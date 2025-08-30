// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// NoSleep
using System;
using UnityEngine;

[Serializable]
public class NoSleep : MonoBehaviour
{
	public void Start()
	{
		rigidbody.sleepVelocity = 0f;
	}

	public void Update()
	{
	}

	public void Main()
	{
	}
}
