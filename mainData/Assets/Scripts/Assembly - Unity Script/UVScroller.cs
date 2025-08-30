// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UVScroller
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class UVScroller : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class scrollUV$82 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal UVScroller $self_448;

			public $(UVScroller self_)
			{
				$self_448 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				case 2:
					$self_448.offset += $self_448.scrollSpeed * $self_448.scrollSpeed;
					$self_448.renderer.material.SetTextureOffset("_BumpMap", new Vector2($self_448.offset / (7f * -1f), $self_448.offset));
					$self_448.renderer.material.SetTextureOffset("_MainTex", new Vector2($self_448.offset / 10f, $self_448.offset));
					return Yield(3, null);
				default:
					if (true)
					{
						return Yield(2, new WaitForSeconds($self_448.scrollSpeed));
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

		internal UVScroller $self_449;

		public scrollUV$82(UVScroller self_)
		{
			$self_449 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_449);
		}
	}

	public float scrollSpeed;

	private Renderer RendererRef;

	private float offset;

	public UVScroller()
	{
		scrollSpeed = 0.05f;
	}

	public void Start()
	{
		StartCoroutine("scrollUV");
	}

	public IEnumerator scrollUV()
	{
		return new scrollUV$82(this).GetEnumerator();
	}

	public void Main()
	{
	}
}
