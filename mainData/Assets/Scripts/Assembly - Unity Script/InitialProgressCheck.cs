// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// InitialProgressCheck
using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class InitialProgressCheck : MonoBehaviour
{
	public object g;

	public int[] LevelMedals;

	public Texture2D LoadBackground;

	public void Start()
	{
		if ((bool)GameObject.Find("Gorillaz"))
		{
			g = GameObject.Find("Gorillaz").GetComponent("Gorillaz");
			setLevelMedals();
		}
	}

	private void setLevelMedals()
	{
		PlayerPrefs.SetInt("PlayerProgress", 0);
		checked
		{
			for (int i = 0; i < Extensions.get_length((System.Array)LevelMedals); i++)
			{
				if (RuntimeServices.ToBool(RuntimeServices.GetSlice(g, "ach_bronze", new object[1] { i + 727 })))
				{
					int[] levelMedals = LevelMedals;
					levelMedals[RuntimeServices.NormalizeArrayIndex(levelMedals, i)] = 1;
					continue;
				}
				if (RuntimeServices.ToBool(RuntimeServices.GetSlice(g, "ach_silver", new object[1] { i + 727 })))
				{
					int[] levelMedals2 = LevelMedals;
					levelMedals2[RuntimeServices.NormalizeArrayIndex(levelMedals2, i)] = 2;
					continue;
				}
				if (RuntimeServices.ToBool(RuntimeServices.GetSlice(g, "ach_gold", new object[1] { i + 727 })))
				{
					int[] levelMedals3 = LevelMedals;
					levelMedals3[RuntimeServices.NormalizeArrayIndex(levelMedals3, i)] = 3;
					continue;
				}
				int[] levelMedals4 = LevelMedals;
				levelMedals4[RuntimeServices.NormalizeArrayIndex(levelMedals4, i)] = 0;
				PlayerPrefs.SetInt("PlayerProgress", i + 2);
				i = Extensions.get_length((System.Array)LevelMedals);
			}
		}
	}

	public void OnGUI()
	{
		GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), LoadBackground);
	}

	public void Main()
	{
	}
}
