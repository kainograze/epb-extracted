// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Level1Control
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class Level1Control : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class end2DEscapeIntro$48 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Level1Control $self_360;

			public $(Level1Control self_)
			{
				$self_360 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					$self_360.ScreenFade.SendMessage("setFadeIn");
					return Yield(2, new WaitForSeconds(0.25f));
				case 2:
					Camera.main.BroadcastMessage("introZoom");
					GameObject.Find("TakeOff").BroadcastMessage("startIntroAnimation");
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal Level1Control $self_361;

		public end2DEscapeIntro$48(Level1Control self_)
		{
			$self_361 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_361);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class endLevel$49 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Level1Control $self_366;

			public $(Level1Control self_)
			{
				$self_366 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					if ($self_366.BonusLevel)
					{
						$self_366.ScoreObject.SendMessage("timeLeftBonus", $self_366.StartJourneyTimer);
					}
					$self_366.GUIObject.SendMessage("cutSceneOn");
					$self_366.GUIObject.SendMessage("childGUIOff");
					$self_366.StartJourney = false;
					$self_366.ReturnTrip = false;
					if ((bool)$self_366.PirateBoats)
					{
						$self_366.PirateBoats.SetActiveRecursively(state: false);
					}
					$self_366.Player.SetActiveRecursively(state: false);
					$self_366.ArrowMarker.BroadcastMessage("hideObject");
					$self_366.ScreenFade.SendMessage("setFadeIn");
					Camera.main.SendMessage("endLevelCam");
					return Yield(2, new WaitForSeconds(2.2f));
				case 2:
					if (!$self_366.Final2DLevel)
					{
						$self_366.ScoreObject.SendMessage("levelComplete");
					}
					else
					{
						GameObject.Find("FinalCut").SendMessage("turnOn");
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

		internal Level1Control $self_367;

		public endLevel$49(Level1Control self_)
		{
			$self_367 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_367);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class startLevel$50 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Level1Control $self_362;

			public $(Level1Control self_)
			{
				$self_362 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					$self_362.TwoD.SendMessage("shiftToStart");
					$self_362.GUIObject.SendMessage("cutSceneOff");
					$self_362.ScreenFade.SendMessage("setFadeIn");
					return Yield(2, new WaitForSeconds(0.75f));
				case 2:
					$self_362.GUIObject.BroadcastMessage("displayInstructions", 1);
					$self_362.StartJourney = true;
					$self_362.GUIObject.BroadcastMessage("newStage", Mathf.Round($self_362.StartJourneyTimer));
					$self_362.TwoD.SendMessage("enableMove");
					$self_362.pauseTime();
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal Level1Control $self_363;

		public startLevel$50(Level1Control self_)
		{
			$self_363 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_363);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class battleWon$51 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Level1Control $self_364;

			public $(Level1Control self_)
			{
				$self_364 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					$self_364.StartJourneyTimer += 30f;
					$self_364.Disabled2D = true;
					$self_364.GUIObject.SendMessage("childGUIOff");
					return Yield(2, new WaitForSeconds(4f));
				case 2:
					$self_364.ScreenFade.SendMessage("setFadeIn");
					$self_364.StartJourney = false;
					return Yield(3, new WaitForSeconds(0.12f));
				case 3:
					$self_364.LandingPad.SetActiveRecursively(state: true);
					UnityRuntimeServices.Invoke($self_364.ArrowMarker.GetComponent("ArrowMarker"), "changeTarget", new object[1] { $self_364.LandingPad.transform }, typeof(MonoBehaviour));
					Camera.main.SendMessage("haveALookAt2D");
					$self_364.GUIObject.SendMessage("cutSceneOn");
					$self_364.TwoD.SendMessage("safelyReposition");
					$self_364.TwoD.SendMessage("startWhaley");
					$self_364.Player.SendMessage("recordRotation");
					$self_364.Player.SendMessage("nearestRespawn");
					$self_364.Player.SendMessage("turnControlOff");
					return Yield(4, new WaitForSeconds(6f));
				case 4:
					Camera.main.SendMessage("stopHavinALook");
					$self_364.GUIObject.SendMessage("cutSceneOff");
					$self_364.ScreenFade.SendMessage("setFadeIn");
					return Yield(5, new WaitForSeconds(0.75f));
				case 5:
					$self_364.GUIObject.BroadcastMessage("displayInstructions", 2);
					$self_364.pauseTime();
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal Level1Control $self_365;

		public battleWon$51(Level1Control self_)
		{
			$self_365 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_365);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class playerKilled$52 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Level1Control $self_368;

			public $(Level1Control self_)
			{
				$self_368 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					if (!$self_368.FinalBonusLevel)
					{
						$self_368.ArrowMarker.BroadcastMessage("hideObject");
						$self_368.StartJourney = false;
						return Yield(2, new WaitForSeconds(1.5f));
					}
					$self_368.StartCoroutine_Auto($self_368.endLevel());
					goto IL_0113;
				case 2:
					$self_368.GUIObject.SendMessage("cutSceneOn");
					$self_368.GUIObject.SendMessage("childGUIOff");
					$self_368.GUIObject.SendMessage("displayMessage", "You Died!");
					$self_368.ScoreObject.SendMessage("failedLevel");
					if ((bool)$self_368.PirateBoats && $self_368.PirateBoats.active)
					{
						$self_368.PirateBoats.BroadcastMessage("stopFiring");
					}
					goto IL_0113;
				case 1:
					break;
					IL_0113:
					Yield(1, null);
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal Level1Control $self_369;

		public playerKilled$52(Level1Control self_)
		{
			$self_369 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_369);
		}
	}

	public bool BonusLevel;

	public bool Final2DLevel;

	public bool FinalBonusLevel;

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

	private GameObject PirateBoats;

	private GameObject Mines;

	private Transform ArrowMarker;

	private bool StartJourney;

	public float StartJourneyTimer;

	private GameObject TwoD;

	private GameObject LandingPad;

	private GameObject ScreenFade;

	public GUIStyle LargeComicText;

	public Level1Control()
	{
		StartJourneyTimer = 90f;
	}

	public void Start()
	{
		GUIObject = GameObject.Find("GameGUI");
		ScoreObject = GameObject.Find("Score");
		Player = GameObject.Find("GlideController");
		PirateBoats = GameObject.Find("PirateBoats");
		ScreenFade = GameObject.Find("WhiteFade");
		TwoD = GameObject.Find("TwoD");
		ArrowMarker = GameObject.Find("/Camera/angleArrow2").transform;
		if (!BonusLevel)
		{
			LandingPad = GameObject.Find("LandingPad");
			if ((bool)LandingPad)
			{
				LandingPad.SetActiveRecursively(state: false);
			}
			GUIObject.BroadcastMessage("cutSceneActive");
		}
		if (BonusLevel)
		{
			StartCoroutine_Auto(end2DEscapeIntro());
		}
		Player.SendMessage("turnControlOff");
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
		if (!(StartJourneyTimer < 0f))
		{
			return;
		}
		if (!BonusLevel)
		{
			StartJourney = false;
			if (!Disabled2D)
			{
				twoDEscaped();
				return;
			}
			StartCoroutine_Auto(endLevel());
			Camera.main.BroadcastMessage("thermalOff");
		}
		else
		{
			bonusTimeOut();
			StartJourney = false;
		}
	}

	public void OnGUI()
	{
		if (TwoDEscaped && Input.GetKeyDown("space"))
		{
			restartTime();
			Application.LoadLevel(Application.loadedLevel);
		}
		checked
		{
			if (LevelDescription)
			{
				GUI.Box(new Rect(10f, 35f, 400f, 200f), "    2D has escaped the island! \nTrack him down and stop him.\nCollect as many bonuses before\nyou return to the island", LargeComicText);
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
		}
	}

	public void endIntroScene()
	{
		GUIObject.BroadcastMessage("cutSceneInactive");
		TwoD.SendMessage("introEscape");
	}

	public IEnumerator end2DEscapeIntro()
	{
		return new end2DEscapeIntro$48(this).GetEnumerator();
	}

	public IEnumerator startLevel()
	{
		return new startLevel$50(this).GetEnumerator();
	}

	public void endInstructions()
	{
		if (!BonusLevel)
		{
			ArrowMarker.SendMessage("showArrow");
		}
		restartTime();
		Spotted2D = false;
		LevelDescription = false;
		Player.SendMessage("restartGlider");
		GUIObject.SendMessage("childGUIOn");
		StartJourney = true;
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
		bool flag = true;
		pauseTime();
	}

	public void twoDEscaped()
	{
		ArrowMarker.BroadcastMessage("hideObject");
		TwoD.SendMessage("escapeCutScene");
		Camera.main.SendMessage("escapeCutScene");
		Player.SendMessage("turnControlOff");
		GUIObject.SendMessage("cutSceneOn");
		GUIObject.SendMessage("childGUIOff");
		GUIObject.SendMessage("displayMessage", "2D Has Escaped!");
		ScoreObject.SendMessage("failedLevel");
	}

	public void bonusTimeOut()
	{
		Player.SendMessage("turnControlOff");
		GUIObject.SendMessage("cutSceneOn");
		GUIObject.SendMessage("childGUIOff");
		GUIObject.SendMessage("displayMessage", "Out of Time!");
		ScoreObject.SendMessage("failedLevel");
	}

	public void found2D()
	{
		StartJourney = false;
		GUIObject.BroadcastMessage("stageComplete");
		ScoreObject.SendMessage("stageComplete", StartJourneyTimer);
		TwoD.SetActiveRecursively(state: true);
		Mines.SetActiveRecursively(state: false);
		Player.SendMessage("turnControlOff");
		ScreenFade.SendMessage("setFadeIn");
		Camera.main.SendMessage("enableFollowZoom", 25);
		UnityRuntimeServices.Invoke(ArrowMarker.GetComponent("ArrowMarker"), "changeTarget", new object[1] { TwoD.transform }, typeof(MonoBehaviour));
	}

	public void spotted2D()
	{
		Spotted2D = true;
		pauseTime();
	}

	public IEnumerator battleWon()
	{
		return new battleWon$51(this).GetEnumerator();
	}

	public IEnumerator endLevel()
	{
		return new endLevel$49(this).GetEnumerator();
	}

	public IEnumerator playerKilled()
	{
		return new playerKilled$52(this).GetEnumerator();
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
