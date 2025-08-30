// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// LocationRubbish
using System;
using UnityEngine;

[Serializable]
public class LocationRubbish : MonoBehaviour
{
	private bool DisplayRadar;

	private GameObject Player;

	public void Start()
	{
		Player = GameObject.Find("GlideController");
	}

	public void Update()
	{
		if (DisplayRadar && (bool)Player)
		{
			Debug.DrawLine(transform.position, Player.transform.position, Color.yellow);
		}
	}

	public void radarToggle()
	{
		DisplayRadar = !DisplayRadar;
	}

	public void Main()
	{
	}
}
