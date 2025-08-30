// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// BulletsObject
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class BulletsObject : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class lifespanCheck$68 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal BulletsObject $self_400;

			public $(BulletsObject self_)
			{
				$self_400 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					return Yield(2, new WaitForSeconds(0.25f));
				case 2:
					$self_400.makeInactive();
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal BulletsObject $self_401;

		public lifespanCheck$68(BulletsObject self_)
		{
			$self_401 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_401);
		}
	}

	public float InitialSpeedPerSec;

	private int SpeedPerSec;

	private Vector3 Trajectory;

	private bool Active;

	private Transform ParentTransform;

	private float LifeSpanTimer;

	public float LifeSpanTime;

	private Transform TransformReference;

	public BulletsObject()
	{
		InitialSpeedPerSec = 3f;
		LifeSpanTime = 0.25f;
	}

	public void Awake()
	{
		TransformReference = transform;
	}

	public void Start()
	{
		makeInactive();
		SpeedPerSec = checked((int)InitialSpeedPerSec);
	}

	public void FixedUpdate()
	{
		if (Active)
		{
			TransformReference.position += Trajectory * SpeedPerSec;
		}
	}

	public IEnumerator lifespanCheck()
	{
		return new lifespanCheck$68(this).GetEnumerator();
	}

	public void makeActive(float inSpeed)
	{
		SpeedPerSec = checked((int)((float)SpeedPerSec * inSpeed));
		TransformReference.position = ParentTransform.position;
		Active = true;
		setAngle();
		setTrajectory();
		StartCoroutine("lifespanCheck");
	}

	public void makeInactive()
	{
		SpeedPerSec = checked((int)InitialSpeedPerSec);
		Active = false;
		int num = 100000;
		Vector3 position = TransformReference.position;
		float num2 = (position.x = num);
		Vector3 vector = (TransformReference.position = position);
		StopCoroutine("lifespanCheck");
	}

	public void setParentTransform(Transform inTransform)
	{
		ParentTransform = inTransform;
	}

	public void setAngle()
	{
		TransformReference.rotation = ParentTransform.rotation;
		float y = ParentTransform.eulerAngles.y;
		Vector3 localEulerAngles = TransformReference.localEulerAngles;
		float num = (localEulerAngles.y = y);
		Vector3 vector = (TransformReference.localEulerAngles = localEulerAngles);
	}

	public void setTrajectory()
	{
		Trajectory = TransformReference.rotation * Vector3.forward;
		Trajectory.Normalize();
	}

	public void speedBoost()
	{
	}

	public void Main()
	{
	}
}
