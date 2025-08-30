// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// LevelControl copy
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class LevelControl copy : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class startLevel$62 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal LevelControl copy $self_388;

			public $(LevelControl copy self_)
			{
				$self_388 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					return Yield(2, new WaitForSeconds(1f));
				case 2:
					$self_388.LevelDescription = true;
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

		internal LevelControl copy $self_389;

		public startLevel$62(LevelControl copy self_)
		{
			$self_389 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_389);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class checkDistance$63 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal LevelControl copy $self_390;

			public $(LevelControl copy self_)
			{
				$self_390 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					return Yield(2, new WaitForSeconds(8f));
				case 2:
					if ((bool)$self_390.TwoD && $self_390.TwoD.active)
					{
						if (($self_390.TwoD.transform.position - $self_390.Player.transform.position).magnitude > 2000f)
						{
							$self_390.twoDEscaped();
						}
						else
						{
							$self_390.TwoDEscaping = false;
						}
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

		internal LevelControl copy $self_391;

		public checkDistance$63(LevelControl copy self_)
		{
			$self_391 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_391);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class battleWon$64 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal LevelControl copy $self_392;

			public $(LevelControl copy self_)
			{
				$self_392 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					return Yield(2, new WaitForSeconds(2f));
				case 2:
					$self_392.LandingPad.SetActiveRecursively(state: true);
					UnityRuntimeServices.Invoke($self_392.ArrowMarker.GetComponent("ArrowMarker"), "changeTarget", new object[1] { $self_392.LandingPad.transform }, typeof(MonoBehaviour));
					$self_392.ScreenFade.SendMessage("setFadeIn");
					return Yield(3, new WaitForSeconds(0.25f));
				case 3:
					$self_392.Player.SendMessage("setEscapePos");
					if ((bool)$self_392.PirateBoats)
					{
						$self_392.PirateBoats.BroadcastMessage("increaseAccuracy");
					}
					return Yield(4, new WaitForSeconds(1f));
				case 4:
					Time.timeScale = 0f;
					$self_392.EscapeIntro = true;
					$self_392.ReturnTrip = true;
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal LevelControl copy $self_393;

		public battleWon$64(LevelControl copy self_)
		{
			$self_393 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_393);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class endLevel$65 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal LevelControl copy $self_394;

			public $(LevelControl copy self_)
			{
				$self_394 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					if ((bool)$self_394.PirateBoats)
					{
						$self_394.PirateBoats.SetActiveRecursively(state: false);
					}
					$self_394.Thermals.SetActiveRecursively(state: false);
					$self_394.Player.SetActiveRecursively(state: false);
					$self_394.ArrowMarker.BroadcastMessage("hideObject");
					$self_394.LandingPad.BroadcastMessage("turnOff");
					$self_394.ScreenFade.SendMessage("setFadeIn");
					Camera.main.SendMessage("endLevelCam");
					return Yield(2, new WaitForSeconds(0.75f));
				case 2:
					$self_394.LevelComplete = true;
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal LevelControl copy $self_395;

		public endLevel$65(LevelControl copy self_)
		{
			$self_395 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_395);
		}
	}

	public Transform ArrowMarker;

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

	private GameObject ReturnMines;

	private GameObject SpeedMines;

	private GameObject ScreenFade;

	public void Start()
	{
		StartCoroutine_Auto(startLevel());
		Player = GameObject.Find("GlideController");
		SpeedRings = GameObject.Find("SpeedRingCollection");
		PirateBoats = GameObject.Find("PirateBoats");
		Thermals = GameObject.Find("Thermals");
		ScreenFade = GameObject.Find("WhiteFade");
		TwoD = GameObject.Find("2DPlane");
		LandingPad = GameObject.Find("LandingPad");
		Mines = GameObject.Find("Mines");
		ReturnMines = GameObject.Find("MinesReturn");
		if ((bool)PirateBoats)
		{
			PirateBoats.SetActiveRecursively(state: false);
		}
		Thermals.SetActiveRecursively(state: false);
		TwoD.SetActiveRecursively(state: false);
		LandingPad.SetActiveRecursively(state: false);
		Mines.SetActiveRecursively(state: false);
		ReturnMines.SetActiveRecursively(state: false);
	}

	public void Update()
	{
		if (Stage1Timer > 0f)
		{
			Stage1Timer -= Time.deltaTime;
			if (!(Stage1Timer > 0f))
			{
				outOfTime();
			}
		}
	}

	public void OnGUI()
	{
		if ((bool)TwoD && TwoD.active && !TwoDEscaping && (TwoD.transform.position - Player.transform.position).magnitude > 2000f)
		{
			TwoDEscaping = true;
			StartCoroutine_Auto(checkDistance());
		}
		checked
		{
			if (Stage1Timer > 0f)
			{
				GUI.Box(new Rect(unchecked(Screen.width / 2) - 70, 10f, 140f, 30f), "Time Left - " + Mathf.Round(Stage1Timer));
			}
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
			if (BattleIntro)
			{
				GUI.Box(new Rect(10f, 50f, 200f, 90f), "2D is ahead of you \nUse the thermals to keep altitude \nGet close enough to shoot him\n\nWatch out for cannon fire \nfrom pirates");
				GUI.Button(new Rect(10f, 140f, 200f, 30f), "Press Space To Continue");
				if (Input.GetKeyDown("space"))
				{
					Time.timeScale = 1f;
					BattleIntro = false;
				}
			}
			if (EscapeIntro)
			{
				GUI.Box(new Rect(10f, 50f, 200f, 90f), "Escape back to the island\n\nFollow the thermals to get back \n\nDive and weave to avoid\ncannon fire");
				GUI.Button(new Rect(10f, 140f, 200f, 30f), "Press Space To Continue");
				if (Input.GetKeyDown("space"))
				{
					Time.timeScale = 1f;
					EscapeIntro = false;
				}
			}
			if (ReturnTrip && (Player.transform.position - LandingPad.transform.position).magnitude < 750f)
			{
				LandingIntro = true;
				ReturnTrip = false;
				Time.timeScale = 0f;
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
		return new startLevel$62(this).GetEnumerator();
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

	public IEnumerator checkDistance()
	{
		return new checkDistance$63(this).GetEnumerator();
	}

	public void twoDEscaped()
	{
		Stage1TimeOut = true;
		TwoDEscaping = false;
		Time.timeScale = 0f;
	}

	public void found2D()
	{
		Stage1Timer = 0f;
		TwoD.SetActiveRecursively(state: true);
		SpeedRings.SetActiveRecursively(state: false);
		if ((bool)PirateBoats)
		{
			PirateBoats.SetActiveRecursively(state: true);
			PirateBoats.BroadcastMessage("delayShooting");
		}
		Mines.SetActiveRecursively(state: true);
		ReturnMines.SetActiveRecursively(state: true);
		Thermals.SetActiveRecursively(state: true);
		Player.SendMessage("turnControlOff");
		ScreenFade.SendMessage("setFadeIn");
		Camera.main.SendMessage("enableFollowZoom", 25);
	}

	public IEnumerator battleWon()
	{
		return new battleWon$64(this).GetEnumerator();
	}

	public IEnumerator endLevel()
	{
		return new endLevel$65(this).GetEnumerator();
	}

	public void playerKilled()
	{
		PlayerKilled = true;
		if (PirateBoats.active)
		{
			PirateBoats.BroadcastMessage("stopFiring");
		}
	}

	public void Main()
	{
	}
}
