using System;
using UnityEngine;

[Serializable]
public class TitleScreen : MonoBehaviour
{
	public Texture2D StartButton;
	public Texture2D OptionsButton;
	public Texture2D HighScoresButton;
	public Texture2D BackButton;
	public Texture2D LockedLevel;
	public Texture2D NormalButton;
	public Texture2D OptionsSelectButton;
	public Texture2D BronzeLevel;
	public Texture2D SilverLevel;
	public Texture2D GoldLevel;
	public GUIStyle BlankStyle;
	public Texture2D PurchaseAlbum;
	public Texture2D TextBackground;
	public GUIStyle ComicNormalText;
	public GUIStyle ComicNormalTextSmall;
	public GUIStyle ComicNormalTextWhite;
	public GUIStyle NormalTextSize8;
	public GUIStyle NormalTextSize8Centre;
	public GUIStyle NormalTextCentreBlack;
	public GUIStyle SmallerText;
	public GUIStyle NormalTextBlack;
	public GUIStyle LargeTextBlack;
	public Texture2D LoadLevelScreen;
	public ScoreStored ScoreStored;
	public int[] LevelMedals;
	public bool[] LevelsUnlocked;
	public int[] LevelScores;
}
