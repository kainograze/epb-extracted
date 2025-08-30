// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// AudioOnOff
using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class AudioOnOff : MonoBehaviour
{
	public int ID;

	public void Update()
	{
	}

	public void audioOn(object inID)
	{
		if (RuntimeServices.EqualityOperator(inID, ID))
		{
			audio.Play();
		}
	}

	public void audioOff(object inID)
	{
		if (RuntimeServices.EqualityOperator(inID, ID))
		{
			audio.Stop();
		}
	}

	public void allAudioOff()
	{
		audio.Stop();
	}

	public void Main()
	{
	}
}
