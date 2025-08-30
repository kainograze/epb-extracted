// d4e5115e396b84ea8820f5b0a8f12827, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// ZoomToTarget
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class ZoomToTarget : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class twoDLocated$3 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal ZoomToTarget $self_22;

			public $(ZoomToTarget self_)
			{
				$self_22 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					return Yield(2, new WaitForSeconds(0.75f));
				case 2:
					GameObject.Find("WhiteFade").SendMessage("setFadeIn");
					return Yield(3, new WaitForSeconds(0.25f));
				case 3:
					GameObject.Find("GlideController").SendMessage("setBattlePos");
					$self_22.SendMessage("enableFollow");
					$self_22.SendMessage("disableLookAt");
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal ZoomToTarget $self_23;

		public twoDLocated$3(ZoomToTarget self_)
		{
			$self_23 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_23);
		}
	}

	private Transform Target;

	public float PanSpeed;

	private Vector3 targetDir;

	private bool Active;

	public void Start()
	{
		Target = GameObject.Find("TwoD").transform;
	}

	public void Update()
	{
		if (Active)
		{
			targetDir = Target.position - transform.position;
			if (targetDir.magnitude < 155f)
			{
				GameObject.Find("LevelControl").SendMessage("spotted2D");
				Active = false;
				StartCoroutine_Auto(twoDLocated());
			}
			targetDir.Normalize();
			transform.position += targetDir * PanSpeed * Time.deltaTime * 145f;
		}
	}

	public void zoomToTarget()
	{
		Active = true;
		SendMessage("lookAt2D");
		SendMessage("disableFollow");
	}

	public IEnumerator twoDLocated()
	{
		return new twoDLocated$3(this).GetEnumerator();
	}

	public void Main()
	{
	}
}
