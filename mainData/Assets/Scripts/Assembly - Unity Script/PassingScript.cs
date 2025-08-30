// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// PassingScript
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class PassingScript : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class vehicleSmashed$34 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal PassingScript $self_316;

			public $(PassingScript self_)
			{
				$self_316 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					$self_316.BroadcastMessage("makeBlack");
					if ($self_316.StopAnimation && typeof(UnityEngine.Animation) != null)
					{
						$self_316.animation.Stop();
					}
					return Yield(2, new WaitForSeconds(5f));
				case 2:
					$self_316.BroadcastMessage("turnOn");
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal PassingScript $self_317;

		public vehicleSmashed$34(PassingScript self_)
		{
			$self_317 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_317);
		}
	}

	public bool StopAnimation;

	public void Update()
	{
	}

	public IEnumerator vehicleSmashed()
	{
		return new vehicleSmashed$34(this).GetEnumerator();
	}

	public void Main()
	{
	}
}
