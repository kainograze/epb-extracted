// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MissionScript
using System;
using UnityEngine;

[Serializable]
public class MissionScript : MonoBehaviour
{
	public int MissionType;

	public void Update()
	{
	}

	public void OnTriggerEnter(Collider Player)
	{
		GameObject.Find("LevelControl").SendMessage("startMission", MissionType);
		UnityEngine.Object.Destroy(transform.parent);
	}

	public void Main()
	{
	}
}
