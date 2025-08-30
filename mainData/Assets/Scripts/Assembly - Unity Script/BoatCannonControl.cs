// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// BoatCannonControl
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class BoatCannonControl : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class fireCannons$39 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject $NewCannon$326;

			internal Vector3 $SpawnPos$327;

			internal BoatCannonControl $self_328;

			public $(BoatCannonControl self_)
			{
				$self_328 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					if (true)
					{
						if ((bool)$self_328.Target && !$self_328.Target.rigidbody.isKinematic && $self_328.Firing)
						{
							$self_328.ReloadTimer -= Time.deltaTime;
							if ($self_328.ReloadTimer < 0f && ($self_328.transform.position - $self_328.Target.transform.position).magnitude < 1500f)
							{
								$self_328.audio.Play();
								$self_328.ReloadTimer = $self_328.ReloadTime;
								$NewCannon$326 = null;
								$SpawnPos$327 = $self_328.transform.position;
								$SpawnPos$327.y += 25f;
								$NewCannon$326 = (GameObject)UnityEngine.Object.Instantiate($self_328.CannonBall.gameObject, $SpawnPos$327, Quaternion.identity);
								$NewCannon$326.SendMessage("setAccuracy", $self_328.Accuracy);
								($NewCannon$326.GetComponent("CannonBallNotHoming") as CannonBallNotHoming).setTarget($self_328.Target);
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

		internal BoatCannonControl $self_329;

		public fireCannons$39(BoatCannonControl self_)
		{
			$self_329 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new $($self_329);
		}
	}

	public float ReloadTime;

	public Transform CannonBall;

	public int Accuracy;

	public Transform ExplodeAudio;

	private bool Firing;

	private GameObject Target;

	private float ReloadTimer;

	public BoatCannonControl()
	{
		Accuracy = 560;
		Firing = true;
	}

	public void Start()
	{
		Target = GameObject.Find("GlideController");
		ReloadTimer = ReloadTime;
		StartCoroutine("fireCannons");
	}

	public IEnumerator fireCannons()
	{
		return new fireCannons$39(this).GetEnumerator();
	}

	public void setTarget(object inTarget)
	{
	}

	public void reduceReloadTime()
	{
	}

	public void increaseAccuracy()
	{
		bool flag = true;
	}

	public void delayShooting()
	{
		Firing = true;
	}

	public void stopFiring()
	{
		Firing = false;
	}

	public void Main()
	{
	}
}
