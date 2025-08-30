// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MuzzleFlash
using System;
using UnityEngine;

[Serializable]
public class MuzzleFlash : MonoBehaviour
{
	private bool Shooting;

	public float FlashTime;

	private float FlashTimer;

	public void Update()
	{
		if (!Shooting)
		{
			return;
		}
		FlashTimer -= Time.deltaTime;
		if (FlashTimer < 0f)
		{
			float num = UnityEngine.Random.Range(1, 6);
			if (num > 3f)
			{
				renderer.enabled = false;
				return;
			}
			renderer.enabled = true;
			num *= 0.3333f;
			float y = num;
			Vector2 mainTextureOffset = renderer.material.mainTextureOffset;
			float num2 = (mainTextureOffset.y = y);
			Vector2 vector = (renderer.material.mainTextureOffset = mainTextureOffset);
			FlashTimer = FlashTime;
		}
	}

	public void startShooting()
	{
		Shooting = true;
		renderer.enabled = true;
	}

	public void gunsOff()
	{
		Shooting = false;
		renderer.enabled = false;
	}

	public void Main()
	{
	}
}
