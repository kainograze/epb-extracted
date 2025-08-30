// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// EscapeMove
using System;
using UnityEngine;

[Serializable]
public class EscapeMove : MonoBehaviour
{
	private bool Active;

	public float Speed;

	public void Update()
	{
		if (Active)
		{
			float z = transform.position.z - Speed * Time.deltaTime;
			Vector3 position = transform.position;
			float num = (position.z = z);
			Vector3 vector = (transform.position = position);
			float x = transform.position.x + Speed * Time.deltaTime;
			Vector3 position2 = transform.position;
			float num2 = (position2.x = x);
			Vector3 vector3 = (transform.position = position2);
		}
	}

	public void escapeMovement()
	{
		Active = true;
	}

	public void Main()
	{
	}
}
