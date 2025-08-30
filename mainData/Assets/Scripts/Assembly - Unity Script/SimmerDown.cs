// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// SimmerDown
using System;
using UnityEngine;

[Serializable]
public class SimmerDown : MonoBehaviour
{
	public float SimmerDownTime;

	public bool Sink;

	public int SinkSpeedPerSec;

	private float DeltaTimeMultiplication;

	private bool m_SimmerDown;

	public SimmerDown()
	{
		SimmerDownTime = 2f;
		SinkSpeedPerSec = 8;
	}

	public void Start()
	{
		DeltaTimeMultiplication = particleEmitter.minEmission / SimmerDownTime;
	}

	public void Update()
	{
		if (m_SimmerDown)
		{
			particleEmitter.minEmission -= Time.deltaTime * DeltaTimeMultiplication;
			particleEmitter.minEmission -= Time.deltaTime * DeltaTimeMultiplication;
			if (Sink)
			{
				float y = transform.position.y - Time.deltaTime * (float)SinkSpeedPerSec;
				Vector3 position = transform.position;
				float num = (position.y = y);
				Vector3 vector = (transform.position = position);
			}
			if (particleEmitter.minEmission < 0f)
			{
				particleEmitter.emit = false;
			}
		}
	}

	public void turnOn()
	{
		m_SimmerDown = true;
	}

	public void sinkFire()
	{
		Sink = true;
	}

	public void Main()
	{
	}
}
