// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// ArrowMarker
using System;
using UnityEngine;

[Serializable]
public class ArrowMarker : MonoBehaviour
{
	private Transform target;

	private float IterationTimer;

	public void Start()
	{
		target = GameObject.Find("TwoD").transform;
		IterationTimer = 0.05f;
	}

	public void Update()
	{
		if ((bool)target)
		{
			IterationTimer -= Time.deltaTime;
			if (IterationTimer < 0f)
			{
				Vector3 vector = target.position - transform.position;
				float num = Mathf.Atan2(vector.x, vector.z);
				num *= 57.29578f;
				float y = num - transform.parent.eulerAngles.y - 180f;
				Vector3 localEulerAngles = transform.localEulerAngles;
				float num2 = (localEulerAngles.y = y);
				Vector3 vector2 = (transform.localEulerAngles = localEulerAngles);
				IterationTimer = 0.01f;
			}
		}
	}

	public void changeTarget(Transform inTarget)
	{
		target = inTarget;
		showArrow();
	}

	public void showArrow()
	{
		BroadcastMessage("showObject");
	}

	public void Main()
	{
	}
}
