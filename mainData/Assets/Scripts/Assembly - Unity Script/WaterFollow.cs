// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// WaterFollow
using System;
using UnityEngine;

[Serializable]
public class WaterFollow : MonoBehaviour
{
	public GameObject Player;

	public void Start()
	{
		Player = GameObject.Find("GlideController");
	}

	public void Update()
	{
		if ((bool)Player)
		{
			float x = Player.transform.position.x;
			Vector3 position = transform.position;
			float num = (position.x = x);
			Vector3 vector = (transform.position = position);
			float z = Player.transform.position.z;
			Vector3 position2 = transform.position;
			float num2 = (position2.z = z);
			Vector3 vector3 = (transform.position = position2);
		}
	}

	public void Main()
	{
	}
}
