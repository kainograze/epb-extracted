// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// CannonBallNotHoming
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class CannonBallNotHoming : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class activateCollision$40 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal CannonBallNotHoming $self_330;

			public $(CannonBallNotHoming self_)
			{
				$self_330 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					return Yield(2, new WaitForSeconds(0.2f));
				case 2:
					$self_330.CollisionCheck = true;
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal CannonBallNotHoming $self_331;

		public activateCollision$40(CannonBallNotHoming self_)
		{
			$self_331 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_331);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class updateCannon$41 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Vector3 $targetDir$332;

			internal RaycastHit $hit$333;

			internal Vector3 $RaycastFrom$334;

			internal CannonBallNotHoming $self_335;

			public $(CannonBallNotHoming self_)
			{
				$self_335 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					if (true)
					{
						if ((bool)$self_335.Target)
						{
							if (!$self_335.PlayedSound)
							{
								$self_335.DistanceCheckTimer -= Time.deltaTime;
								if ($self_335.DistanceCheckTimer < 0f)
								{
									$self_335.DistanceCheckTimer = $self_335.DistanceCheckInterval;
									if (($self_335.Target.transform.position - $self_335.transform.position).magnitude < 85f)
									{
										$self_335.audio.Play();
										$self_335.PlayedSound = true;
									}
									if ($self_335.Target.rigidbody.velocity.magnitude > 140f)
									{
										$self_335.LockOn = false;
										$self_335.IntervalTimer = 0f;
									}
								}
							}
							$self_335.LifeSpanTimer += Time.deltaTime;
							if ($self_335.LifeSpanTimer > $self_335.LifeSpanLimit)
							{
								$self_335.SendMessage("Hit");
							}
							if (!($self_335.IntervalTimer > 0f))
							{
								$self_335.IntervalTimer = 0f;
								$self_335.LockOn = false;
							}
							else
							{
								$self_335.IntervalTimer -= Time.deltaTime;
							}
							if ($self_335.LockOn)
							{
								$targetDir$332 = $self_335.Target.transform.position - $self_335.transform.position;
								$targetDir$332.Normalize();
								$self_335.Trajectory = $targetDir$332 * $self_335.Speed * Time.deltaTime * 105f;
							}
							$self_335.transform.position = $self_335.transform.position + $self_335.Trajectory;
						}
						else
						{
							$self_335.transform.position = $self_335.transform.position + $self_335.Trajectory;
						}
						if ($self_335.CollisionCheck)
						{
							$hit$333 = default(RaycastHit);
							$RaycastFrom$334 = $self_335.transform.position;
							$RaycastFrom$334 += $self_335.Trajectory * 5f;
							if (Physics.Raycast($RaycastFrom$334, $self_335.Trajectory, out $hit$333, 100f) && $hit$333.distance < 5f)
							{
								$self_335.SendMessage("Hit");
							}
						}
						return Yield(2, null);
					}
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal CannonBallNotHoming $self_336;

		public updateCannon$41(CannonBallNotHoming self_)
		{
			$self_336 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new $($self_336);
		}
	}

	public float Speed;

	public float Interval;

	public float LifeSpanLimit;

	public float DistanceCheckInterval;

	private float DistanceCheckTimer;

	private int AccuracyDivide;

	private float LifeSpanTimer;

	private float IntervalTimer;

	private bool LockOn;

	private GameObject Target;

	private Vector3 Trajectory;

	private bool PlayedSound;

	private bool HomingCannon;

	private bool CollisionCheck;

	public CannonBallNotHoming()
	{
		Speed = 4.6f;
		Interval = 1.8f;
		LifeSpanLimit = 5.5f;
		DistanceCheckInterval = 0.05f;
		HomingCannon = true;
	}

	public void Start()
	{
		gameObject.name = "CannonBall";
		IntervalTimer = Interval;
		float y = transform.eulerAngles.y + 190f;
		Vector3 eulerAngles = transform.eulerAngles;
		float num = (eulerAngles.y = y);
		Vector3 vector = (transform.eulerAngles = eulerAngles);
		DistanceCheckTimer = DistanceCheckInterval;
		StartCoroutine_Auto(activateCollision());
		StartCoroutine("updateCannon");
	}

	public IEnumerator activateCollision()
	{
		return new activateCollision$40(this).GetEnumerator();
	}

	public IEnumerator updateCannon()
	{
		return new updateCannon$41(this).GetEnumerator();
	}

	public void setTarget(object inTarget)
	{
		Target = (GameObject)RuntimeServices.Coerce(inTarget, typeof(GameObject));
		Vector3 vector = Target.transform.position - transform.position;
		if (HomingCannon)
		{
			setInterval(vector);
		}
		vector.Normalize();
		Trajectory = vector * Speed;
		LockOn = true;
	}

	public void setAccuracy(int inAccuracy)
	{
		AccuracyDivide = inAccuracy;
		if (inAccuracy > 999)
		{
			HomingCannon = false;
			Interval = 0f;
		}
	}

	public void setInterval(Vector3 inTargetDir)
	{
		Interval = inTargetDir.magnitude / (float)AccuracyDivide;
	}

	public void OnTriggerEnter(Collider Other)
	{
		if (Other.gameObject.name == "GlideController")
		{
			Other.SendMessage("Hit");
			SendMessage("Hit");
		}
		else
		{
			SendMessage("Hit");
		}
	}

	public void increaseAccuracy(float inAmount)
	{
		Interval += inAmount;
	}

	public void Main()
	{
	}
}
