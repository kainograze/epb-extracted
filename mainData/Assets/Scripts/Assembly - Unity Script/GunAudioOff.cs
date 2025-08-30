// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// GunAudioOff
using System;
using UnityEngine;

[Serializable]
public class GunAudioOff : MonoBehaviour
{
	public void Update()
	{
		if (Time.timeScale == 0f)
		{
			audio.Stop();
			SendMessage("stopShooting");
		}
	}

	public void Main()
	{
	}
}
