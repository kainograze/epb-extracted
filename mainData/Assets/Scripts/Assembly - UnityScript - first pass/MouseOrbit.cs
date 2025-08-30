// d4e5115e396b84ea8820f5b0a8f12827, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MouseOrbit
using System;
using UnityEngine;

[Serializable]
[AddComponentMenu("Camera-Control/Mouse Orbit")]
public class MouseOrbit : MonoBehaviour
{
	public Transform target;

	public float distance;

	public float xSpeed;

	public float ySpeed;

	public int yMinLimit;

	public int yMaxLimit;

	private float x;

	private float y;

	public MouseOrbit()
	{
		distance = 10f;
		xSpeed = 250f;
		ySpeed = 120f;
		yMinLimit = -20;
		yMaxLimit = 80;
		x = 0f;
		y = 0f;
	}

	public void Start()
	{
		Vector3 eulerAngles = transform.eulerAngles;
		x = eulerAngles.y;
		y = eulerAngles.x;
		if ((bool)rigidbody)
		{
			rigidbody.freezeRotation = true;
		}
	}

	public void LateUpdate()
	{
		if ((bool)target)
		{
			x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
			y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
			y = ClampAngle(y, yMinLimit, yMaxLimit);
			Quaternion quaternion = Quaternion.Euler(y, x, 0f);
			Vector3 position = quaternion * new Vector3(0f, 0f, distance * -1f) + target.position;
			transform.rotation = quaternion;
			transform.position = position;
		}
	}

	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360f)
		{
			angle += 360f;
		}
		if (angle > 360f)
		{
			angle -= 360f;
		}
		return Mathf.Clamp(angle, min, max);
	}

	public void Main()
	{
	}
}
