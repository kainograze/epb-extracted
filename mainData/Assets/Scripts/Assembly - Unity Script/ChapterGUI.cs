// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// ChapterGUI
using System;
using UnityEngine;

[Serializable]
public class ChapterGUI : MonoBehaviour
{
	public GUIStyle NormalSizeText;

	private int CurrentChapter;

	private bool DisplayText;

	public ChapterGUI()
	{
		DisplayText = true;
	}

	public void Start()
	{
		guiTexture.pixelInset = new Rect(Screen.width * -1 / 2, Screen.height * -1 / 2, 146f, 58f);
		CurrentChapter = Application.loadedLevel;
	}

	public void OnGUI()
	{
		checked
		{
			if (DisplayText)
			{
				int loadedLevel = Application.loadedLevel;
				loadedLevel--;
				GUI.Box(new Rect(11f, Screen.height - 33, 120f, 30f), "Demo Level ", NormalSizeText);
			}
		}
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
		guiTexture.pixelInset = new Rect(Screen.width * -1 / 2, Screen.height * -1 / 2, 146f, 58f);
	}

	public void Main()
	{
	}
}
