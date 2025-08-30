// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// CannonBallBehaviour
using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class CannonBallBehaviour : MonoBehaviour
{
	public float Speed;

	public float Interval;

	private float IntervalTimer;

	private bool LockOn;

	private GameObject Target;

	private Vector3 Trajectory;

	public void Start()
	{
		gameObject.name = "CannonBall";
		IntervalTimer = Interval;
	}

	public void Update()
	{
		MonoBehaviour.print(transform.position);
		IntervalTimer = -1f;
		if (IntervalTimer < 0f && LockOn)
		{
			Vector3 vector = Target.transform.position - transform.position;
			vector.Normalize();
			Trajectory.Normalize();
			if ((Trajectory - vector).magnitude > 0.3f)
			{
			}
			Trajectory = vector * Speed;
			IntervalTimer = Interval;
		}
		transform.position += Trajectory;
		if (transform.position.z < -780f)
		{
			SendMessage("Hit");
		}
		Debug.DrawLine(transform.position, Target.transform.position, Color.red);
	}

	public void setTarget(object inTarget)
	{
		Target = (GameObject)RuntimeServices.Coerce(inTarget, typeof(GameObject));
		Vector3 vector = Target.transform.position - transform.position;
		vector.Normalize();
		Trajectory = vector * Speed;
		LockOn = true;
	}

	public void OnTriggerEnter(Collider Other)
	{
		if (Other.gameObject.name == "GlideController")
		{
			Other.SendMessage("Hit");
			SendMessage("Hit");
		}
	}

	public void Main()
	{
	}
}
