// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// FadeIn
using System;
using UnityEngine;

[Serializable]
public class FadeIn : MonoBehaviour
{
	private bool FadeIn;

	private bool FadeOut;

	private bool SafetyNet;

	private float InsuranceTimer;

	public void Start()
	{
	}

	public void Update()
	{
		if (FadeIn)
		{
			float a = guiTexture.color.a + Time.deltaTime * 4f;
			Color color = guiTexture.color;
			float num = (color.a = a);
			Color color2 = (guiTexture.color = color);
			if (!(guiTexture.color.a < 1f))
			{
				FadeIn = false;
				int num2 = 1;
				Color color4 = guiTexture.color;
				float num3 = (color4.a = num2);
				Color color5 = (guiTexture.color = color4);
				FadeOut = true;
			}
		}
		if (FadeOut)
		{
			float a2 = guiTexture.color.a - Time.deltaTime * 4f;
			Color color7 = guiTexture.color;
			float num4 = (color7.a = a2);
			Color color8 = (guiTexture.color = color7);
			if (!(guiTexture.color.a > 0f))
			{
				int num5 = 0;
				Color color10 = guiTexture.color;
				float num6 = (color10.a = num5);
				Color color11 = (guiTexture.color = color10);
				FadeOut = false;
			}
		}
		if (SafetyNet)
		{
			InsuranceTimer -= Time.deltaTime;
			if (InsuranceTimer < 0f)
			{
				int num7 = 0;
				Color color13 = guiTexture.color;
				float num8 = (color13.a = num7);
				Color color14 = (guiTexture.color = color13);
				FadeOut = false;
				FadeIn = false;
			}
		}
	}

	public void setFadeIn()
	{
		FadeIn = true;
		SafetyNet = true;
		InsuranceTimer = 0.75f;
	}

	public void Main()
	{
	}
}
