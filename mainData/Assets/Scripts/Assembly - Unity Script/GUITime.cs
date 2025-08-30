// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// GUITime
using System;
using UnityEngine;

[Serializable]
public class GUITime : MonoBehaviour
{
	private int DisplayTime;

	private bool DisplaySuccessTime;

	private bool ShowTime;

	private float RewardTimer;

	private int BonusTime;

	private bool DisplayRedTime;

	public float RewardTime;

	public float MaxAlpha;

	public GUIStyle NormalSizeText;

	public GUIStyle NormalSizeTextGreen;

	public GUIStyle LargeSizeTextRed;

	public GUITime()
	{
		DisplayTime = 1000;
		RewardTime = 0.25f;
		MaxAlpha = 0.5f;
	}

	public void Start()
	{
		checked
		{
			guiTexture.pixelInset = new Rect(-52f, unchecked(Screen.height / 2) - 57, 48f, 60f);
			int num = 0;
			Color color = guiTexture.color;
			float num2 = (color.a = num);
			Color color2 = (guiTexture.color = color);
		}
	}

	public void Update()
	{
		if (RewardTimer > 0f)
		{
			RewardTimer -= Time.deltaTime;
		}
	}

	public void OnGUI()
	{
		if (!ShowTime)
		{
			return;
		}
		checked
		{
			if (!DisplayRedTime)
			{
				string text;
				unchecked
				{
					float num = Mathf.Floor(DisplayTime % 3600 / 60);
					float num2 = Mathf.Floor(DisplayTime % 3600 % 60);
					text = null;
					text = ((!(num2 < 10f)) ? (num + ":" + num2) : (num + ":0" + num2));
				}
				if (RewardTimer > 0f)
				{
					GUI.Box(new Rect(unchecked(Screen.width / 2) + 10, 11f, 100f, 50f), text, NormalSizeText);
				}
				else
				{
					GUI.Box(new Rect(unchecked(Screen.width / 2) + 10, 11f, 100f, 50f), text, NormalSizeText);
				}
			}
			else
			{
				GUI.Box(new Rect(unchecked(Screen.width / 2) + 10, 11f, 100f, 50f), DisplayTime + string.Empty, LargeSizeTextRed);
			}
		}
	}

	public void updateTime(int inTime)
	{
		if (inTime < 31)
		{
			DisplayRedTime = true;
		}
		else
		{
			DisplayRedTime = false;
		}
		if (inTime > DisplayTime)
		{
			RewardTimer = RewardTime;
			BonusTime = checked((int)Mathf.Round(inTime - DisplayTime));
		}
		DisplayTime = inTime;
	}

	public void stageComplete()
	{
		ShowTime = false;
		int num = 0;
		Color color = guiTexture.color;
		float num2 = (color.a = num);
		Color color2 = (guiTexture.color = color);
	}

	public void newStage(int inTime)
	{
		DisplayTime = inTime;
		float maxAlpha = MaxAlpha;
		Color color = guiTexture.color;
		float num = (color.a = maxAlpha);
		Color color2 = (guiTexture.color = color);
	}

	public void turnGUIOff()
	{
		guiTexture.enabled = false;
		ShowTime = false;
	}

	public void turnGUIOn()
	{
		guiTexture.enabled = true;
		ShowTime = true;
	}

	public void alignGUI()
	{
		checked
		{
			guiTexture.pixelInset = new Rect(-52f, unchecked(Screen.height / 2) - 57, 48f, 60f);
		}
	}

	public void Main()
	{
	}
}
