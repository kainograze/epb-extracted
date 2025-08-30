// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// HealthBarOverlay
using System;
using UnityEngine;

[Serializable]
public class HealthBarOverlay : MonoBehaviour
{
	public void Start()
	{
		checked
		{
			guiTexture.pixelInset = new Rect(unchecked(Screen.width * -1 / 2) + 44, unchecked(Screen.height / 2) - 31, 188f, 33f);
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

	public void alignGUI()
	{
		checked
		{
			guiTexture.pixelInset = new Rect(unchecked(Screen.width * -1 / 2) + 44, unchecked(Screen.height / 2) - 31, 188f, 33f);
		}
	}

	public void Main()
	{
	}
}
