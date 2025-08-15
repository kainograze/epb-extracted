using System;
using UnityEngine;

[Serializable]
public class CutScene2D : MonoBehaviour
{
	public bool OnRight;
	public Texture2D Picture1;
	public Texture2D TextBannerTop;
	public Texture2D SpeechBubble;
	public GUIStyle ComicTextSmall;
	public string[] Text;
	public float[] DisplayTimes;
	public int StageLimit;
	public int StageMove;
}
