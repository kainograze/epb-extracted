// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Mine
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class Mine : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class Explode$38 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Mine $self_324;

			public $(Mine self_)
			{
				$self_324 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					if (!$self_324.Exploded)
					{
						if ((bool)$self_324.TargetHit && $self_324.AltitudeCheck)
						{
							$self_324.TargetHit.SendMessage("destroyHit");
						}
						$self_324.BroadcastMessage("hideObject");
						$self_324.Exploded = true;
						UnityEngine.Object.Instantiate($self_324.MineWaterExplodeAudio, $self_324.transform.position, Quaternion.identity);
						UnityEngine.Object.Instantiate($self_324.Explosion, $self_324.transform.position, Quaternion.identity);
						$self_324.transform.parent.SendMessage("mineHit");
						return Yield(2, new WaitForSeconds(0.15f));
					}
					goto IL_0114;
				case 2:
					$self_324.transform.parent.SendMessage("removeParent");
					goto IL_0114;
				case 1:
					break;
					IL_0114:
					Yield(1, null);
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal Mine $self_325;

		public Explode$38(Mine self_)
		{
			$self_325 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_325);
		}
	}

	public bool AltitudeCheck;

	public Transform Explosion;

	public int SeaLevel;

	public int FlightSpeed;

	public GameObject TargetHit;

	public Transform MineWaterExplodeAudio;

	private bool LockOn;

	private GameObject Target;

	private GameObject ScoreObject;

	private bool Exploded;

	public Mine()
	{
		SeaLevel = -32;
	}

	public void Start()
	{
		Target = GameObject.Find("GlideController");
		ScoreObject = GameObject.Find("Score");
	}

	public void Update()
	{
		if (AltitudeCheck && transform.position.y < (float)SeaLevel)
		{
			StartCoroutine_Auto(Explode());
		}
	}

	public void altitudeCheck()
	{
		AltitudeCheck = true;
		BroadcastMessage("destroyDetector");
	}

	public IEnumerator Explode()
	{
		return new Explode$38(this).GetEnumerator();
	}

	public void Main()
	{
	}
}
