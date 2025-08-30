// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// ParticleEmitters
using System;
using UnityEngine;

[Serializable]
public class ParticleEmitters : MonoBehaviour
{
	public void Update()
	{
	}

	public void turnOn()
	{
		particleEmitter.emit = true;
	}

	public void turnOff()
	{
		particleEmitter.emit = false;
	}

	public void Main()
	{
	}
}
