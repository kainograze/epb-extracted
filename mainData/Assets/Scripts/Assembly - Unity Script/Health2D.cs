// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Health2D
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Health2D : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class playConversation$30 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int $RandomSound$305;

			internal Health2D $self_306;

			public $(Health2D self_)
			{
				$self_306 = self_;
			}

			public override bool MoveNext()
			{
				checked
				{
					switch (_state)
					{
					default:
						$self_306.ConversationCount++;
						if ($self_306.ConversationCount < 5)
						{
							$RandomSound$305 = UnityEngine.Random.Range(8, 19);
							$self_306.BroadcastMessage("audioOn", $RandomSound$305);
							return Yield(2, new WaitForSeconds(1.5f));
						}
						$self_306.BroadcastMessage("audioOn", 15);
						goto IL_00c1;
					case 2:
						$self_306.BroadcastMessage("audioOn", $RandomSound$305 + 1);
						goto IL_00c1;
					case 1:
						break;
						IL_00c1:
						Yield(1, null);
						break;
					}
					bool result = default(bool);
					return result;
				}
			}
		}

		internal Health2D $self_307;

		public playConversation$30(Health2D self_)
		{
			$self_307 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_307);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class startWhaley$31 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Health2D $self_308;

			public $(Health2D self_)
			{
				$self_308 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					UnityEngine.Object.Instantiate($self_308.Whale, $self_308.transform.position, Quaternion.identity);
					return Yield(2, new WaitForSeconds(1f));
				case 2:
					$self_308.BroadcastMessage("audioOn", 25);
					return Yield(3, new WaitForSeconds(2.05f));
				case 3:
					$self_308.BroadcastMessage("audioOn", 26);
					return Yield(4, new WaitForSeconds(2.25f));
				case 4:
					$self_308.BroadcastMessage("audioOn", 27);
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal Health2D $self_309;

		public startWhaley$31(Health2D self_)
		{
			$self_309 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_309);
		}
	}

	public Transform BoatExplosion;

	public float TotalHealth;

	private float Health;

	public Transform ExplodeAudio;

	public Transform Whale;

	private GameObject ScoreObject;

	private GameObject GUIHealth;

	private GameObject LevelControl;

	private float ConversationTimer;

	private float ConversationTime;

	private bool RecentlyShot;

	private int ConversationCount;

	public Health2D()
	{
		TotalHealth = 30f;
		ConversationTime = 5f;
	}

	public void Start()
	{
		Health = TotalHealth;
		GUIHealth = GameObject.Find("/GameGUI/GUIEnemyHealth");
		ScoreObject = GameObject.Find("Score");
		LevelControl = GameObject.Find("LevelControl");
	}

	public void Update()
	{
		if (ConversationTimer > 0f)
		{
			ConversationTimer -= Time.deltaTime;
		}
	}

	public void Hit()
	{
		if (Health > 0f)
		{
			Health -= 1f;
			if (Health > 1f && !(ConversationTimer > 0f))
			{
				ConversationTimer = ConversationTime;
				StartCoroutine_Auto(playConversation());
			}
			float num = Health / TotalHealth * 1f;
			GUIHealth.SendMessage("enemyHit", num);
			GUIHealth.SendMessage("receiveEnemyType", "2D");
			if (Health == 0f)
			{
				BroadcastMessage("allAudioOff");
				RuntimeServices.SetProperty(collider, "isTrigger", true);
				GameObject.Find("Score").SendMessage("sendScore", 9);
				RecentlyShot = false;
				ConversationTimer = 1f;
				BroadcastMessage("audioOn", 24);
				BroadcastMessage("audioOn", 6);
				LevelControl.SendMessage("battleWon");
				BroadcastMessage("vehicleSmashed");
				SendMessage("slowDown");
				SendMessage("disableIcon");
				UnityEngine.Object.Instantiate(ExplodeAudio, transform.position, Quaternion.identity);
				UnityEngine.Object.Instantiate(BoatExplosion, transform.position, Quaternion.identity);
			}
		}
	}

	public IEnumerator playConversation()
	{
		return new playConversation$30(this).GetEnumerator();
	}

	public IEnumerator startWhaley()
	{
		return new startWhaley$31(this).GetEnumerator();
	}

	public void Main()
	{
	}
}
