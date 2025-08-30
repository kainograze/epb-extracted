// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Collisions
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Collisions : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class waterCollision$69 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Collisions $self_402;

			public $(Collisions self_)
			{
				$self_402 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					$self_402.BroadcastMessage("audioOn", 2);
					$self_402.SendMessage("Hit");
					return Yield(2, new WaitForSeconds(0.05f));
				case 2:
					$self_402.SendMessage("resetGlider");
					GameObject.Find("WhiteFade").SendMessage("setFadeIn");
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal Collisions $self_403;

		public waterCollision$69(Collisions self_)
		{
			$self_403 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_403);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class OnTriggerEnter$70 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int $BonusCollected$404;

			internal string $BonusName$405;

			internal Collider $Hit406;

			internal Collisions $self_407;

			public $(Collider Hit, Collisions self_)
			{
				$Hit406 = Hit;
				$self_407 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					if ($Hit406.gameObject.name == "SlalomRing")
					{
						$self_407.LevelControl.SendMessage("addTime", 5);
						$self_407.ScoreObject.SendMessage("sendScore", 4);
						$Hit406.SendMessage("destroy");
					}
					else if (!($Hit406.gameObject.name == "SpeedRing"))
					{
						if ($Hit406.gameObject.name == "Doll")
						{
							$self_407.BroadcastMessage("audioOn", 4);
							$self_407.ScoreObject.SendMessage("sendScore", 8);
							UnityEngine.Object.Destroy($Hit406.gameObject);
						}
						else if ($Hit406.gameObject.name == "Time")
						{
							$self_407.ScoreObject.SendMessage("sendScore", 5);
							$self_407.LevelControl.SendMessage("addTime", 30);
							UnityEngine.Object.Destroy($Hit406.gameObject);
						}
						else if ($Hit406.gameObject.name == "Health")
						{
							$self_407.ScoreObject.SendMessage("sendScore", 7);
							$self_407.SendMessage("healthCollected");
							UnityEngine.Object.Destroy($Hit406.gameObject);
						}
						else if ($Hit406.gameObject.name == "ViewingPoint")
						{
							GameObject.Find("LevelControl").SendMessage("found2D");
							UnityEngine.Object.Destroy($Hit406.gameObject);
						}
						else if ($Hit406.gameObject.name == "MineDetector")
						{
							$self_407.SendMessage("Hit");
						}
						else if ($Hit406.gameObject.name == "Balloon")
						{
							$self_407.SendMessage("Hit");
						}
						else
						{
							if ($Hit406.gameObject.name == "Border")
							{
								$self_407.SendMessage("recordRotation");
								return Yield(2, new WaitForSeconds(0.05f));
							}
							if ($Hit406.gameObject.tag == "Bonus")
							{
								$self_407.BroadcastMessage("audioOn", 7);
								$BonusCollected$404 = default(int);
								$BonusName$405 = $Hit406.gameObject.name;
								if ($BonusName$405 == "BonusB")
								{
									$BonusCollected$404 = 4;
								}
								else if ($BonusName$405 == "BonusO")
								{
									$BonusCollected$404 = 3;
								}
								else if ($BonusName$405 == "BonusN")
								{
									$BonusCollected$404 = 2;
								}
								else if ($BonusName$405 == "BonusU")
								{
									$BonusCollected$404 = 1;
								}
								else if ($BonusName$405 == "BonusS")
								{
									$BonusCollected$404 = 0;
								}
								$self_407.SendMessage("bonusCollected", $BonusCollected$404);
								UnityEngine.Object.Destroy($Hit406.gameObject);
								$self_407.ScoreObject.SendMessage("sendScore", 10);
							}
						}
					}
					goto IL_0437;
				case 2:
					$self_407.SendMessage("resetGlider");
					GameObject.Find("WhiteFade").SendMessage("setFadeIn");
					goto IL_0437;
				case 1:
					break;
					IL_0437:
					Yield(1, null);
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal Collider $Hit408;

		internal Collisions $self_409;

		public OnTriggerEnter$70(Collider Hit, Collisions self_)
		{
			$Hit408 = Hit;
			$self_409 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($Hit408, $self_409);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class OnCollisionEnter$71 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Collision $Hit410;

			internal Collisions $self_411;

			public $(Collision Hit, Collisions self_)
			{
				$Hit410 = Hit;
				$self_411 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					if (!$self_411.EndLevel)
					{
						if (RuntimeServices.EqualityOperator(RuntimeServices.GetProperty($Hit410.gameObject, "name"), "LandingPad"))
						{
							$self_411.ScoreObject.SendMessage("sendScore", 11);
							GameObject.Find("LevelControl").SendMessage("endLevel");
							$self_411.EndLevel = true;
						}
						else
						{
							$self_411.SendMessage("recordRotation");
							if (!RuntimeServices.EqualityOperator(RuntimeServices.GetProperty($Hit410.gameObject, "name"), "WaterBottomLayer"))
							{
								$self_411.SendMessage("Hit");
								return Yield(2, new WaitForSeconds(0.05f));
							}
							$self_411.StartCoroutine_Auto($self_411.waterCollision());
						}
					}
					goto IL_012a;
				case 2:
					$self_411.SendMessage("resetGlider");
					GameObject.Find("WhiteFade").SendMessage("setFadeIn");
					goto IL_012a;
				case 1:
					break;
					IL_012a:
					Yield(1, null);
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal Collision $Hit412;

		internal Collisions $self_413;

		public OnCollisionEnter$71(Collision Hit, Collisions self_)
		{
			$Hit412 = Hit;
			$self_413 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($Hit412, $self_413);
		}
	}

	public Transform Splash;

	private bool EndLevel;

	private GameObject LevelControl;

	private GameObject ScoreObject;

	public void Start()
	{
		ScoreObject = GameObject.Find("Score");
		LevelControl = GameObject.Find("LevelControl");
	}

	public void Update()
	{
		if (transform.position.y < -34f)
		{
			SendMessage("recordRotation");
			StartCoroutine_Auto(waterCollision());
		}
	}

	public IEnumerator waterCollision()
	{
		return new waterCollision$69(this).GetEnumerator();
	}

	public IEnumerator OnTriggerEnter(Collider Hit)
	{
		return new OnTriggerEnter$70(Hit, this).GetEnumerator();
	}

	public IEnumerator OnCollisionEnter(Collision Hit)
	{
		return new OnCollisionEnter$71(Hit, this).GetEnumerator();
	}

	public void Main()
	{
	}
}
