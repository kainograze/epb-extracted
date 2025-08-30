// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// WhaleSeek
using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class WhaleSeek : MonoBehaviour
{
	public Transform[] waypoints;

	public float waypointRadius;

	public float damping;

	private bool loop;

	public float speed;

	private bool faceHeading;

	public States state;

	private Vector3 currentHeading;

	private Vector3 targetHeading;

	private int targetWaypoint;

	private Transform xform;

	private bool useRigidbody;

	private Rigidbody rigidmember;

	private float jumpImpulse;

	public WhaleSeek()
	{
		waypointRadius = 70f;
		damping = 0.58f;
		loop = true;
		speed = 2f;
		faceHeading = true;
		useRigidbody = false;
		jumpImpulse = 10f;
	}

	public void Start()
	{
		transform.position = waypoints[0].transform.position;
		state = States.Patrolling;
		xform = transform;
		currentHeading = xform.forward;
		if (Extensions.get_length((System.Array)waypoints) <= 0)
		{
			Debug.Log("No waypoints on " + name);
			enabled = false;
		}
		targetWaypoint = 0;
		if (rigidbody != null)
		{
			useRigidbody = true;
			rigidmember = rigidbody;
		}
	}

	public void FixedUpdate()
	{
		Transform[] array = waypoints;
		targetHeading = array[RuntimeServices.NormalizeArrayIndex(array, targetWaypoint)].position - xform.position;
		currentHeading = Vector3.Lerp(currentHeading, targetHeading, damping * Time.deltaTime);
	}

	public void Update()
	{
		FollowPath();
	}

	public void FollowPath()
	{
		if (speed < 0.7f)
		{
			speed += 0.005f;
		}
		else
		{
			speed = 0.7f;
		}
		if (useRigidbody)
		{
			rigidmember.velocity = currentHeading * speed;
		}
		else
		{
			xform.position += currentHeading * Time.deltaTime * speed;
		}
		if (faceHeading)
		{
			xform.LookAt(xform.position + currentHeading);
		}
		Vector3 position = xform.position;
		Transform[] array = waypoints;
		if (Vector3.Distance(position, array[RuntimeServices.NormalizeArrayIndex(array, targetWaypoint)].position) > waypointRadius)
		{
			return;
		}
		checked
		{
			targetWaypoint++;
			if (targetWaypoint >= waypoints.Length)
			{
				targetWaypoint = 0;
				if (!loop)
				{
					enabled = false;
				}
			}
		}
	}

	public void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		checked
		{
			for (int i = 0; i < waypoints.Length; i++)
			{
				Transform[] array = waypoints;
				Vector3 position = array[RuntimeServices.NormalizeArrayIndex(array, i)].position;
				if (i >= 0)
				{
					Transform[] array2 = waypoints;
					Vector3 position2 = array2[RuntimeServices.NormalizeArrayIndex(array2, i - 1)].position;
					Gizmos.DrawLine(position2, position);
				}
				Transform[] array3 = waypoints;
				Gizmos.DrawWireSphere(array3[RuntimeServices.NormalizeArrayIndex(array3, i)].position, waypointRadius);
			}
		}
	}

	public void Main()
	{
	}
}
