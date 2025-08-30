// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Score
using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class Score : MonoBehaviour
{
	public bool BonusLevelScoreSystem;

	public bool FinalBonusLevelSystem;

	public float DisplayScoreTime;

	public int MinePoints;

	public int TimeRingPoints;

	public int PiratePoints;

	public int SecondPoints;

	public int Disable2DPoints;

	public int BonusPoints;

	public int LandingPoints;

	public int DollPoints;

	public int HealthBonusPoints;

	public int TimeBonusPoints;

	public int TargetPoints;

	public Texture2D GoldMedalTexture;

	public Texture2D SilverMedalTexture;

	public Texture2D BronzeMedalTexture;

	public Texture2D NoMedalTexture;

	public Texture2D NextLevelButton;

	public Texture2D RetryLevelButton;

	public Texture2D MainMenuButton;

	public Texture2D ScoreBackground;

	public Texture2D ScoreBanner;

	public Texture2D MedalGold;

	public Texture2D MedalSilver;

	public Texture2D MedalBronze;

	private GameObject GUIObject;

	private float DisplayScoreTimer;

	private int ScoreType;

	private int LevelScore;

	private int OtherBonusScore;

	private float ScoreTimeRemaining;

	private int MinesDestroyed;

	private int PiratesDestroyed;

	private float Stage1TimeLeft;

	private float Stage2TimeLeft;

	private float Stage3TimeLeft;

	private int TotalPirates;

	private int CurrentPiratesKilled;

	private int TotalTimeRings;

	private int CurrentTimeRings;

	private int TotalDolls;

	private int CurrentDolls;

	private int CurrentBonuses;

	private int TotalTargets;

	private int CurrentTargets;

	private bool EndScore;

	private bool SafeLanding;

	private bool FailedLevel;

	public GUIStyle NormalTextSize;

	public GUIStyle NormalTextSizeGold;

	public GUIStyle NormalTextSizeBeige;

	public GUIStyle NormalTextSmall;

	public GUIStyle ComicNormalTextSize;

	public GUIStyle ComicSmallTextSize;

	public int GoldLimit;

	public int SilverLimit;

	public int BronzeLimit;

	public object g;

	public Score()
	{
		DisplayScoreTime = 0.7f;
		MinePoints = 50;
		TimeRingPoints = 10;
		PiratePoints = 400;
		SecondPoints = 10;
		Disable2DPoints = 250;
		BonusPoints = 300;
		LandingPoints = 250;
		DollPoints = 40;
		HealthBonusPoints = 10;
		TimeBonusPoints = 10;
		TargetPoints = 2;
	}

	public void Start()
	{
		if ((bool)GameObject.Find("Gorillaz"))
		{
			g = GameObject.Find("Gorillaz").GetComponent("Gorillaz");
			UnityRuntimeServices.Invoke(g, "StartLevelToken", new object[1] { checked(Application.loadedLevel + 725) }, typeof(MonoBehaviour));
			getMedalLimits();
		}
		GUIObject = GameObject.Find("GameGUI");
		GameObject gameObject = GameObject.Find("PirateBoats");
		if ((bool)gameObject)
		{
			TotalPirates = gameObject.transform.childCount;
		}
		GameObject gameObject2 = GameObject.Find("TimeRings");
		if ((bool)gameObject2)
		{
			TotalTimeRings = gameObject2.transform.childCount;
		}
		GameObject gameObject3 = GameObject.Find("Dolls");
		if ((bool)gameObject3)
		{
			TotalDolls = gameObject3.transform.childCount;
		}
		GameObject gameObject4 = GameObject.Find("Targets");
		if ((bool)gameObject4)
		{
			TotalTargets = gameObject4.transform.childCount;
		}
	}

	public void Update()
	{
		if (DisplayScoreTimer > 0f)
		{
			DisplayScoreTimer -= Time.deltaTime;
			if (!(DisplayScoreTimer > 0f))
			{
				GUIObject.BroadcastMessage("scoreBannerOff");
			}
		}
	}

	public void sendScore(int inID)
	{
		GUIObject.BroadcastMessage("scoreBannerOn");
		ScoreType = inID;
		DisplayScoreTimer = DisplayScoreTime;
		checked
		{
			if (ScoreType == 1)
			{
				LevelScore += TargetPoints;
				CurrentTargets++;
			}
			if (ScoreType == 2)
			{
				PiratesDestroyed++;
				LevelScore += PiratePoints;
				CurrentPiratesKilled++;
			}
			if (ScoreType == 4)
			{
				CurrentTimeRings++;
				LevelScore += TimeRingPoints;
			}
			if (ScoreType == 5)
			{
				audio.Play();
			}
			if (ScoreType == 7)
			{
				audio.Play();
			}
			if (ScoreType == 8)
			{
				CurrentDolls++;
				LevelScore += DollPoints;
			}
			if (ScoreType == 9)
			{
				LevelScore += Disable2DPoints;
			}
			if (ScoreType == 10)
			{
				LevelScore += BonusPoints;
				CurrentBonuses++;
			}
			if (ScoreType == 11)
			{
				LevelScore += LandingPoints;
				SafeLanding = true;
			}
		}
	}

	public void timeLeftBonus(float inTime)
	{
		if (!FinalBonusLevelSystem)
		{
			ScoreTimeRemaining = Mathf.Floor(inTime);
			LevelScore = checked((int)((float)LevelScore + ScoreTimeRemaining));
		}
	}

	public void stageComplete(float inTime)
	{
		if (!FinalBonusLevelSystem)
		{
			GUIObject.BroadcastMessage("scoreBannerOn");
			if (inTime > 0f)
			{
				audio.Play();
			}
			DisplayScoreTimer = DisplayScoreTime * 2.5f;
			ScoreTimeRemaining = Mathf.Round(inTime);
			ScoreType = 3;
			LevelScore = checked((int)((float)LevelScore + ScoreTimeRemaining * (float)SecondPoints));
		}
	}

	public void levelComplete()
	{
		GUIObject.SendMessage("cutSceneOff");
		EndScore = true;
		checked
		{
			if ((bool)GameObject.Find("Gorillaz"))
			{
				UnityRuntimeServices.Invoke(g, "SetGameScore", new object[1] { LevelScore }, typeof(MonoBehaviour));
				if (CurrentBonuses > 0)
				{
					for (int i = 0; i < CurrentBonuses; i++)
					{
						UnityRuntimeServices.Invoke(g, "AddAchievement", new object[1] { Application.loadedLevel * 5 + 743 + i }, typeof(MonoBehaviour));
					}
				}
			}
			if (PlayerPrefs.GetInt("PlayerProgress") <= Application.loadedLevel && LevelScore > BronzeLimit)
			{
				PlayerPrefs.SetInt("PlayerProgress", Application.loadedLevel + 1);
			}
			if (!SafeLanding)
			{
				LandingPoints = 0;
			}
		}
	}

	public void updateScore()
	{
		PlayerPrefs.SetInt("PlayerScore", checked(PlayerPrefs.GetInt("PlayerScore") + LevelScore));
	}

	public void OnGUI()
	{
		int num = 76;
		int num2 = 32;
		int num3 = 200;
		int num4 = num3 / 2;
		checked
		{
			if (DisplayScoreTimer > 0f)
			{
				if (ScoreType == 1)
				{
					GUI.Box(new Rect(unchecked(Screen.width / 2) - num4, num, num3, num2), "Target Destroyed\n+" + TargetPoints + "pts", ComicSmallTextSize);
					GUI.Box(new Rect(65f, 50f, 200f, 80f), CurrentTargets + " of " + TotalTargets + " Targets Destroyed", ComicSmallTextSize);
				}
				else if (ScoreType == 2)
				{
					GUI.Box(new Rect(unchecked(Screen.width / 2) - num4, num, num3, num2), "Pirate Ghost Ship\n+" + PiratePoints + "pts", ComicSmallTextSize);
					GUI.Box(new Rect(65f, 50f, 200f, 80f), CurrentPiratesKilled + " of " + TotalPirates + " Ghost Pirate Ships Destroyed", ComicSmallTextSize);
				}
				else if (ScoreType == 4)
				{
					GUI.Box(new Rect(unchecked(Screen.width / 2) - num4, num, num3, num2), "Time Ring +" + TimeRingPoints + "pts\n" + "+5secs", ComicSmallTextSize);
					GUI.Box(new Rect(65f, 50f, 200f, 80f), CurrentTimeRings + " of " + TotalTimeRings + " Time Rings Collected", ComicSmallTextSize);
				}
				else if (ScoreType == 5)
				{
					GUI.Box(new Rect(unchecked(Screen.width / 2) - num4, num, num3, num2), "Time Bonus +30secs", ComicSmallTextSize);
				}
				else if (ScoreType == 7)
				{
					GUI.Box(new Rect(unchecked(Screen.width / 2) - num4, num, num3, num2), "Health +1", ComicSmallTextSize);
				}
				else if (ScoreType == 8)
				{
					GUI.Box(new Rect(unchecked(Screen.width / 2) - num4, num, num3, num2), "G Club Cube\nCollected +" + DollPoints + "pts", ComicSmallTextSize);
					GUI.Box(new Rect(65f, 50f, 200f, 80f), CurrentDolls + " of " + TotalDolls + " G Club Cubes Collected", ComicSmallTextSize);
				}
				else if (ScoreType == 9)
				{
					GUI.Box(new Rect(unchecked(Screen.width / 2) - num4, num, num3, num2), "2D's vehicle Disabled \n+" + Disable2DPoints + "pts", ComicSmallTextSize);
				}
				else if (ScoreType == 10)
				{
					GUI.Box(new Rect(unchecked(Screen.width / 2) - num4, num, num3, num2), "Bonus Collected \n+" + BonusPoints + "pts", ComicSmallTextSize);
				}
				else if (ScoreType == 11)
				{
					GUI.Box(new Rect(unchecked(Screen.width / 2) - num4, num, num3, num2), "Safe Landing \n+" + LandingPoints + "pts", ComicSmallTextSize);
				}
			}
			if (EndScore)
			{
				GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), ScoreBackground);
				int num5 = Application.loadedLevel - 1;
				Rect position;
				Rect position2;
				unchecked
				{
					GUI.Box(new Rect((float)(Screen.width / 2) - (float)Screen.width / 3.15f, Screen.height / 33, (float)Screen.width / 2.5f, (float)Screen.height / 8.5f), "Demo Level Complete", ComicNormalTextSize);
					float left = Screen.width / 50;
					float top = Screen.width / 10;
					float width = (float)Screen.width / 2.7f;
					float height = Screen.height / 2;
					position = new Rect(left, top, width, height);
					if (!BonusLevelScoreSystem)
					{
						GUI.Box(position, "Pirate Ghost Ships:\n" + "Time Rings Passed:\n" + "G Club Cubes Collected:\n" + "Bonuses Collected:\n" + "Targets Destroyed:\n" + "2D Stopped:\n" + "Landing Bonus:\n\n" + "LEVEL SCORE:", NormalTextSizeBeige);
					}
					else if (!FinalBonusLevelSystem)
					{
						GUI.Box(position, "Pirate Ghost Ships:\n" + "Time Rings Passed:\n" + "G Club Cubes Collected:\n" + "Targets Destroyed:\n" + "Landing Bonus:\n" + "Time Remaining:\n\n" + "LEVEL SCORE:", NormalTextSizeBeige);
					}
					else
					{
						GUI.Box(position, "Pirate Ghost Ships:\n" + "G Club Cubes Collected:\n" + "Targets Destroyed:\n" + "Landing Bonus:\n\n" + "LEVEL SCORE:", NormalTextSizeBeige);
					}
					float left2 = position.x + position.width + 7f;
					float y = position.y;
					float width2 = Screen.width / 2;
					float height2 = position.height;
					position2 = new Rect(left2, y, width2, height2);
				}
				if (!BonusLevelScoreSystem)
				{
					GUI.Box(position2, string.Empty + CurrentPiratesKilled * PiratePoints + "pts\n" + CurrentTimeRings * TimeRingPoints + "pts\n" + CurrentDolls * DollPoints + "pts\n" + CurrentBonuses * BonusPoints + "pts\n" + CurrentTargets * TargetPoints + "pts\n" + Disable2DPoints + "pts\n" + LandingPoints + "pts\n\n" + LevelScore + "pts", NormalTextSize);
				}
				else if (!FinalBonusLevelSystem)
				{
					GUI.Box(position2, string.Empty + CurrentPiratesKilled * PiratePoints + "pts\n" + CurrentTimeRings * TimeRingPoints + "pts\n" + CurrentDolls * DollPoints + "pts\n" + CurrentTargets * TargetPoints + "pts\n" + LandingPoints + "pts\n" + ScoreTimeRemaining + "pts\n\n" + LevelScore + "pts", NormalTextSize);
				}
				else
				{
					GUI.Box(position2, string.Empty + CurrentPiratesKilled * PiratePoints + "pts\n" + CurrentDolls * DollPoints + "pts\n" + CurrentTargets * TargetPoints + "pts\n" + LandingPoints + "pts\n\n" + LevelScore + "pts", NormalTextSize);
				}
				Vector2 vector = new Vector2(237f, 57f);
				Rect position3 = new Rect(position.x + position.width - vector.x / 2f, position.y + position.height, vector.x, vector.y);
				position3.y += vector.y;
				GUI.DrawTexture(position3, RetryLevelButton);
				if (GUI.Button(position3, string.Empty, NormalTextSize))
				{
					Application.LoadLevel(Application.loadedLevel);
				}
				position3.y += vector.y;
				GUI.DrawTexture(position3, MainMenuButton);
				if (GUI.Button(position3, string.Empty, NormalTextSize))
				{
					Application.LoadLevel(1);
				}
				if (LevelScore >= GoldLimit)
				{
					GUI.DrawTexture(new Rect(Screen.width - 296, Screen.height - 315, 296f, 315f), GoldMedalTexture);
				}
				else if (LevelScore >= SilverLimit)
				{
					GUI.DrawTexture(new Rect(Screen.width - 296, Screen.height - 315, 296f, 315f), SilverMedalTexture);
				}
				else if (LevelScore >= BronzeLimit)
				{
					GUI.DrawTexture(new Rect(Screen.width - 296, Screen.height - 315, 296f, 315f), BronzeMedalTexture);
				}
				else
				{
					GUI.DrawTexture(new Rect(Screen.width - 296, Screen.height - 315, 296f, 315f), NoMedalTexture);
				}
			}
			if (FailedLevel)
			{
				Rect position4 = new Rect(unchecked(Screen.width / 2) - RetryLevelButton.width - 5, unchecked(Screen.height / 4) * 3, RetryLevelButton.width, RetryLevelButton.height);
				GUI.DrawTexture(position4, RetryLevelButton);
				if (GUI.Button(position4, string.Empty, NormalTextSize))
				{
					Application.LoadLevel(Application.loadedLevel);
				}
				position4.x += MainMenuButton.width + 10;
				GUI.DrawTexture(position4, MainMenuButton);
				if (GUI.Button(position4, string.Empty, NormalTextSize))
				{
					Application.LoadLevel(1);
				}
			}
			if (!EndScore)
			{
				Rect rect = default(Rect);
				rect = new Rect(new Rect(12f, Screen.height - 93, ScoreBanner.width, ScoreBanner.height));
				rect.x += 10f;
				rect.y -= 3f;
				GUI.DrawTexture(rect, ScoreBanner);
				rect.x -= 14f;
				rect.y -= 3f;
				if (LevelScore < BronzeLimit)
				{
					GUI.Box(rect, LevelScore + "/" + BronzeLimit + "pts", NormalTextSmall);
					GUI.DrawTexture(new Rect(0f, rect.y, (float)MedalGold.width * 0.9f, (float)MedalGold.height * 0.9f), MedalBronze);
				}
				else if (LevelScore < SilverLimit)
				{
					GUI.Box(rect, LevelScore + "/" + SilverLimit + "pts", NormalTextSmall);
					GUI.DrawTexture(new Rect(0f, rect.y, (float)MedalGold.width * 0.9f, (float)MedalGold.height * 0.9f), MedalSilver);
				}
				else if (LevelScore < GoldLimit)
				{
					GUI.Box(rect, LevelScore + "/" + GoldLimit + "pts", NormalTextSmall);
					GUI.DrawTexture(new Rect(0f, rect.y, (float)MedalGold.width * 0.9f, (float)MedalGold.height * 0.9f), MedalGold);
				}
				else
				{
					GUI.Box(rect, LevelScore + "pts", NormalTextSizeGold);
					GUI.DrawTexture(new Rect(0f, rect.y, (float)MedalGold.width * 0.9f, (float)MedalGold.height * 0.9f), MedalGold);
				}
			}
		}
	}

	public void getMedalLimits()
	{
		checked
		{
			GoldLimit = RuntimeServices.UnboxInt32(RuntimeServices.GetSlice(g, "gold", new object[1] { Application.loadedLevel + 725 }));
			SilverLimit = RuntimeServices.UnboxInt32(RuntimeServices.GetSlice(g, "silver", new object[1] { Application.loadedLevel + 725 }));
			BronzeLimit = RuntimeServices.UnboxInt32(RuntimeServices.GetSlice(g, "bronze", new object[1] { Application.loadedLevel + 725 }));
		}
	}

	public void failedLevel()
	{
		FailedLevel = true;
	}

	public void Main()
	{
	}
}
