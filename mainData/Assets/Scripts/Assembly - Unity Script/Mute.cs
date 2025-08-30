// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Mute
using System;
using UnityEngine;

[Serializable]
public class Mute : MonoBehaviour
{
	public Texture2D MuteOn;

	public Texture2D MuteOff;

	private bool Muted;

	public GUIStyle BlankStyle;

	public void Start()
	{
		if (PlayerPrefs.GetInt("MuteOn") == 1)
		{
			switchMute();
		}
	}

	public void OnGUI()
	{
		GUI.depth = 0;
		Rect rect = default(Rect);
		rect = new Rect(0f, 50f, MuteOn.width, MuteOn.height);
		if (Muted)
		{
			GUI.DrawTexture(rect, MuteOff);
		}
		else
		{
			GUI.DrawTexture(rect, MuteOn);
		}
		if (GUI.Button(rect, string.Empty, BlankStyle))
		{
			switchMute();
		}
	}

	public void switchMute()
	{
		Muted = !Muted;
		if (Muted)
		{
			PlayerPrefs.SetInt("MuteOn", 1);
			AudioListener.volume = 0f;
		}
		else
		{
			PlayerPrefs.SetInt("MuteOn", 0);
			AudioListener.volume = 1f;
		}
	}

	public void Main()
	{
	}
}
