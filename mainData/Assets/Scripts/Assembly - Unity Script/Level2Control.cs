// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Level2Control
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class Level2Control : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class endLevel$53 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Level2Control $self_372;

			public $(Level2Control self_)
			{
				$self_372 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					$self_372.StartJourney = false;
					$self_372.ReturnTrip = false;
					$self_372.Player.SetActiveRecursively(state: false);
					$self_372.ArrowMarker.BroadcastMessage("hideObject");
					$self_372.ScreenFade.SendMessage("setFadeIn");
					Camera.main.SendMessage("endLevelCam");
					return Yield(2, new WaitForSeconds(0.75f));
				case 2:
					$self_372.ScoreObject.SendMessage("levelComplete");
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal Level2Control $self_373;

		public endLevel$53(Level2Control self_)
		{
			$self_373 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_373);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class startLevel$54 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Level2Control $self_370;

			public $(Level2Control self_)
			{
				$self_370 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					$self_370.ScreenFade.SendMessage("setFadeIn");
					return Yield(2, new WaitForSeconds(0.5f));
				case 2:
					$self_370.GUIObject.BroadcastMessage("displayInstructions", (object)0);
					$self_370.StartJourney = true;
					$self_370.GUIObject.BroadcastMessage("newStage", Mathf.Round($self_370.StartJourneyTimer));
					$self_370.pauseTime();
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal Level2Control $self_371;

		public startLevel$54(Level2Control self_)
		{
			$self_371 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_371);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class playerKilled$55 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Level2Control $self_374;

			public $(Level2Control self_)
			{
				$self_374 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					return Yield(2, new WaitForSeconds(2f));
				case 2:
					$self_374.pauseTime();
					$self_374.PlayerKilled = true;
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal Level2Control $self_375;

		public playerKilled$55(Level2Control self_)
		{
			$self_375 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_375);
		}
	}

	private bool Spotted2D;

	private bool BattleIntro;

	private bool LevelDescription;

	private bool EscapeIntro;

	private bool ReturnTrip;

	private bool LandingIntro;

	private bool PlayerKilled;

	private bool Disabled2D;

	private bool TwoDEscaped;

	private GameObject Player;

	private GameObject GUIObject;

	private GameObject ScoreObject;

	private Transform ArrowMarker;

	private bool StartJourney;

	public float StartJourneyTimer;

	private GameObject TwoD;

	private GameObject LandingPad;

	private GameObject ScreenFade;

	public GUIStyle LargeComicText;

	public Level2Control()
	{
		StartJourneyTimer = 90f;
	}

	public void Start()
	{
		GUIObject = GameObject.Find("GameGUI");
		ScoreObject = GameObject.Find("Score");
		Player = GameObject.Find("GlideController");
		ScreenFade = GameObject.Find("WhiteFade");
		ArrowMarker = GameObject.Find("/Camera/angleArrow2").transform;
		Time.timeScale = 1f;
		Camera.main.SendMessage("disableFollow");
	}

	public void Update()
	{
		int num = default(int);
		if (!StartJourney)
		{
			return;
		}
		StartJourneyTimer -= Time.deltaTime;
		num = checked((int)Mathf.Round(StartJourneyTimer));
		GUIObject.BroadcastMessage("updateTime", num);
		if (StartJourneyTimer < 0f)
		{
			StartJourney = false;
			if (!Disabled2D)
			{
				pauseTime();
				TwoDEscaped = true;
			}
			else
			{
				StartCoroutine_Auto(endLevel());
				Camera.main.BroadcastMessage("thermalOff");
			}
		}
	}

	public void OnGUI()
	{
		if (TwoDEscaped)
		{
			GUI.Box(new Rect(10f, 60f, 300f, 90f), "2D has escaped!", LargeComicText);
			GUI.Button(new Rect(10f, 140f, 300f, 90f), "Press Space To Restart", LargeComicText);
			if (Input.GetKeyDown("space"))
			{
				restartTime();
				Application.LoadLevel(Application.loadedLevel);
			}
		}
		checked
		{
			if (LevelDescription)
			{
				GUI.Box(new Rect(10f, 35f, 400f, 200f), "    2D has escaped! \nTrack him down and stop him.\nCollect as many bonuses before\nyou return to the island", LargeComicText);
				GUI.Button(new Rect(Screen.width - 350, 140f, 300f, 30f), "Press Space To Continue", LargeComicText);
				if (!Input.GetKeyDown("space"))
				{
				}
			}
			if (Spotted2D)
			{
				GUI.Box(new Rect(unchecked(Screen.width / 2) - 100, 110f, 200f, 90f), "You've spotted 2D! \nPrevent him from escaping");
				GUI.Button(new Rect(10f, 140f, 200f, 30f), "Press Space To Continue");
				if (Input.GetKeyDown("space"))
				{
					restartTime();
					Spotted2D = false;
				}
			}
			if (EscapeIntro)
			{
				GUI.Box(new Rect(10f, 90f, 400f, 200f), "You stopped 2D!\nReturn to the island and land\non the giant cushion\nor explore the level\nand maximise your score", LargeComicText);
				GUI.Button(new Rect(Screen.width - 350, 140f, 300f, 30f), "Press Space To Continue", LargeComicText);
				if (Input.GetKeyDown("space"))
				{
					EscapeIntro = false;
					restartTime();
				}
			}
			if (PlayerKilled)
			{
				GUI.Box(new Rect(10f, 80f, 200f, 90f), "GAME OVER", LargeComicText);
				GUI.Button(new Rect(10f, 140f, 300f, 30f), "Press Space To Restart", LargeComicText);
				if (Input.GetKeyDown("space"))
				{
					restartTime();
					Application.LoadLevel(Application.loadedLevel);
				}
			}
		}
	}

	public IEnumerator startLevel()
	{
		return new startLevel$54(this).GetEnumerator();
	}

	public void endInstructions()
	{
		ArrowMarker.SendMessage("showArrow");
		restartTime();
		Spotted2D = false;
		LevelDescription = false;
		Player.SendMessage("restartGlider");
	}

	public void addTime(int AddTimeAmount)
	{
		if (StartJourney)
		{
			StartJourneyTimer += AddTimeAmount;
		}
	}

	public void outOfTime()
	{
	}

	public void twoDEscaped()
	{
	}

	public void found2D()
	{
	}

	public void spotted2D()
	{
	}

	public void battleWon()
	{
	}

	public IEnumerator endLevel()
	{
		return new endLevel$53(this).GetEnumerator();
	}

	public IEnumerator playerKilled()
	{
		return new playerKilled$55(this).GetEnumerator();
	}

	public void pauseTime()
	{
		if ((bool)Player && Player.active)
		{
			Player.BroadcastMessage("audioOff", 1);
		}
		Time.timeScale = 0f;
	}

	public void restartTime()
	{
		if ((bool)Player && Player.active)
		{
			Player.BroadcastMessage("audioOn", 1);
		}
		Time.timeScale = 1f;
	}

	public void Main()
	{
	}
}
