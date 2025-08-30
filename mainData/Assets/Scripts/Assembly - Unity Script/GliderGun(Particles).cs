// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// GliderGun(Particles)
using System;
using UnityEngine;

[Serializable]
public class GliderGun(Particles) : MonoBehaviour
{
	public void Update()
	{
	}

	public void resetVelocity()
	{
		particleEmitter.localVelocity = default(Vector3);
	}

	public void gunsOn()
	{
		particleEmitter.emit = true;
	}

	public void gunsOff()
	{
		particleEmitter.emit = false;
	}

	public void setBulletTrajectory(Vector3 inVector)
	{
		inVector *= 100f;
		particleEmitter.worldVelocity = inVector;
	}

	public void OnParticleCollision(GameObject other)
	{
		if (other.gameObject.tag == "Hittable")
		{
			other.SendMessage("Hit");
		}
	}

	public void speedBoostOn()
	{
		int num = 280;
		Vector3 localVelocity = particleEmitter.localVelocity;
		float num2 = (localVelocity.z = num);
		Vector3 vector = (particleEmitter.localVelocity = localVelocity);
	}

	public void speedBoostOff()
	{
		int num = 140;
		Vector3 localVelocity = particleEmitter.localVelocity;
		float num2 = (localVelocity.z = num);
		Vector3 vector = (particleEmitter.localVelocity = localVelocity);
	}

	public void Main()
	{
	}
}
