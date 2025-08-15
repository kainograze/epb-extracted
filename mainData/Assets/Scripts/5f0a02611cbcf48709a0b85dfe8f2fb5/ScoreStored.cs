using System;
using UnityEngine;

[Serializable]
public class ScoreStored : MonoBehaviour
{
	public string[] LevelScoresString;
	public int[] LevelScores;
	public MedalScores[] LevelMedalScores;
	public int[] LevelMedals;
	public int TotalScore;
}
