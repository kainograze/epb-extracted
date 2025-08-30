// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// SplashParticles
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class SplashParticles : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class splashParticles$28 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal SplashParticles $self_301;

			public $(SplashParticles self_)
			{
				$self_301 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					return Yield(2, new WaitForSeconds($self_301.DelayTime));
				case 2:
					$self_301.particleEmitter.emit = true;
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal SplashParticles $self_302;

		public splashParticles$28(SplashParticles self_)
		{
			$self_302 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_302);
		}
	}

	public float DelayTime;

	public SplashParticles()
	{
		DelayTime = 0.6f;
	}

	public void Start()
	{
	}

	public IEnumerator splashParticles()
	{
		return new splashParticles$28(this).GetEnumerator();
	}

	public void Main()
	{
	}
}
