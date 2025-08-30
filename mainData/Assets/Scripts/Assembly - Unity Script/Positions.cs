// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Positions
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class Positions : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class setBattlePos$76 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int $___temp283$424;

			internal Vector3 $___temp284$425;

			internal Positions $self_426;

			public $(Positions self_)
			{
				$self_426 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					return Yield(2, new WaitForSeconds(0.5f));
				case 2:
				{
					GameObject.Find("LevelControl").SendMessage("battleIntro");
					int num = ($___temp283$424 = 150);
					Vector3 vector = ($___temp284$425 = $self_426.constantForce.relativeForce);
					float num2 = ($___temp284$425.z = $___temp283$424);
					Vector3 vector2 = ($self_426.constantForce.relativeForce = $___temp284$425);
					Yield(1, null);
					break;
				}
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal Positions $self_427;

		public setBattlePos$76(Positions self_)
		{
			$self_427 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_427);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class restartGlider$77 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int $___temp295$438;

			internal Vector3 $___temp296$439;

			internal Positions $self_440;

			public $(Positions self_)
			{
				$self_440 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					$self_440.BroadcastMessage("gunsOff");
					$self_440.BroadcastMessage("stopShooting");
					$self_440.audio.Stop();
					return Yield(2, new WaitForSeconds(0.5f));
				case 2:
				{
					$self_440.rigidbody.isKinematic = false;
					int num = ($___temp295$438 = 150);
					Vector3 vector = ($___temp296$439 = $self_440.constantForce.relativeForce);
					float num2 = ($___temp296$439.z = $___temp295$438);
					Vector3 vector2 = ($self_440.constantForce.relativeForce = $___temp296$439);
					Yield(1, null);
					break;
				}
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal Positions $self_441;

		public restartGlider$77(Positions self_)
		{
			$self_441 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_441);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class resetGlider$78 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float $ShortestDistance$428;

			internal int $ShortestDistanceArrayPos$429;

			internal int $i$430;

			internal float $Distance$431;

			internal int $___temp291$432;

			internal Vector3 $___temp292$433;

			internal int $___temp293$434;

			internal Vector3 $___temp294$435;

			internal Positions $self_436;

			public $(Positions self_)
			{
				$self_436 = self_;
			}

			public override bool MoveNext()
			{
				checked
				{
					switch (_state)
					{
					default:
						return Yield(2, new WaitForSeconds(0.25f));
					case 2:
					{
						$ShortestDistance$428 = 100000f;
						$ShortestDistanceArrayPos$429 = default(int);
						for ($i$430 = 0; $i$430 < Extensions.get_length((System.Array)$self_436.RespawnPoints); $i$430++)
						{
							$Distance$431 = default(float);
							Vector3 position = $self_436.transform.position;
							Transform[] respawnPoints = $self_436.RespawnPoints;
							$Distance$431 = (position - respawnPoints[RuntimeServices.NormalizeArrayIndex(respawnPoints, $i$430)].position).magnitude;
							if ($Distance$431 < $ShortestDistance$428)
							{
								$ShortestDistance$428 = $Distance$431;
								$ShortestDistanceArrayPos$429 = $i$430;
							}
						}
						$self_436.rigidbody.isKinematic = true;
						Transform transform = $self_436.transform;
						Transform[] respawnPoints2 = $self_436.RespawnPoints;
						transform.position = respawnPoints2[RuntimeServices.NormalizeArrayIndex(respawnPoints2, $ShortestDistanceArrayPos$429)].position;
						$self_436.transform.eulerAngles = $self_436.ResetRotation;
						int num = ($___temp291$432 = 0);
						Vector3 vector = ($___temp292$433 = $self_436.transform.eulerAngles);
						float num2 = ($___temp292$433.x = $___temp291$432);
						Vector3 vector2 = ($self_436.transform.eulerAngles = $___temp292$433);
						int num3 = ($___temp293$434 = 0);
						Vector3 vector4 = ($___temp294$435 = $self_436.transform.eulerAngles);
						float num4 = ($___temp294$435.z = $___temp293$434);
						Vector3 vector5 = ($self_436.transform.eulerAngles = $___temp294$435);
						$self_436.SendMessage("makeInvincible");
						$self_436.StartCoroutine_Auto($self_436.restartGlider());
						Yield(1, null);
						break;
					}
					case 1:
						break;
					}
					bool result = default(bool);
					return result;
				}
			}
		}

		internal Positions $self_437;

		public resetGlider$78(Positions self_)
		{
			$self_437 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_437);
		}
	}

	public Vector3 BattlePos;

	public Quaternion BattleRot;

	public Vector3 ReturnLegPos;

	public Quaternion ReturnLegRot;

	private Vector3 RestartPos;

	private Quaternion StartRot;

	private Vector3 ResetRotation;

	public Transform[] RespawnPoints;

	public void Update()
	{
	}

	public void Start()
	{
		RestartPos = transform.position;
		StartRot = transform.rotation;
	}

	public IEnumerator setBattlePos()
	{
		return new setBattlePos$76(this).GetEnumerator();
	}

	public void setEscapePos()
	{
		int num = 180;
		Vector3 eulerAngles = transform.eulerAngles;
		float num2 = (eulerAngles.y = num);
		Vector3 vector = (transform.eulerAngles = eulerAngles);
		transform.position = ReturnLegPos;
		RestartPos = ReturnLegPos;
		StartRot = transform.rotation;
		int num3 = 150;
		Vector3 relativeForce = constantForce.relativeForce;
		float num4 = (relativeForce.z = num3);
		Vector3 vector3 = (constantForce.relativeForce = relativeForce);
		SendMessage("makeInvincible");
	}

	public void setEscapeRot()
	{
		StartRot = Quaternion.identity;
		int num = 180;
		Vector3 eulerAngles = StartRot.eulerAngles;
		float num2 = (eulerAngles.y = num);
		Vector3 vector = (StartRot.eulerAngles = eulerAngles);
	}

	public IEnumerator resetGlider()
	{
		return new resetGlider$78(this).GetEnumerator();
	}

	public void nearestRespawn()
	{
		float num = 100000f;
		int index = default(int);
		for (int i = 0; i < Extensions.get_length((System.Array)RespawnPoints); i = checked(i + 1))
		{
			float num2 = default(float);
			Vector3 position = transform.position;
			Transform[] respawnPoints = RespawnPoints;
			num2 = (position - respawnPoints[RuntimeServices.NormalizeArrayIndex(respawnPoints, i)].position).magnitude;
			if (num2 < num)
			{
				num = num2;
				index = i;
			}
		}
		rigidbody.isKinematic = true;
		Transform obj = transform;
		Transform[] respawnPoints2 = RespawnPoints;
		obj.position = respawnPoints2[RuntimeServices.NormalizeArrayIndex(respawnPoints2, index)].position;
	}

	public IEnumerator restartGlider()
	{
		return new restartGlider$77(this).GetEnumerator();
	}

	public void recordRotation()
	{
		ResetRotation = transform.eulerAngles;
		ResetRotation.x = 0f;
		ResetRotation.y = 0f;
	}

	public void Main()
	{
	}
}
