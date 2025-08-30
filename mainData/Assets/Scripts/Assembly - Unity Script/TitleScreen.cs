// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// TitleScreen
using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class TitleScreen : MonoBehaviour
{
	public Texture2D StartButton;

	public Texture2D MainMenuButton;

	public Texture2D BackButton;

	public Texture2D LockedLevel;

	public Texture2D NormalLevel;

	public Texture2D BronzeLevel;

	public Texture2D SilverLevel;

	public Texture2D GoldLevel;

	public Texture2D LoadingScreen;

	public GUIStyle BlankStyle;

	public Texture2D PurchaseAlbum;

	public Texture2D TextBackground;

	public GUIStyle ComicNormalText;

	public GUIStyle ComicNormalTextSmall;

	public GUIStyle ComicNormalTextWhite;

	public GUIStyle NormalTextSize8;

	private bool DisplayLevelSelect;

	private bool DisplayMain;

	private bool DisplayLoadingScreen;

	public object g;

	public int[] LevelMedals;

	public bool[] LevelsUnlocked;

	public int[] LevelScores;

	public void Start()
	{
		DisplayMain = true;
		if ((bool)GameObject.Find("Gorillaz"))
		{
			g = GameObject.Find("Gorillaz").GetComponent("Gorillaz");
			setLevelMedals();
			setLevelScores();
		}
		setUnlockedLevels();
	}

	public void Update()
	{
	}

	public void OnGUI()
	{
		if (DisplayMain)
		{
			GUI.DrawTexture(new Rect(Screen.width / 2, (float)Screen.height - (float)Screen.height / 1.3f, 237f, 57f), StartButton);
			if (GUI.Button(new Rect(Screen.width / 2, (float)Screen.height - (float)Screen.height / 1.3f, 237f, 57f), string.Empty, BlankStyle))
			{
				loadLevel(1);
			}
			GUI.DrawTexture(new Rect(Screen.width / 2, (float)Screen.height - (float)Screen.height / 1.7f, 237f, 57f), MainMenuButton);
			if (GUI.Button(new Rect(Screen.width / 2, (float)Screen.height - (float)Screen.height / 1.7f, 237f, 57f), string.Empty, BlankStyle))
			{
				Application.ExternalEval("parent.unity_link(\"http://gorillaz.com/g-player/games/etpb?menu=1\");");
			}
		}
		Rect rect = default(Rect);
		rect = new Rect(checked(Screen.width - PurchaseAlbum.width), (float)Screen.height - (float)PurchaseAlbum.height / 1.35f, PurchaseAlbum.width, PurchaseAlbum.height);
		GUI.DrawTexture(rect, PurchaseAlbum);
		if (GUI.Button(rect, string.Empty, BlankStyle))
		{
			Application.OpenURL("http://links.emi.com/plasticbeach10");
		}
		if (DisplayLoadingScreen)
		{
			GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), LoadingScreen);
		}
	}

	private void loadLevel(int inLevel)
	{
		DisplayLoadingScreen = true;
		Application.LoadLevel(inLevel);
	}

	private string assignLevelDescription(object inID)
	{
		string text = null;
		if (RuntimeServices.EqualityOperator(inID, 1))
		{
			return "2D's escaped in the Orka. Hunt him down and bring him back before he gets too far away";
		}
		if (RuntimeServices.EqualityOperator(inID, 3))
		{
			return "2D's escaped in the Speedboat. Hunt him down and bring him back before he gets too far away";
		}
		if (RuntimeServices.EqualityOperator(inID, 5))
		{
			return "2D's escaped in the Submarine. Hunt him down and bring him back before he gets too far away";
		}
		if (RuntimeServices.EqualityOperator(inID, 7))
		{
			return "2D's escaped in the Plane. Hunt him down and bring him back before he gets too far away";
		}
		if (RuntimeServices.EqualityOperator(inID, 8))
		{
			return "Survive long enough amidst a horde of pirate ghost ships to rack up your score";
		}
		return "Glide back to the Island, avoid the ghost pirate ships and shoot the targets";
	}

	private Texture2D returnLevelIcon(int inID)
	{
		bool[] levelsUnlocked = LevelsUnlocked;
		if (levelsUnlocked[RuntimeServices.NormalizeArrayIndex(levelsUnlocked, inID)])
		{
			int[] levelMedals = LevelMedals;
			return levelMedals[RuntimeServices.NormalizeArrayIndex(levelMedals, inID)] switch
			{
				1 => BronzeLevel, 
				2 => SilverLevel, 
				3 => GoldLevel, 
				_ => NormalLevel, 
			};
		}
		return LockedLevel;
	}

	private void setLevelMedals()
	{
		checked
		{
			for (int i = 0; i < Extensions.get_length((System.Array)LevelMedals); i++)
			{
				if (RuntimeServices.ToBool(RuntimeServices.GetSlice(g, "ach_gold", new object[1] { i + 727 })))
				{
					int[] levelMedals = LevelMedals;
					levelMedals[RuntimeServices.NormalizeArrayIndex(levelMedals, i)] = 3;
				}
				else if (RuntimeServices.ToBool(RuntimeServices.GetSlice(g, "ach_silver", new object[1] { i + 727 })))
				{
					int[] levelMedals2 = LevelMedals;
					levelMedals2[RuntimeServices.NormalizeArrayIndex(levelMedals2, i)] = 2;
				}
				else if (RuntimeServices.ToBool(RuntimeServices.GetSlice(g, "ach_bronze", new object[1] { i + 727 })))
				{
					int[] levelMedals3 = LevelMedals;
					levelMedals3[RuntimeServices.NormalizeArrayIndex(levelMedals3, i)] = 1;
				}
				else
				{
					int[] levelMedals4 = LevelMedals;
					levelMedals4[RuntimeServices.NormalizeArrayIndex(levelMedals4, i)] = 0;
				}
			}
		}
	}

	private void setLevelScores()
	{
		checked
		{
			for (int i = 0; i < Extensions.get_length((System.Array)LevelScores); i++)
			{
				int[] levelScores = LevelScores;
				levelScores[RuntimeServices.NormalizeArrayIndex(levelScores, i)] = RuntimeServices.UnboxInt32(RuntimeServices.GetSlice(g, "levelscore", new object[1] { i + 727 }));
			}
		}
	}

	private void setUnlockedLevels()
	{
		checked
		{
			for (int i = 1; i < Extensions.get_length((System.Array)LevelsUnlocked); i++)
			{
				int[] levelMedals = LevelMedals;
				if (levelMedals[RuntimeServices.NormalizeArrayIndex(levelMedals, i - 1)] > 0)
				{
					bool[] levelsUnlocked = LevelsUnlocked;
					levelsUnlocked[RuntimeServices.NormalizeArrayIndex(levelsUnlocked, i)] = true;
					continue;
				}
				bool[] levelsUnlocked2 = LevelsUnlocked;
				levelsUnlocked2[RuntimeServices.NormalizeArrayIndex(levelsUnlocked2, i)] = false;
				PlayerPrefs.SetInt("PlayerProgress", i + 1);
				for (int j = i; j < Extensions.get_length((System.Array)LevelsUnlocked); j++)
				{
					bool[] levelsUnlocked3 = LevelsUnlocked;
					levelsUnlocked3[RuntimeServices.NormalizeArrayIndex(levelsUnlocked3, j)] = false;
				}
				i = Extensions.get_length((System.Array)LevelsUnlocked);
			}
			LevelsUnlocked[0] = true;
		}
	}

	public void Main()
	{
	}
}
