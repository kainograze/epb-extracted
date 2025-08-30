// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// TakeOffSounds
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class TakeOffSounds : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class startIntroAnimation$81 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal TakeOffSounds $self_446;

			public $(TakeOffSounds self_)
			{
				$self_446 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					return Yield(2, new WaitForSeconds(1.25f));
				case 2:
					$self_446.BroadcastMessage("audioOn", 60);
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal TakeOffSounds $self_447;

		public startIntroAnimation$81(TakeOffSounds self_)
		{
			$self_447 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_447);
		}
	}

	public IEnumerator startIntroAnimation()
	{
		return new startIntroAnimation$81(this).GetEnumerator();
	}

	public void endIntroCam()
	{
		BroadcastMessage("allAudioOff");
	}

	public void Main()
	{
	}
}
