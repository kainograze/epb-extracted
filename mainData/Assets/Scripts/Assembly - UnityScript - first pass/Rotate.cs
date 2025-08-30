// d4e5115e396b84ea8820f5b0a8f12827, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Rotate
using System;
using UnityEngine;

[Serializable]
public class Rotate : MonoBehaviour
{
	public Vector3 RotateAxis;

	public int RotateSpeed;

	public Rotate()
	{
		RotateAxis = Vector3.forward;
		RotateSpeed = 20;
	}

	public void Update()
	{
		if ((bool)transform)
		{
			transform.Rotate(RotateAxis * Time.deltaTime * RotateSpeed);
		}
	}

	public void Main()
	{
	}
}
