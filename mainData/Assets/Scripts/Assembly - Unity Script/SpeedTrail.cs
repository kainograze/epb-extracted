// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// SpeedTrail
using System;
using UnityEngine;

[Serializable]
public class SpeedTrail : MonoBehaviour
{
	private float FadeInTime;

	private float FadeTimer;

	private bool FadeIn;

	private bool FadeOut;

	public SpeedTrail()
	{
		FadeInTime = 1f;
	}

	public void Start()
	{
		Color white = Color.white;
		white.a = 0f;
		renderer.material.SetColor("_TintColor", white);
	}

	public void Update()
	{
		if (FadeIn)
		{
			setColor();
			FadeTimer += Time.deltaTime;
			if (FadeTimer > FadeInTime)
			{
				FadeIn = false;
				FadeTimer = 1f;
			}
		}
		if (FadeOut)
		{
			setColor();
			FadeTimer -= Time.deltaTime;
			if (FadeTimer < 0f)
			{
				FadeOut = false;
				FadeTimer = 0f;
			}
		}
	}

	public void setColor()
	{
		Color color = renderer.material.GetColor("_TintColor");
		color.a = FadeTimer;
		renderer.material.SetColor("_TintColor", color);
	}

	public void speedBoostOn()
	{
		FadeIn = true;
		FadeOut = false;
	}

	public void speedBoostOff()
	{
		FadeOut = true;
		FadeTimer = FadeInTime;
	}

	public void Main()
	{
	}
}
