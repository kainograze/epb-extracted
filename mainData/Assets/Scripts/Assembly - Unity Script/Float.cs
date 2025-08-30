// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Float
using System;
using UnityEngine;

[Serializable]
public class Float : MonoBehaviour
{
	private float OriginalYPos;

	public float MovementAmount;

	public Float()
	{
		MovementAmount = 1.2f;
	}

	public void Start()
	{
		OriginalYPos = transform.position.y;
	}

	public void Update()
	{
		float y = OriginalYPos + Mathf.Sin(Time.time * 2f) * MovementAmount;
		Vector3 position = transform.position;
		float num = (position.y = y);
		Vector3 vector = (transform.position = position);
	}

	public void Main()
	{
	}
}
