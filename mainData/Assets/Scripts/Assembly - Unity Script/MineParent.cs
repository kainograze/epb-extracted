// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MineParent
using System;
using UnityEngine;

[Serializable]
public class MineParent : MonoBehaviour
{
	public int FallSpeedPerSec;

	private float OriginalYPos;

	private bool Falling;

	private bool BalloonPopped;

	public void Start()
	{
		OriginalYPos = transform.position.y;
	}

	public void Update()
	{
		if (Falling)
		{
			float y = transform.position.y - Time.deltaTime * (float)FallSpeedPerSec;
			Vector3 position = transform.position;
			float num = (position.y = y);
			Vector3 vector = (transform.position = position);
		}
		else
		{
			float y2 = OriginalYPos + Mathf.Sin(Time.time * 2f) * 6f;
			Vector3 position2 = transform.position;
			float num2 = (position2.y = y2);
			Vector3 vector3 = (transform.position = position2);
		}
	}

	public void balloonPopped()
	{
		if (transform.childCount > 1)
		{
			BroadcastMessage("altitudeCheck");
			Falling = true;
		}
	}

	public void mineHit()
	{
		if (transform.childCount > 1)
		{
			BroadcastMessage("popBalloon");
			BalloonPopped = true;
		}
	}

	public void removeParent()
	{
		UnityEngine.Object.Destroy(gameObject);
	}

	public void Main()
	{
	}
}
