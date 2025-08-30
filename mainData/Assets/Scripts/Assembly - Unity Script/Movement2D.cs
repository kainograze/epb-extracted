// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Movement2D
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class Movement2D : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class escapeCutScene$33 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int $___temp93$312;

			internal Vector3 $___temp94$313;

			internal Movement2D $self_314;

			public $(Movement2D self_)
			{
				$self_314 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
				{
					$self_314.transform.position = $self_314.EscapePos.position;
					int num = ($___temp93$312 = 140);
					Vector3 vector = ($___temp94$313 = $self_314.transform.eulerAngles);
					float num2 = ($___temp94$313.y = $___temp93$312);
					Vector3 vector2 = ($self_314.transform.eulerAngles = $___temp94$313);
					$self_314.SendMessage("escapeMovement");
					$self_314.disableMove();
					return Yield(2, new WaitForSeconds(1.5f));
				}
				case 2:
					$self_314.BroadcastMessage("audioOn", 52);
					return Yield(3, new WaitForSeconds(1.5f));
				case 3:
					$self_314.BroadcastMessage("audioOn", 53);
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal Movement2D $self_315;

		public escapeCutScene$33(Movement2D self_)
		{
			$self_315 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_315);
		}
	}

	public Transform[] waypoints;

	public float waypointRadius;

	public float damping;

	public bool loop;

	public float startspeed;

	private float speed;

	public bool faceHeading;

	public Transform EscapePos;

	private Vector3 currentHeading;

	private Vector3 targetHeading;

	private int targetWaypoint;

	private Transform xform;

	private bool useRigidbody;

	private Rigidbody rigidmember;

	private bool Disabled;

	private bool SlowDown;

	private bool reachedLastWaypoint;

	public bool IsAPlane;

	public int StartPos;

	public Movement2D()
	{
		waypointRadius = 1.5f;
		damping = 0.1f;
		loop = false;
		startspeed = 2f;
		speed = 2f;
		faceHeading = true;
		useRigidbody = false;
		Disabled = true;
		reachedLastWaypoint = false;
		StartPos = 0;
	}

	public void Start()
	{
		speed = startspeed;
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
		if (SlowDown)
		{
			speed -= Time.deltaTime * (startspeed / 2f);
			if (speed < 0f)
			{
				speed = 0f;
				disableMove();
				SlowDown = false;
			}
		}
		if (Disabled)
		{
			return;
		}
		Transform[] array = waypoints;
		targetHeading = array[RuntimeServices.NormalizeArrayIndex(array, targetWaypoint)].position - xform.position;
		currentHeading = Vector3.Lerp(currentHeading, targetHeading, damping * Time.deltaTime);
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
		Transform[] array2 = waypoints;
		checked
		{
			if (!(Vector3.Distance(position, array2[RuntimeServices.NormalizeArrayIndex(array2, targetWaypoint)].position) > waypointRadius))
			{
				targetWaypoint++;
				if (targetWaypoint >= waypoints.Length)
				{
					targetWaypoint = 0;
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
				if (i > 0)
				{
					Transform[] array2 = waypoints;
					Vector3 position2 = array2[RuntimeServices.NormalizeArrayIndex(array2, i - 1)].position;
					if (loop)
					{
						Vector3 position3 = waypoints[0].position;
						Transform[] array3 = waypoints;
						Gizmos.DrawLine(position3, array3[RuntimeServices.NormalizeArrayIndex(array3, Extensions.get_length((System.Array)waypoints) - 1)].position);
					}
					Gizmos.DrawLine(position2, position);
				}
				Transform[] array4 = waypoints;
				Gizmos.DrawWireSphere(array4[RuntimeServices.NormalizeArrayIndex(array4, i)].position, waypointRadius);
			}
		}
	}

	public void disableMove()
	{
		Disabled = true;
	}

	public void enableMove()
	{
		Disabled = false;
	}

	public void slowDown()
	{
		if (!IsAPlane)
		{
			SlowDown = true;
			return;
		}
		for (int i = 0; i < waypoints.Length; i = checked(i + 1))
		{
			int num = -32;
			Transform[] array = waypoints;
			Vector3 position = array[RuntimeServices.NormalizeArrayIndex(array, i)].transform.position;
			float num2 = (position.y = num);
			Transform[] array2 = waypoints;
			Vector3 vector = (array2[RuntimeServices.NormalizeArrayIndex(array2, i)].transform.position = position);
		}
		speed += 0.02f;
	}

	public void safelyReposition()
	{
		speed = 0f;
		int num = 0;
		Vector3 eulerAngles = transform.eulerAngles;
		float num2 = (eulerAngles.z = num);
		Vector3 vector = (transform.eulerAngles = eulerAngles);
		int num3 = 0;
		Vector3 eulerAngles2 = transform.eulerAngles;
		float num4 = (eulerAngles2.x = num3);
		Vector3 vector3 = (transform.eulerAngles = eulerAngles2);
		float num5 = 100000f;
		int index = default(int);
		for (int i = 0; i < Extensions.get_length((System.Array)waypoints); i = checked(i + 1))
		{
			float num6 = default(float);
			Vector3 position = transform.position;
			Transform[] array = waypoints;
			num6 = (position - array[RuntimeServices.NormalizeArrayIndex(array, i)].position).magnitude;
			if (num6 < num5)
			{
				num5 = num6;
				index = i;
			}
		}
		Transform obj = transform;
		Transform[] array2 = waypoints;
		obj.position = array2[RuntimeServices.NormalizeArrayIndex(array2, index)].position;
	}

	public void shiftToStart()
	{
		if (Extensions.get_length((System.Array)waypoints) > 0)
		{
			Transform obj = transform;
			Transform[] array = waypoints;
			obj.position = array[RuntimeServices.NormalizeArrayIndex(array, StartPos)].position;
			targetWaypoint = StartPos;
		}
	}

	public IEnumerator escapeCutScene()
	{
		return new escapeCutScene$33(this).GetEnumerator();
	}

	public void Main()
	{
	}
}
