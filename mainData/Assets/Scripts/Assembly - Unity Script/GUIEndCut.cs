// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// GUIEndCut
using System;
using UnityEngine;

[Serializable]
public class GUIEndCut : MonoBehaviour
{
	public Texture2D Picture;

	public Texture2D NextButton;

	private bool Active;

	public GUIStyle BlankStyle;

	public void OnGUI()
	{
		GUI.depth = 2;
		checked
		{
			if (Active)
			{
				GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), Picture);
				Rect rect = default(Rect);
				rect = new Rect(unchecked(Screen.width / 2) - unchecked(NextButton.width / 2), (float)Screen.height / 1.32f, NextButton.width, NextButton.height);
				GUI.DrawTexture(rect, NextButton);
				if (GUI.Button(rect, string.Empty, BlankStyle))
				{
					Active = false;
					GameObject.Find("Score").SendMessage("levelComplete");
				}
			}
		}
	}

	public void turnOn()
	{
		audio.Play();
		Active = true;
		GameObject.Find("GameGUI").SendMessage("displayMessage", "That'll stop him!");
	}

	public void turnOff()
	{
		Active = false;
	}

	public void Main()
	{
	}
}
