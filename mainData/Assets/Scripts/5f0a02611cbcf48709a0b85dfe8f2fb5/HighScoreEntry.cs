using System;
using UnityEngine;

[Serializable]
public class HighScoreEntry : MonoBehaviour
{
	public Texture2D Background;
	public Texture2D SubmitButton;
	public GUIStyle BlankStyle;
	public GUIStyle NormalBlackText;
	public GUIStyle LargeBlackText;
	public string ScoreName;
	public int MaxNameLength;
	public ScoreStored scoreStored;
	public bool waiting;
}
