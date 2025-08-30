// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// SpeedboatMove
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class SpeedboatMove : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class escape$35 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal SpeedboatMove $self_318;

			public $(SpeedboatMove self_)
			{
				$self_318 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					$self_318.IncrementSpeed = 350f;
					return Yield(2, new WaitForSeconds(5f));
				case 2:
					GameObject.Find("LevelControl").SendMessage("twoDEscaped");
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal SpeedboatMove $self_319;

		public escape$35(SpeedboatMove self_)
		{
			$self_319 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_319);
		}
	}

	public float DistancePerSec;

	public float IncrementSpeed;

	public Vector3 Direction;

	public int EscapeZPoint;

	public Transform[] Positions;

	private int CurrentPos;

	private float EscapeCheckTimer;

	private bool Escaping;

	private Vector3 Trajectory;

	private bool Move;

	public SpeedboatMove()
	{
		DistancePerSec = 25f;
		Direction = Vector3.forward;
	}

	public void Start()
	{
		updatePos();
	}

	public void FixedUpdate()
	{
		if (!Move)
		{
			return;
		}
		DistancePerSec += IncrementSpeed * Time.deltaTime;
		transform.position += Trajectory * DistancePerSec * Time.deltaTime;
		checked
		{
			if (CurrentPos < Extensions.get_length((System.Array)Positions) - 1)
			{
				Vector3 position = transform.position;
				Transform[] positions = Positions;
				if ((position - positions[RuntimeServices.NormalizeArrayIndex(positions, CurrentPos)].transform.position).magnitude < 20f)
				{
					CurrentPos++;
					updatePos();
				}
			}
		}
	}

	public void escapeCheck()
	{
		if (transform.position.z > (float)EscapeZPoint)
		{
			Escaping = true;
			GameObject.Find("LevelControl").SendMessage("twoDEscaping");
		}
	}

	public IEnumerator escape()
	{
		return new escape$35(this).GetEnumerator();
	}

	public void updatePos()
	{
		Transform[] positions = Positions;
		Trajectory = positions[RuntimeServices.NormalizeArrayIndex(positions, CurrentPos)].transform.position - transform.position;
		Trajectory.Normalize();
	}

	public void enableMove()
	{
		Move = true;
	}

	public void disableMove()
	{
		Move = false;
	}

	public void Main()
	{
	}
}
