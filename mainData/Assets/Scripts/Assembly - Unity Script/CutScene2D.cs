// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// CutScene2D
using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class CutScene2D : MonoBehaviour
{
	public bool OnRight;

	public Texture2D Picture1;

	public Texture2D TextBannerTop;

	public Texture2D SpeechBubble;

	private bool Active;

	public GUIStyle ComicTextSmall;

	public string[] Text;

	public float[] DisplayTimes;

	public int StageLimit;

	public int StageMove;

	private int CurrentStage;

	private float Timer;

	public CutScene2D()
	{
		StageLimit = 5;
		StageMove = 4;
	}

	public void Start()
	{
		float[] displayTimes = DisplayTimes;
		Timer = displayTimes[RuntimeServices.NormalizeArrayIndex(displayTimes, CurrentStage)];
		updateText();
	}

	public void Update()
	{
		if (!Active)
		{
			return;
		}
		Timer -= Time.deltaTime;
		checked
		{
			if (Timer < 0f)
			{
				CurrentStage++;
				playAudio();
				if (CurrentStage >= StageLimit)
				{
					endCutScene();
				}
				else
				{
					float[] displayTimes = DisplayTimes;
					Timer = displayTimes[RuntimeServices.NormalizeArrayIndex(displayTimes, CurrentStage)];
				}
			}
			if (Input.GetKeyDown("space"))
			{
				BroadcastMessage("allAudioOff");
				endCutScene();
			}
		}
	}

	public void OnGUI()
	{
		if (!Active)
		{
			return;
		}
		if (CurrentStage < StageLimit)
		{
			GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), Picture1);
			string[] text = Text;
			if (text[RuntimeServices.NormalizeArrayIndex(text, CurrentStage)] != string.Empty)
			{
				if (OnRight)
				{
					GUI.DrawTexture(new Rect((float)Screen.width / 2.7f, Screen.height / 12, 234f, 157f), SpeechBubble);
					Rect position = new Rect((float)Screen.width / 2.7f, Screen.height / 12, 234f, 157f);
					string[] text2 = Text;
					GUI.Box(position, text2[RuntimeServices.NormalizeArrayIndex(text2, CurrentStage)], ComicTextSmall);
				}
				else
				{
					GUI.DrawTexture(new Rect(Screen.width / 3, Screen.height / 7, 234f, 157f), SpeechBubble);
					Rect position2 = new Rect(Screen.width / 3, Screen.height / 7, 234f, 157f);
					string[] text3 = Text;
					GUI.Box(position2, text3[RuntimeServices.NormalizeArrayIndex(text3, CurrentStage)], ComicTextSmall);
				}
			}
		}
		checked
		{
			GUI.DrawTexture(new Rect(unchecked(Screen.width / 2) - unchecked(TextBannerTop.width / 2), 0f, TextBannerTop.width, TextBannerTop.height), TextBannerTop);
			GUI.Box(new Rect(unchecked(Screen.width / 2) - unchecked(TextBannerTop.width / 2), 0f, TextBannerTop.width, TextBannerTop.height), "In 2D 's Room...", ComicTextSmall);
		}
	}

	public void cutSceneActive()
	{
		Active = true;
	}

	public void cutSceneInactive()
	{
		Active = false;
	}

	public void endCutScene()
	{
		GameObject.Find("LevelControl").SendMessage("endIntroScene");
	}

	public void updateText()
	{
		Text[1] = "Murdoc's locked me \ndown here again...";
		Text[3] = "I need to get away...";
		if (Application.loadedLevel == 2)
		{
			Text[5] = "I've got to escape...";
		}
		else if (Application.loadedLevel == 1)
		{
			Text[5] = "TO THE \nBANANAMOBILE!";
		}
		else if (Application.loadedLevel == 6)
		{
			Text[5] = "That sub...\nThat sub sh.. should\ndo the trick.\nHe'll hardly see me...";
		}
		else if (Application.loadedLevel == 8)
		{
			Text[5] = "If I can get\nthat plane off the\nground... Sorry, water...\nI'm OUTTA HERE!";
		}
	}

	public void playAudio()
	{
		if (CurrentStage == 1)
		{
			BroadcastMessage("audioOn", 40);
		}
		if (CurrentStage == 3)
		{
			BroadcastMessage("audioOn", 41);
		}
		if (CurrentStage == 5)
		{
			BroadcastMessage("audioOn", 42);
		}
	}

	public void Main()
	{
	}
}
