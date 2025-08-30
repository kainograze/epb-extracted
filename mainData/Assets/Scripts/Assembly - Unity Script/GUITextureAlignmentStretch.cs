// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// GUITextureAlignmentStretch
using System;
using UnityEngine;

[Serializable]
public class GUITextureAlignmentStretch : MonoBehaviour
{
	public void Start()
	{
		alignGUI();
	}

	public void alignGUI()
	{
		guiTexture.pixelInset = new Rect(Screen.width * -1 / 2, checked(unchecked(Screen.height / 2) - Screen.height), Screen.width, Screen.height);
	}

	public void Main()
	{
	}
}
