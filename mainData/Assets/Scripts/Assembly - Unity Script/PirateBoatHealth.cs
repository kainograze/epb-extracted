// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// PirateBoatHealth
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class PirateBoatHealth : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class destroyHit$42 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Vector3 $PositionBelowWater$337;

			internal PirateBoatHealth $self_338;

			public $(PirateBoatHealth self_)
			{
				$self_338 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					$self_338.SendMessage("stopFiring");
					$self_338.Health = 0f;
					UnityEngine.Object.Instantiate($self_338.ExplodeAudio, $self_338.transform.position, Quaternion.identity);
					UnityEngine.Object.Instantiate($self_338.BoatExplosion, $self_338.transform.position, Quaternion.identity);
					$self_338.BroadcastMessage("turnOn");
					$self_338.ScoreObject.SendMessage("sendScore", 2);
					return Yield(2, new WaitForSeconds(1f));
				case 2:
					$self_338.BroadcastMessage("sinkFire");
					$self_338.animation.Play("sink");
					return Yield(3, new WaitForSeconds(5f));
				case 3:
					$PositionBelowWater$337 = $self_338.transform.position;
					$PositionBelowWater$337.y -= 175f;
					UnityEngine.Object.Instantiate($self_338.BoatExplosion, $PositionBelowWater$337, Quaternion.identity);
					UnityEngine.Object.Destroy($self_338.gameObject);
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal PirateBoatHealth $self_339;

		public destroyHit$42(PirateBoatHealth self_)
		{
			$self_339 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_339);
		}
	}

	public Transform BoatExplosion;

	public float TotalHealth;

	private float Health;

	public Transform ExplodeAudio;

	private bool Sinking;

	private GameObject ScoreObject;

	private GameObject GUIHealth;

	public PirateBoatHealth()
	{
		TotalHealth = 30f;
	}

	public void Start()
	{
		Health = TotalHealth;
		GUIHealth = GameObject.Find("/GameGUI/GUIEnemyHealth");
		ScoreObject = GameObject.Find("Score");
	}

	public void Hit()
	{
		if (Health > 0f)
		{
			Health -= 1f;
			float num = Health / TotalHealth * 1f;
			GUIHealth.SendMessage("enemyHit", num);
			GUIHealth.SendMessage("receiveEnemyType", gameObject.name);
			if (Health == 0f)
			{
				StartCoroutine_Auto(destroyHit());
			}
		}
	}

	public IEnumerator destroyHit()
	{
		return new destroyHit$42(this).GetEnumerator();
	}

	public void Main()
	{
	}
}
