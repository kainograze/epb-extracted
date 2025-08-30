// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Submarine2D
using System;
using UnityEngine;

[Serializable]
public class Submarine2D : MonoBehaviour
{
	public float SurfaceTime;

	private float SurfaceTimer;

	public float DiveTime;

	private float DiveTimer;

	private bool Diving;

	public Submarine2D()
	{
		SurfaceTime = 40f;
		DiveTime = 7f;
	}

	public void Start()
	{
		SurfaceTime = SurfaceTimer;
		DiveTime = DiveTimer;
	}

	public void Update()
	{
		if (!Diving)
		{
			SurfaceTimer -= Time.deltaTime;
			if (!(SurfaceTimer < 0f))
			{
			}
		}
	}

	public void Main()
	{
	}
}
