// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// BonusController
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class BonusController : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class enableIntro$44 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal BonusController $self_344;

			public $(BonusController self_)
			{
				$self_344 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					return Yield(2, new WaitForSeconds(0.5f));
				case 2:
					$self_344.DisplayLevelIntroduction = true;
					Time.timeScale = 0f;
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal BonusController $self_345;

		public enableIntro$44(BonusController self_)
		{
			$self_345 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_345);
		}
	}

	public int TotalRubbish;

	private int RubbishCollected;

	private bool DisplayVictory;

	private bool DisplayLevelIntroduction;

	public void Start()
	{
		StartCoroutine_Auto(enableIntro());
	}

	public void Update()
	{
	}

	public void OnGUI()
	{
		GUI.Box(new Rect(10f, 10f, 140f, 30f), "Rubbish Collected " + RubbishCollected + "/" + TotalRubbish);
		if (DisplayLevelIntroduction)
		{
			GUI.Box(new Rect(10f, 50f, 200f, 60f), "Collect the 4 pieces of rubbish\nscattered round the island\n(Marked by gold markers)");
			GUI.Button(new Rect(10f, 140f, 200f, 30f), "Press Space To Continue");
			if (Input.GetKeyDown("space"))
			{
				DisplayLevelIntroduction = false;
				Time.timeScale = 1f;
			}
		}
		checked
		{
			if (DisplayVictory)
			{
				GUI.Box(new Rect(unchecked(Screen.width / 2) - 150, unchecked(Screen.height / 2) - 70, 300f, 30f), "Bonus Level Complete");
				if (GUI.Button(new Rect(unchecked(Screen.width / 2) - 50, unchecked(Screen.height / 2) + 60, 100f, 30f), "Menu"))
				{
					Time.timeScale = 1f;
					Application.LoadLevel(0);
				}
			}
		}
	}

	public void rubbishCollected()
	{
		checked
		{
			RubbishCollected++;
			if (RubbishCollected == TotalRubbish)
			{
				DisplayVictory = true;
				Time.timeScale = 0f;
			}
		}
	}

	public IEnumerator enableIntro()
	{
		return new enableIntro$44(this).GetEnumerator();
	}

	public void Main()
	{
	}
}
