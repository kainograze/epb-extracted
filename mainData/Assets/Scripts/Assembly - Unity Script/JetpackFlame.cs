// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// JetpackFlame
using System;
using UnityEngine;

[Serializable]
public class JetpackFlame : MonoBehaviour
{
	public void flameOn()
	{
		particleEmitter.emit = true;
	}

	public void flameOff()
	{
		particleEmitter.emit = false;
	}

	public void matchGliderSpeed(float inSpeed)
	{
		Vector3 localVelocity = particleEmitter.localVelocity;
		float num = (localVelocity.z = inSpeed);
		Vector3 vector = (particleEmitter.localVelocity = localVelocity);
	}

	public void Main()
	{
	}
}
