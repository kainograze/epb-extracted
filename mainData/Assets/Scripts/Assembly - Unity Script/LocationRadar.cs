// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// LocationRadar
using System;
using UnityEngine;

[Serializable]
public class LocationRadar : MonoBehaviour
{
	public bool DisplayRadar;

	private GameObject Player;

	public LocationRadar()
	{
		DisplayRadar = true;
	}

	public void Start()
	{
		Player = GameObject.Find("GlideController");
	}

	public void Update()
	{
		if (DisplayRadar && (bool)Player)
		{
			Debug.DrawLine(transform.position, Player.transform.position, Color.green);
		}
	}

	public void turnRadarOn()
	{
		DisplayRadar = true;
	}

	public void Main()
	{
	}
}
