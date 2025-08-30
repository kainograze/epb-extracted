// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// OneShotAudioDelete
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class OneShotAudioDelete : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class Start$36 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal OneShotAudioDelete $self_320;

			public $(OneShotAudioDelete self_)
			{
				$self_320 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					return Yield(2, new WaitForSeconds($self_320.audio.clip.length));
				case 2:
					UnityEngine.Object.Destroy($self_320.gameObject);
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal OneShotAudioDelete $self_321;

		public Start$36(OneShotAudioDelete self_)
		{
			$self_321 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_321);
		}
	}

	public IEnumerator Start()
	{
		return new Start$36(this).GetEnumerator();
	}

	public void Main()
	{
	}
}
