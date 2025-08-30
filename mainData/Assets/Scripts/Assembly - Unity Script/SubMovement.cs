// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// SubMovement
using System;
using UnityEngine;

[Serializable]
public class SubMovement : MonoBehaviour
{
	public float SurfaceTime;

	private float SurfaceTimer;

	public float UnderwaterTime;

	private float UnderwaterTimer;

	private bool Diving;

	private bool Surfaced;

	private bool Underwater;

	private bool Surfacing;

	private bool Disabled;

	public int DiveSpeed;

	public Transform WayPoints;

	private int CurrentPos;

	public void Start()
	{
		Disabled = true;
		startDive();
		SurfaceTimer = SurfaceTime;
		UnderwaterTimer = UnderwaterTime;
	}

	public void Update()
	{
		if (Disabled)
		{
			return;
		}
		if (Surfaced)
		{
			SurfaceTimer -= Time.deltaTime;
			if (SurfaceTimer < 0f)
			{
				startDive();
			}
		}
		if (Diving)
		{
			float y = transform.position.y - Time.deltaTime * (float)DiveSpeed;
			Vector3 position = transform.position;
			float num = (position.y = y);
			Vector3 vector = (transform.position = position);
			float y2 = transform.position.y;
			Vector3 position2 = WayPoints.position;
			float num2 = (position2.y = y2);
			Vector3 vector3 = (WayPoints.position = position2);
			if (transform.position.y < -80f)
			{
				int num3 = -80;
				Vector3 position3 = transform.position;
				float num4 = (position3.y = num3);
				Vector3 vector5 = (transform.position = position3);
				stopDive();
			}
		}
		if (Underwater)
		{
			UnderwaterTimer -= Time.deltaTime;
			if (UnderwaterTimer < 0f)
			{
				startSurface();
			}
		}
		if (Surfacing)
		{
			float y3 = transform.position.y + Time.deltaTime * (float)DiveSpeed;
			Vector3 position4 = transform.position;
			float num5 = (position4.y = y3);
			Vector3 vector7 = (transform.position = position4);
			float y4 = transform.position.y;
			Vector3 position5 = WayPoints.position;
			float num6 = (position5.y = y4);
			Vector3 vector9 = (WayPoints.position = position5);
			if (transform.position.y > -34f)
			{
				int num7 = -34;
				Vector3 position6 = transform.position;
				float num8 = (position6.y = num7);
				Vector3 vector11 = (transform.position = position6);
				stopSurfacing();
			}
		}
	}

	public void startDive()
	{
		Diving = true;
		Surfaced = false;
		SurfaceTimer = SurfaceTime;
	}

	public void stopDive()
	{
		Diving = false;
		Underwater = true;
	}

	public void startSurface()
	{
		Underwater = false;
		UnderwaterTimer = UnderwaterTime;
		Surfacing = true;
	}

	public void stopSurfacing()
	{
		Surfaced = true;
		Surfacing = false;
	}

	public void enableMove()
	{
		Disabled = false;
	}

	public void disableMove()
	{
		Disabled = true;
	}

	public void slowDown()
	{
		Disabled = true;
	}

	public void Main()
	{
	}
}
