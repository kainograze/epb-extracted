// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// AltimeterOverlay
using System;
using UnityEngine;

[Serializable]
public class AltimeterOverlay : MonoBehaviour
{
	public void Start()
	{
		alignGUI();
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
			guiTexture.pixelInset = new Rect(unchecked(Screen.width / 2) - 46, -183f, 46f, 367f);
		}
	}

	public void Main()
	{
	}
}
