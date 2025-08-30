// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Rotate
using System;
using UnityEngine;

[Serializable]
public class Rotate : MonoBehaviour
{
	public Vector3 RotateAxis;

	public int RotateSpeed;

	private bool Rotation;

	public Rotate()
	{
		RotateAxis = Vector3.forward;
		RotateSpeed = 20;
	}

	public void Update()
	{
		if (Rotation && (bool)transform)
		{
			transform.Rotate(RotateAxis * Time.deltaTime * RotateSpeed);
		}
	}

	public void stopRotation()
	{
		Rotation = false;
	}

	public void startRotation()
	{
		Rotation = true;
	}

	public void Main()
	{
	}
}
