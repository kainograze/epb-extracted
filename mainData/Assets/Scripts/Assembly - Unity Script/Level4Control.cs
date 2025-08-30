// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Level4Control
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class Level4Control : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class endLevel$56 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Level4Control $self_378;

			public $(Level4Control self_)
			{
				$self_378 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					$self_378.ScoreObject.SendMessage("stageComplete", $self_378.ReturnTimer);
					$self_378.ScoreObject.SendMessage("levelComplete");
					$self_378.ReturnTrip = false;
					if ((bool)$self_378.PirateBoats)
					{
						$self_378.PirateBoats.SetActiveRecursively(state: false);
					}
					$self_378.Thermals.SetActiveRecursively(state: false);
					$self_378.Player.SetActiveRecursively(state: false);
					$self_378.ArrowMarker.BroadcastMessage("hideObject");
					$self_378.LandingPad.BroadcastMessage("turnOff");
					$self_378.ScreenFade.SendMessage("setFadeIn");
					Camera.main.SendMessage("endLevelCam");
					return Yield(2, new WaitForSeconds(0.75f));
				case 2:
					$self_378.LevelComplete = true;
					$self_378.LevelTime = Mathf.Round(Time.timeSinceLevelLoad);
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal Level4Control $self_379;

		public endLevel$56(Level4Control self_)
		{
			$self_379 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_379);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class startLevel$57 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Level4Control $self_376;

			public $(Level4Control self_)
			{
				$self_376 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					return Yield(2, new WaitForSeconds(1f));
				case 2:
					$self_376.LevelDescription = true;
					$self_376.pauseTime();
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal Level4Control $self_377;

		public startLevel$57(Level4Control self_)
		{
			$self_377 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_377);
		}
	}

	public Transform ArrowMarker;

	private int DialogueTime;

	public float Stage1Timer;

	private bool Spotted2D;

	private bool Stage1TimeOut;

	private bool BattleIntro;

	private bool LevelComplete;

	private bool LevelDescription;

	private bool TwoDEscaping;

	private bool EscapeIntro;

	private bool ReturnTrip;

	private bool LandingIntro;

	private bool PlayerKilled;

	private bool PirateBattleIntro;

	private bool DisplayPirateBattle;

	public float PirateBattleTimer;

	private GameObject Player;

	private GameObject SpeedRings;

	private GameObject ScoreObject;

	private GameObject PirateBoats;

	private GameObject Mines;

	private bool StartJourney;

	public float StartJourneyTimer;

	private GameObject PirateBoatsBattle;

	private GameObject MinesBattle;

	private int TotalPirates;

	private GameObject MinesReturn;

	public float ReturnTimer;

	private int TotalReturnMines;

	private GameObject Thermals;

	private GameObject TwoD;

	private GameObject LandingPad;

	private int TotalMines;

	private GameObject SpeedMines;

	private GameObject ScreenFade;

	private float DialogueTimer;

	private float LevelTime;

	public Level4Control()
	{
		DialogueTime = 12;
		PirateBattleTimer = 90f;
		StartJourney = true;
		StartJourneyTimer = 90f;
		ReturnTimer = 120f;
	}

	public void Start()
	{
		ScoreObject = GameObject.Find("Score");
		Player = GameObject.Find("GlideController");
		PirateBoats = GameObject.Find("PirateBoats");
		PirateBoatsBattle = GameObject.Find("PirateBoatsBattle");
		Thermals = GameObject.Find("Thermals");
		ScreenFade = GameObject.Find("WhiteFade");
		TwoD = GameObject.Find("2DPlane");
		LandingPad = GameObject.Find("LandingPad");
		Mines = GameObject.Find("Mines");
		MinesBattle = GameObject.Find("MinesBattle");
		MinesReturn = GameObject.Find("MinesReturn");
		if ((bool)PirateBoatsBattle)
		{
			int childCount = PirateBoatsBattle.transform.childCount;
		}
		LandingPad.SetActiveRecursively(state: false);
		PirateBoatsBattle.SetActiveRecursively(state: false);
		MinesBattle.SetActiveRecursively(state: false);
		MinesReturn.SetActiveRecursively(state: false);
		UnityRuntimeServices.Invoke(ArrowMarker.GetComponent("ArrowMarker"), "changeTarget", new object[1] { TwoD.transform }, typeof(MonoBehaviour));
		if ((bool)PirateBoats)
		{
			int childCount2 = PirateBoats.transform.childCount;
			PirateBoats.BroadcastMessage("delayShooting");
		}
	}

	public void Update()
	{
		if (StartJourney)
		{
			StartJourneyTimer -= Time.deltaTime;
			if (StartJourneyTimer < 0f)
			{
				playerKilled();
			}
		}
		if (DisplayPirateBattle)
		{
			PirateBattleTimer -= Time.deltaTime;
			if (PirateBattleTimer < 0f)
			{
				playerKilled();
				DisplayPirateBattle = false;
			}
		}
		if (ReturnTrip)
		{
			ReturnTimer -= Time.deltaTime;
			if (ReturnTimer < 0f)
			{
				StartCoroutine_Auto(endLevel());
			}
		}
	}

	public void OnGUI()
	{
		if ((bool)TwoD && TwoD.active && TwoDEscaping && (TwoD.transform.position - Player.transform.position).magnitude > 1000f)
		{
			twoDEscaped();
		}
		if (Stage1TimeOut)
		{
			GUI.Box(new Rect(10f, 50f, 200f, 90f), "2D has escaped!");
			GUI.Button(new Rect(10f, 140f, 200f, 30f), "Press Space To Restart");
			if (Input.GetKeyDown("space"))
			{
				restartTime();
				Application.LoadLevel(Application.loadedLevel);
			}
		}
		checked
		{
			if (StartJourney)
			{
				GUI.Box(new Rect(unchecked(Screen.width / 2) - 70, 10f, 140f, 30f), "Time Left - " + Mathf.Round(StartJourneyTimer));
			}
			if (LevelDescription)
			{
				GUI.Box(new Rect(10f, 50f, 200f, 60f), "Fly through the rings ahead to \nclimb high enough to find 2D");
				GUI.Button(new Rect(10f, 140f, 200f, 30f), "Press Space To Continue");
				if (Input.GetKeyDown("space"))
				{
					restartTime();
					Spotted2D = false;
					LevelDescription = false;
				}
			}
			if (Spotted2D)
			{
				GUI.Box(new Rect(10f, 50f, 200f, 60f), "You've spotted 2D! \nPrevent him from escaping");
				GUI.Button(new Rect(10f, 140f, 200f, 30f), "Press Space To Continue");
				if (Input.GetKeyDown("space"))
				{
					restartTime();
					Spotted2D = false;
				}
			}
			if (EscapeIntro)
			{
				DialogueTimer -= Time.deltaTime;
				GUI.Box(new Rect(unchecked(Screen.width / 2) - 100, 110f, 200f, 90f), "Return to the island\nwithin the time left to\ngain bonus points");
				if (!(DialogueTimer > 0f))
				{
					DialogueTimer = DialogueTime;
					EscapeIntro = false;
				}
			}
			if (PirateBattleIntro)
			{
				GUI.Box(new Rect(10f, 50f, 200f, 90f), "2D's vehicle is destroyed\n\nDestroy the pirates before\nthey destroy the oilrig\nwith 2D inside it!");
				GUI.Button(new Rect(10f, 140f, 200f, 30f), "Press Space To Continue");
				if (Input.GetKeyDown("space"))
				{
					restartTime();
					PirateBattleIntro = false;
					DisplayPirateBattle = true;
					ScoreObject.SendMessage("stageComplete", StartJourneyTimer);
				}
			}
			if (DisplayPirateBattle)
			{
				GUI.Box(new Rect(unchecked(Screen.width / 2) - 150, 10f, 140f, 30f), "Time Left - " + Mathf.Round(PirateBattleTimer));
				int num = TotalPirates - PirateBoatsBattle.transform.childCount;
				GUI.Box(new Rect(unchecked(Screen.width / 2) + 10, 10f, 140f, 30f), "Pirates Destroyed " + num + "/" + TotalPirates);
				if (num == TotalPirates)
				{
					DisplayPirateBattle = false;
					piratesDestroyed();
				}
			}
			if (ReturnTrip)
			{
				GUI.Box(new Rect(unchecked(Screen.width / 2) - 70, 10f, 140f, 30f), "Time Left - " + Mathf.Round(ReturnTimer));
			}
			if (LandingIntro)
			{
				GUI.Box(new Rect(10f, 50f, 200f, 90f), "Crash land on the landing target\nmarked with a flare\n\nBe quick to avoid being shot");
				GUI.Button(new Rect(10f, 140f, 200f, 30f), "Press Space To Continue");
				if (Input.GetKeyDown("space"))
				{
					restartTime();
					LandingIntro = false;
				}
			}
			if (LevelComplete)
			{
				GUI.Box(new Rect(10f, 50f, 200f, 20f), "LEVEL COMPLETE!");
				if (GUI.Button(new Rect(10f, 170f, 100f, 30f), "Menu"))
				{
					Application.LoadLevel(0);
				}
				GUI.Box(new Rect(Screen.width - 140, 145f, 140f, 30f), "Level Time " + LevelTime + "Secs");
			}
			if (PlayerKilled)
			{
				GUI.Box(new Rect(10f, 50f, 200f, 90f), "GAME OVER");
				GUI.Button(new Rect(10f, 140f, 200f, 30f), "Press Space To Restart");
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
		return new startLevel$57(this).GetEnumerator();
	}

	public void addTime(int AddTimeAmount)
	{
		if (StartJourney)
		{
			StartJourneyTimer += AddTimeAmount;
		}
		if (DisplayPirateBattle)
		{
			PirateBattleTimer += AddTimeAmount;
		}
		if (ReturnTrip)
		{
			ReturnTimer += AddTimeAmount;
		}
	}

	public void outOfTime()
	{
		Stage1TimeOut = true;
		pauseTime();
	}

	public void spotted2D()
	{
		Spotted2D = true;
		pauseTime();
	}

	public void battleIntro()
	{
		UnityRuntimeServices.Invoke(ArrowMarker.GetComponent("ArrowMarker"), "changeTarget", new object[1] { TwoD.transform }, typeof(MonoBehaviour));
		BattleIntro = true;
		pauseTime();
	}

	public void twoDEscaped()
	{
		Stage1TimeOut = true;
		TwoDEscaping = false;
		pauseTime();
	}

	public void twoDEscaping()
	{
	}

	public void found2D()
	{
		TwoD.SetActiveRecursively(state: true);
		SpeedRings.SetActiveRecursively(state: false);
		if ((bool)PirateBoats)
		{
			PirateBoats.SetActiveRecursively(state: true);
			PirateBoats.BroadcastMessage("delayShooting");
		}
	}

	public void battleWon()
	{
		StartJourney = false;
		PirateBattleIntro = true;
		PirateBoats.SetActiveRecursively(state: false);
		PirateBoatsBattle.SetActiveRecursively(state: true);
		PirateBoatsBattle.BroadcastMessage("delayShooting");
		Mines.SetActiveRecursively(state: false);
		MinesBattle.SetActiveRecursively(state: true);
		Thermals.SetActiveRecursively(state: false);
		TotalPirates = PirateBoatsBattle.transform.childCount;
		pauseTime();
	}

	public void piratesDestroyed()
	{
		ScoreObject.SendMessage("stageComplete", PirateBattleTimer);
		Thermals.SetActiveRecursively(state: true);
		EscapeIntro = true;
		DialogueTimer = DialogueTime;
		UnityRuntimeServices.Invoke(ArrowMarker.GetComponent("ArrowMarker"), "changeTarget", new object[1] { LandingPad.transform }, typeof(MonoBehaviour));
		MinesReturn.SetActiveRecursively(state: true);
		TotalReturnMines = MinesReturn.transform.childCount;
		ReturnTrip = true;
		LandingPad.SetActiveRecursively(state: true);
	}

	public IEnumerator endLevel()
	{
		return new endLevel$56(this).GetEnumerator();
	}

	public void playerKilled()
	{
		pauseTime();
		PlayerKilled = true;
		if ((bool)PirateBoats && PirateBoats.active)
		{
			PirateBoats.BroadcastMessage("stopFiring");
		}
	}

	public void pauseTime()
	{
		Player.BroadcastMessage("audioOff", 1);
		Time.timeScale = 0f;
	}

	public void restartTime()
	{
		Player.BroadcastMessage("audioOn", 1);
		Time.timeScale = 1f;
	}

	public void Main()
	{
	}
}
