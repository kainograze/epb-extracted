// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// ScoreBanner
using System;
using UnityEngine;

[Serializable]
public class ScoreBanner : MonoBehaviour
{
	public void Start()
	{
		checked
		{
			guiTexture.pixelInset = new Rect(-116f, unchecked(Screen.height / 2) - 120, 233f, 53f);
			int num = 0;
			Color color = guiTexture.color;
			float num2 = (color.a = num);
			Color color2 = (guiTexture.color = color);
		}
	}

	public void scoreBannerOn()
	{
		float a = 0.35f;
		Color color = guiTexture.color;
		float num = (color.a = a);
		Color color2 = (guiTexture.color = color);
	}

	public void scoreBannerOff()
	{
		int num = 0;
		Color color = guiTexture.color;
		float num2 = (color.a = num);
		Color color2 = (guiTexture.color = color);
	}

	public void alignGUI()
	{
		checked
		{
			guiTexture.pixelInset = new Rect(-116f, unchecked(Screen.height / 2) - 120, 233f, 53f);
		}
	}

	public void Main()
	{
	}
}
