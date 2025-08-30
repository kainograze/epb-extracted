// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// SpeedWind
using System;
using UnityEngine;

[Serializable]
public class SpeedWind : MonoBehaviour
{
	public void Update()
	{
	}

	public void windSpeedOn()
	{
		particleEmitter.emit = true;
	}

	public void windSpeedOff()
	{
		particleEmitter.emit = false;
	}

	public void speedBoostOn()
	{
		particleEmitter.minSize = 0.2f;
		particleEmitter.maxSize = 0.2f;
	}

	public void speedBoostOff()
	{
		particleEmitter.minSize = 0.1f;
		particleEmitter.maxSize = 0.1f;
	}

	public void Main()
	{
	}
}
