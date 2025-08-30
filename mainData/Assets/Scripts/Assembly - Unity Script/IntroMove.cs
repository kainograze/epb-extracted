// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// IntroMove
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class IntroMove : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class introEscape$32 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal IntroMove $self_310;

			public $(IntroMove self_)
			{
				$self_310 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					return Yield(2, new WaitForSeconds(0.05f));
				case 2:
					$self_310.Active = true;
					if ($self_310.Active)
					{
						return Yield(3, new WaitForSeconds(0.3f));
					}
					goto IL_0154;
				case 3:
					if ($self_310.Active)
					{
						$self_310.BroadcastMessage("audioOn", 50);
						return Yield(4, new WaitForSeconds(2f));
					}
					goto IL_0154;
				case 4:
					if ($self_310.Active)
					{
						$self_310.SendMessage("enableMove");
						return Yield(5, new WaitForSeconds(1.2f));
					}
					goto IL_0154;
				case 5:
					if ($self_310.Active)
					{
						$self_310.BroadcastMessage("audioOn", 51);
						return Yield(6, new WaitForSeconds(3f));
					}
					goto IL_0154;
				case 6:
					if ($self_310.Active)
					{
						GameObject.Find("LevelControl").SendMessage("end2DEscapeIntro");
						$self_310.Active = false;
					}
					goto IL_0154;
				case 1:
					break;
					IL_0154:
					Yield(1, null);
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal IntroMove $self_311;

		public introEscape$32(IntroMove self_)
		{
			$self_311 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_311);
		}
	}

	private bool Active;

	public void Update()
	{
		if (Active && Input.GetKeyDown("space"))
		{
			GameObject.Find("LevelControl").SendMessage("end2DEscapeIntro");
			BroadcastMessage("allAudioOff");
			SendMessage("enableMove");
			Active = false;
		}
	}

	public IEnumerator introEscape()
	{
		return new introEscape$32(this).GetEnumerator();
	}

	public void Main()
	{
	}
}
