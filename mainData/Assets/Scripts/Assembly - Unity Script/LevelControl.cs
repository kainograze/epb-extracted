// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// LevelControl
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class LevelControl : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class startLevel$66 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal LevelControl $self_396;

			public $(LevelControl self_)
			{
				$self_396 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					return Yield(2, new WaitForSeconds(1f));
				case 2:
					$self_396.LevelDescription = true;
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

		internal LevelControl $self_397;

		public startLevel$66(LevelControl self_)
		{
			$self_397 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_397);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class endLevel$67 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal LevelControl $self_398;

			public $(LevelControl self_)
			{
				$self_398 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					if ((bool)$self_398.PirateBoats)
					{
						$self_398.PirateBoats.SetActiveRecursively(state: false);
					}
					$self_398.Thermals.SetActiveRecursively(state: false);
					$self_398.Player.SetActiveRecursively(state: false);
					$self_398.ArrowMarker.BroadcastMessage("hideObject");
					$self_398.LandingPad.BroadcastMessage("turnOff");
					$self_398.ScreenFade.SendMessage("setFadeIn");
					Camera.main.SendMessage("endLevelCam");
					return Yield(2, new WaitForSeconds(0.75f));
				case 2:
					$self_398.LevelComplete = true;
					$self_398.LevelTime = Mathf.Round(Time.timeSinceLevelLoad);
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal LevelControl $self_399;

		public endLevel$67(LevelControl self_)
		{
			$self_399 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_399);
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

	private GameObject Player;

	private GameObject SpeedRings;

	private GameObject PirateBoats;

	private GameObject Thermals;

	private GameObject TwoD;

	private GameObject LandingPad;

	private GameObject Mines;

	private int TotalMines;

	private GameObject ReturnMines;

	private GameObject SpeedMines;

	private GameObject ScreenFade;

	private float DialogueTimer;

	private float LevelTime;

	public LevelControl()
	{
		DialogueTime = 8;
	}

	public void Start()
	{
		Player = GameObject.Find("GlideController");
		PirateBoats = GameObject.Find("PirateBoats");
		Thermals = GameObject.Find("Thermals");
		ScreenFade = GameObject.Find("WhiteFade");
		TwoD = GameObject.Find("2DPlane");
		LandingPad = GameObject.Find("LandingPad");
		Mines = GameObject.Find("Mines");
		if ((bool)Mines)
		{
			TotalMines = Mines.transform.childCount;
		}
		LandingPad.SetActiveRecursively(state: false);
		UnityRuntimeServices.Invoke(ArrowMarker.GetComponent("ArrowMarker"), "changeTarget", new object[1] { TwoD.transform }, typeof(MonoBehaviour));
		if ((bool)PirateBoats)
		{
			PirateBoats.BroadcastMessage("delayShooting");
		}
	}

	public void Update()
	{
	}

	public void OnGUI()
	{
		if ((bool)TwoD && TwoD.active && TwoDEscaping && (TwoD.transform.position - Player.transform.position).magnitude > 1000f)
		{
			twoDEscaped();
		}
		checked
		{
			int num = TotalMines - Mines.transform.childCount;
			GUI.Box(new Rect(Screen.width - 140, 110f, 140f, 30f), "Mines Destroyed " + num + "/" + TotalMines);
			if (Stage1TimeOut)
			{
				GUI.Box(new Rect(10f, 50f, 200f, 90f), "2D has escaped!");
				GUI.Button(new Rect(10f, 140f, 200f, 30f), "Press Space To Restart");
				if (Input.GetKeyDown("space"))
				{
					Time.timeScale = 1f;
					Application.LoadLevel(Application.loadedLevel);
				}
			}
			if (LevelDescription)
			{
				GUI.Box(new Rect(10f, 50f, 200f, 60f), "Fly through the rings ahead to \nclimb high enough to find 2D");
				GUI.Button(new Rect(10f, 140f, 200f, 30f), "Press Space To Continue");
				if (Input.GetKeyDown("space"))
				{
					Time.timeScale = 1f;
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
					Time.timeScale = 1f;
					Spotted2D = false;
				}
			}
			if (EscapeIntro)
			{
				DialogueTimer -= Time.deltaTime;
				GUI.Box(new Rect(10f, 50f, 200f, 90f), "2D's ship destroyed!\n\nFollow the arrow back\nto the island");
				if (!(DialogueTimer > 0f))
				{
					DialogueTimer = DialogueTime;
					EscapeIntro = false;
				}
			}
			if (LandingIntro)
			{
				GUI.Box(new Rect(10f, 50f, 200f, 90f), "Crash land on the landing target\nmarked with a flare\n\nBe quick to avoid being shot");
				GUI.Button(new Rect(10f, 140f, 200f, 30f), "Press Space To Continue");
				if (Input.GetKeyDown("space"))
				{
					Time.timeScale = 1f;
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
					Time.timeScale = 1f;
					Application.LoadLevel(Application.loadedLevel);
				}
			}
		}
	}

	public IEnumerator startLevel()
	{
		return new startLevel$66(this).GetEnumerator();
	}

	public void outOfTime()
	{
		Stage1TimeOut = true;
		Time.timeScale = 0f;
	}

	public void spotted2D()
	{
		Spotted2D = true;
		Time.timeScale = 0f;
	}

	public void battleIntro()
	{
		UnityRuntimeServices.Invoke(ArrowMarker.GetComponent("ArrowMarker"), "changeTarget", new object[1] { TwoD.transform }, typeof(MonoBehaviour));
		BattleIntro = true;
		Time.timeScale = 0f;
	}

	public void twoDEscaped()
	{
		Stage1TimeOut = true;
		TwoDEscaping = false;
		Time.timeScale = 0f;
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
		Player.SendMessage("setEscapeRot");
		LandingPad.SetActiveRecursively(state: true);
		EscapeIntro = true;
		DialogueTimer = DialogueTime;
		UnityRuntimeServices.Invoke(ArrowMarker.GetComponent("ArrowMarker"), "changeTarget", new object[1] { LandingPad.transform }, typeof(MonoBehaviour));
		if ((bool)PirateBoats)
		{
			PirateBoats.BroadcastMessage("increaseAccuracy");
		}
		ReturnTrip = true;
	}

	public IEnumerator endLevel()
	{
		return new endLevel$67(this).GetEnumerator();
	}

	public void playerKilled()
	{
		PlayerKilled = true;
		if ((bool)PirateBoats && PirateBoats.active)
		{
			PirateBoats.BroadcastMessage("stopFiring");
		}
	}

	public void Main()
	{
	}
}
