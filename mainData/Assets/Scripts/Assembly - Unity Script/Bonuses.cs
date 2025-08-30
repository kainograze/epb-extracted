// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Bonuses
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Bonuses : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class alignGUI$43 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float $___temp119$340;

			internal Rect $___temp120$341;

			internal Bonuses $self_342;

			public $(Bonuses self_)
			{
				$self_342 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					return Yield(2, new WaitForSeconds(0.01f));
				case 2:
				{
					float num = ($___temp119$340 = $self_342.guiTexture.pixelInset.y - 5f);
					Rect rect = ($___temp120$341 = $self_342.guiTexture.pixelInset);
					float num2 = ($___temp120$341.y = $___temp119$340);
					Rect rect2 = ($self_342.guiTexture.pixelInset = $___temp120$341);
					$self_342.CurrentPixelInset = $self_342.guiTexture.pixelInset;
					$self_342.CurrentPixelInset.x = $self_342.CurrentPixelInset.x - $self_342.GUIWidth * (float)$self_342.BonusPosition;
					$self_342.guiTexture.pixelInset = new Rect($self_342.CurrentPixelInset);
					Yield(1, null);
					break;
				}
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal Bonuses $self_343;

		public alignGUI$43(Bonuses self_)
		{
			$self_343 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_343);
		}
	}

	private float GUIWidth;

	private Rect CurrentPixelInset;

	public int BonusPosition;

	public void Start()
	{
		GUIWidth = guiTexture.pixelInset.width - 9f;
		StartCoroutine_Auto(alignGUI());
	}

	public IEnumerator alignGUI()
	{
		return new alignGUI$43(this).GetEnumerator();
	}

	public void bonusOn(object inID)
	{
		if (RuntimeServices.EqualityOperator(inID, BonusPosition))
		{
			int num = 1;
			Color color = guiTexture.color;
			float num2 = (color.a = num);
			Color color2 = (guiTexture.color = color);
		}
	}

	public void bonusesOff()
	{
		guiTexture.enabled = false;
	}

	public void bonusesOn()
	{
		guiTexture.enabled = true;
	}

	public void Main()
	{
	}
}
