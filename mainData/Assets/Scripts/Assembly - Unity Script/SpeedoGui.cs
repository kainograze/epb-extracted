// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// SpeedoGui
using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class SpeedoGui : MonoBehaviour
{
	public GUIStyle NormalSizeText;

	private int Speed;

	private bool DisplayText;

	public void Start()
	{
		checked
		{
			guiTexture.pixelInset = new Rect(unchecked(Screen.width / 2) - 156, unchecked(Screen.height / 2) - 63, 156f, 64f);
		}
	}

	public void OnGUI()
	{
		if (DisplayText && Speed > 0)
		{
			GUI.Box(new Rect(checked(Screen.width - 151), -5f, 100f, 50f), Speed + "mph", NormalSizeText);
		}
	}

	public void updateSpeed(object inSpeed)
	{
		Speed = RuntimeServices.UnboxInt32(inSpeed);
	}

	public void turnGUIOff()
	{
		guiTexture.enabled = false;
		DisplayText = false;
	}

	public void turnGUIOn()
	{
		guiTexture.enabled = true;
		DisplayText = true;
	}

	public void alignGUI()
	{
		checked
		{
			guiTexture.pixelInset = new Rect(unchecked(Screen.width / 2) - 156, unchecked(Screen.height / 2) - 63, 156f, 64f);
		}
	}

	public void Main()
	{
	}
}
