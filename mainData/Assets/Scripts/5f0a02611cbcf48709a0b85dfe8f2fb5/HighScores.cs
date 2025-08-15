using System;
using UnityEngine;

[Serializable]
public class HighScores : MonoBehaviour
{
	public Texture2D ScoreBoardTexture;
	public Texture2D SubmitScore;
	public GUIStyle BlankStyle;
	public GUIStyle ScoreTextRight;
	public GUIStyle ScoreTextLeft;
	public GUIStyle ScoreTextMiddle;
	public ScoreEntry[] Current10;
}
