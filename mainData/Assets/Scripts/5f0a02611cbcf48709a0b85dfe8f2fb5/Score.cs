using System;
using UnityEngine;

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
	public Texture2D LoadingScreen;
	public Texture2D ScoreBanner;
	public Texture2D MedalGold;
	public Texture2D MedalSilver;
	public Texture2D MedalBronze;
	public GUIStyle NormalTextSize;
	public GUIStyle NormalTextSizeRight;
	public GUIStyle NormalTextSizeGold;
	public GUIStyle NormalTextSizeBeige;
	public GUIStyle NormalTextSmall;
	public GUIStyle ComicNormalTextSize;
	public GUIStyle ComicNormalCentreTextSize;
	public GUIStyle ComicSmallTextSize;
	public GUIStyle ComicNormalText;
	public int GoldLimit;
	public int SilverLimit;
	public int BronzeLimit;
	public int CurrentLevel;
	public float DescriptionInsetX;
	public float DescriptionInsetY;
	public float DescriptionWidth;
	public float DescriptionHeight;
	public Rect DescriptionBounds;
	public Transform HighScoreMarker;
	public Texture2D YesButton;
	public Texture2D NoButton;
	public GUIStyle BlankStyle;
}
