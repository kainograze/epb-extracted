// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// RotateObject
using System;
using UnityEngine;

[Serializable]
public class RotateObject : MonoBehaviour
{
	public void Update()
	{
		float y = Time.time * 35f;
		Vector3 eulerAngles = transform.eulerAngles;
		float num = (eulerAngles.y = y);
		Vector3 vector = (transform.eulerAngles = eulerAngles);
	}

	public void Main()
	{
	}
}
