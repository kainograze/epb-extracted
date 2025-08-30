// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// BasicMove2D
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class BasicMove2D : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class escape$29 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal BasicMove2D $self_303;

			public $(BasicMove2D self_)
			{
				$self_303 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					$self_303.IncrementSpeed = 40f;
					return Yield(2, new WaitForSeconds(5f));
				case 2:
					$self_303.SendMessage("escapeHealth");
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal BasicMove2D $self_304;

		public escape$29(BasicMove2D self_)
		{
			$self_304 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_304);
		}
	}

	public float DistancePerSec;

	public float IncrementSpeed;

	public Vector3 Direction;

	private bool Move;

	public BasicMove2D()
	{
		DistancePerSec = 25f;
		Direction = Vector3.forward;
	}

	public void Start()
	{
		int num = 1;
	}

	public void Update()
	{
		if (Move)
		{
			Vector3 vector = Direction * (DistancePerSec * Time.deltaTime);
			transform.position += vector;
			DistancePerSec += IncrementSpeed * Time.deltaTime;
		}
	}

	public void shiftAlongPath()
	{
		transform.position += Direction * 400f;
	}

	public IEnumerator escape()
	{
		return new escape$29(this).GetEnumerator();
	}

	public void enableMove()
	{
		Move = true;
	}

	public void disableMove()
	{
		Move = false;
	}

	public void Main()
	{
	}
}
