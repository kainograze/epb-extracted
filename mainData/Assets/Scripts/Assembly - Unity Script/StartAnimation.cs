// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// StartAnimation
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class StartAnimation : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class endIntroCam$79 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal StartAnimation $self_442;

			public $(StartAnimation self_)
			{
				$self_442 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					GameObject.Find("LevelControl").SendMessage("startLevel");
					return Yield(2, new WaitForSeconds(0.25f));
				case 2:
					Camera.main.SendMessage("enableFollow");
					UnityEngine.Object.Destroy($self_442.gameObject);
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal StartAnimation $self_443;

		public endIntroCam$79(StartAnimation self_)
		{
			$self_443 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_443);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class startIntroAnimation$80 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal StartAnimation $self_444;

			public $(StartAnimation self_)
			{
				$self_444 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					$self_444.Active = true;
					return Yield(2, new WaitForSeconds(1.5f));
				case 2:
					$self_444.RemoveAfterAnimation = true;
					$self_444.animation.Play("Intro");
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal StartAnimation $self_445;

		public startIntroAnimation$80(StartAnimation self_)
		{
			$self_445 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_445);
		}
	}

	private bool RemoveAfterAnimation;

	private bool Active;

	public void Start()
	{
	}

	public void Update()
	{
		if (Active)
		{
			if (RemoveAfterAnimation && !animation.isPlaying)
			{
				StartCoroutine_Auto(endIntroCam());
				RemoveAfterAnimation = false;
			}
			if (Input.GetKeyDown("space"))
			{
				StartCoroutine_Auto(endIntroCam());
			}
		}
	}

	private IEnumerator endIntroCam()
	{
		return new endIntroCam$79(this).GetEnumerator();
	}

	public IEnumerator startIntroAnimation()
	{
		return new startIntroAnimation$80(this).GetEnumerator();
	}

	public void Main()
	{
	}
}
