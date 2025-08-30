// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// ZoomStart
using System;
using UnityEngine;

[Serializable]
public class ZoomStart : MonoBehaviour
{
	public Transform Target;

	public int StopZoomDistance;

	public Vector3 ZoomFromPos;

	private bool Active;

	private bool StopZoom;

	private Vector3 targetDir;

	public ZoomStart()
	{
		StopZoomDistance = 45;
		Active = false;
	}

	public void Start()
	{
		Target = GameObject.Find("/TakeOff/Murdoc").transform;
	}

	public void FixedUpdate()
	{
		if (!Active)
		{
			return;
		}
		transform.LookAt(Target);
		if (!StopZoom)
		{
			targetDir = Target.transform.position - transform.position;
			if (targetDir.magnitude < (float)StopZoomDistance)
			{
				StopZoom = true;
			}
			targetDir.Normalize();
			transform.position += targetDir * Time.deltaTime * 200f;
		}
	}

	public void enableFollow()
	{
		Active = false;
	}

	public void introZoom()
	{
		Active = true;
		transform.position = ZoomFromPos;
	}

	public void Main()
	{
	}
}
