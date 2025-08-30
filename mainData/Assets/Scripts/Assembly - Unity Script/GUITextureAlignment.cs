// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// GUITextureAlignment
using System;
using UnityEngine;

[Serializable]
public class GUITextureAlignment : MonoBehaviour
{
	private float GUIXPos;

	private float GUIYPos;

	private float GUIWidth;

	private float GUIHeight;

	public int WidthAlignment;

	public int HeightAlignment;

	public GUITextureAlignment()
	{
		WidthAlignment = 0;
		HeightAlignment = 0;
	}

	public void Start()
	{
		GUIWidth = guiTexture.pixelInset.width;
		GUIHeight = guiTexture.pixelInset.height;
		alignGUI();
	}

	public void alignGUI()
	{
		if (WidthAlignment == -1)
		{
			GUIXPos = Screen.width * -1 / 2;
			GUIXPos -= 1f;
		}
		else if (WidthAlignment == 0)
		{
			float num = GUIWidth * -1f / 2f;
		}
		else if (WidthAlignment == 1)
		{
			GUIXPos = (float)(Screen.width / 2) - GUIWidth;
		}
		if (HeightAlignment == -1)
		{
			GUIYPos = (float)(Screen.height / 2) - GUIHeight;
			GUIYPos += 1f;
		}
		else if (HeightAlignment == 0)
		{
			GUIYPos = GUIHeight * -1f / 2f;
		}
		else if (HeightAlignment == 1)
		{
			GUIYPos = Screen.height * -1 / 2;
		}
		guiTexture.pixelInset = new Rect(GUIXPos, GUIYPos, GUIWidth, GUIHeight);
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
