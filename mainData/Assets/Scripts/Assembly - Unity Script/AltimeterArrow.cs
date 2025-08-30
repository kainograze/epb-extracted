// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// AltimeterArrow
using System;
using UnityEngine;

[Serializable]
public class AltimeterArrow : MonoBehaviour
{
	public int BottomLimit;

	public int TopLimit;

	public int RealBottomLimit;

	public int RealTopLimit;

	public float MaxHeight;

	private float CurrentHeight;

	public AltimeterArrow()
	{
		BottomLimit = -165;
		TopLimit = 146;
		RealBottomLimit = -32;
		RealTopLimit = 368;
		MaxHeight = 400f;
	}

	public void Start()
	{
		checked
		{
			guiTexture.pixelInset = new Rect(unchecked(Screen.width / 2) - 70, 146f, 33f, 29f);
			updateAltimeter(0f);
		}
	}

	public void updateAltimeter(float inHeight)
	{
		checked
		{
			if (inHeight > MaxHeight)
			{
				guiTexture.pixelInset = new Rect(unchecked(Screen.width / 2) - 70, TopLimit, 33f, 29f);
				return;
			}
			CurrentHeight = (float)(TopLimit - BottomLimit) / MaxHeight * inHeight + (float)BottomLimit;
			guiTexture.pixelInset = new Rect(unchecked(Screen.width / 2) - 70, CurrentHeight, 33f, 29f);
		}
	}

	public void turnGUIOff()
	{
		guiTexture.enabled = false;
	}

	public void turnGUIOn()
	{
		guiTexture.enabled = true;
	}

	public void Main()
	{
	}
}
