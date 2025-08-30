// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// DestroyOneShot
using System;
using UnityEngine;

[Serializable]
public class DestroyOneShot : MonoBehaviour
{
	private float LifeTimer;

	private float LifeTime;

	public void Start()
	{
		LifeTime = particleEmitter.maxEnergy;
	}

	public void Update()
	{
		LifeTimer += Time.deltaTime;
		if (LifeTimer > LifeTime)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	public void Main()
	{
	}
}
