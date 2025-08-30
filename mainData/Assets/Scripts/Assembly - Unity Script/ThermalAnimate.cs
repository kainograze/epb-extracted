// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// ThermalAnimate
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class ThermalAnimate : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class animateThermal$46 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal ThermalAnimate $self_348;

			public $(ThermalAnimate self_)
			{
				$self_348 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				case 2:
					$self_348.offset += 0.1f * (0.25f * -1f);
					if ((bool)$self_348.RendererRef)
					{
						$self_348.RendererRef.material.mainTextureOffset = new Vector2(0f, $self_348.offset);
					}
					goto default;
				default:
					if (true)
					{
						return Yield(2, new WaitForSeconds(0.025f));
					}
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal ThermalAnimate $self_349;

		public animateThermal$46(ThermalAnimate self_)
		{
			$self_349 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_349);
		}
	}

	private float offset;

	private Renderer RendererRef;

	public void Start()
	{
		RendererRef = renderer;
		StartCoroutine("animateThermal");
	}

	public IEnumerator animateThermal()
	{
		return new animateThermal$46(this).GetEnumerator();
	}

	public void Main()
	{
	}
}
