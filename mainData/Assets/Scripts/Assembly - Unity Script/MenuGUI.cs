// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MenuGUI
using System;
using UnityEngine;

[Serializable]
public class MenuGUI : MonoBehaviour
{
	public Transform Music1;

	public Transform Music2;

	public Transform Music3;

	private int CurrentMusic;

	public MenuGUI()
	{
		CurrentMusic = 1;
	}

	public void Start()
	{
		Time.timeScale = 1f;
		Screen.SetResolution(1100, 576, fullscreen: false);
		GameObject gameObject = null;
		gameObject = GameObject.Find("Music");
		if (!gameObject)
		{
			UnityEngine.Object.Instantiate(Music1, transform.position, Quaternion.identity);
		}
	}

	public void OnGUI()
	{
		checked
		{
			GUI.Box(new Rect(unchecked(Screen.width / 2) - 150, 30f, 300f, 30f), "GLIDING GAME");
			if (GUI.Button(new Rect(unchecked(Screen.width / 2) - 100, 140f, 200f, 30f), "Level 1"))
			{
				Application.LoadLevel(1);
			}
			if (GUI.Button(new Rect(unchecked(Screen.width / 2) - 100, 190f, 200f, 30f), "Level 2"))
			{
				Application.LoadLevel(2);
			}
			if (GUI.Button(new Rect(unchecked(Screen.width / 2) - 100, 240f, 200f, 30f), "Level 3"))
			{
				Application.LoadLevel(3);
			}
			if (GUI.Button(new Rect(unchecked(Screen.width / 2) - 100, 290f, 200f, 30f), "Level 4"))
			{
				Application.LoadLevel(4);
			}
			if (GUI.Button(new Rect(unchecked(Screen.width / 2) - 60, Screen.height - 100, 120f, 30f), "Change Music"))
			{
				changeMusic();
			}
		}
	}

	public void changeMusic()
	{
		UnityEngine.Object.Destroy(GameObject.Find("Music"));
		checked
		{
			CurrentMusic++;
			if (CurrentMusic > 3)
			{
				CurrentMusic = 1;
			}
			if (CurrentMusic == 1)
			{
				UnityEngine.Object.Instantiate(Music1, transform.position, Quaternion.identity);
			}
			else if (CurrentMusic == 2)
			{
				UnityEngine.Object.Instantiate(Music2, transform.position, Quaternion.identity);
			}
			else
			{
				UnityEngine.Object.Instantiate(Music3, transform.position, Quaternion.identity);
			}
		}
	}

	public void Main()
	{
	}
}
