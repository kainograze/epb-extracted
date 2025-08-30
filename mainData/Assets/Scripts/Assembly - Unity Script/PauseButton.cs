// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// PauseButton
using System;
using UnityEngine;

[Serializable]
public class PauseButton : MonoBehaviour
{
	private float ButtonWidth;

	private float ButtonHeight;

	public GUIStyle BlankStyle;

	private bool DisplayOptions;

	public Texture2D MainMenu;

	public Texture2D Continue;

	public void Start()
	{
		ButtonWidth = guiTexture.pixelInset.width;
		ButtonHeight = guiTexture.pixelInset.height;
		guiTexture.pixelInset = new Rect(Screen.width * -1 / 2, (float)(Screen.height * -1 / 2) + (float)Screen.height / 4.5f, ButtonWidth, ButtonHeight);
	}

	public void Update()
	{
	}

	public void OnGUI()
	{
		if (GUI.Button(new Rect(5f, (float)Screen.height - (float)Screen.height / 4.5f - ButtonHeight, ButtonWidth, ButtonHeight), string.Empty, BlankStyle))
		{
			DisplayOptions = true;
			Time.timeScale = 0f;
		}
		checked
		{
			if (DisplayOptions)
			{
				if (Time.timeScale > 0f)
				{
					DisplayOptions = false;
				}
				GUI.DrawTexture(new Rect(unchecked(Screen.width / 2) - 116, unchecked(Screen.height / 2) - 90, 237f, 57f), MainMenu);
				if (GUI.Button(new Rect(unchecked(Screen.width / 2) - 116, unchecked(Screen.height / 2) - 90, 237f, 57f), string.Empty, BlankStyle))
				{
					Time.timeScale = 1f;
					Application.LoadLevel(1);
				}
				GUI.DrawTexture(new Rect(unchecked(Screen.width / 2) - 116, unchecked(Screen.height / 2) - 28, 237f, 57f), Continue);
				if (GUI.Button(new Rect(unchecked(Screen.width / 2) - 116, unchecked(Screen.height / 2) - 28, 237f, 57f), string.Empty, BlankStyle))
				{
					DisplayOptions = false;
					Time.timeScale = 1f;
				}
			}
		}
	}

	public void alignGUI()
	{
		ButtonWidth = guiTexture.pixelInset.width;
		ButtonHeight = guiTexture.pixelInset.height;
		guiTexture.pixelInset = new Rect(Screen.width * -1 / 2, (float)(Screen.height * -1 / 2) + (float)Screen.height / 4.5f, ButtonWidth, ButtonHeight);
	}

	public void Main()
	{
	}
}
