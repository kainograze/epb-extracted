// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// GUIFunctions
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class GUIFunctions : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class checkScreenSize$45 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal GUIFunctions $self_346;

			public $(GUIFunctions self_)
			{
				$self_346 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				case 2:
					if ($self_346.CurrentScreenWidth != Screen.width)
					{
						$self_346.BroadcastMessage("alignGUI");
						$self_346.CurrentScreenWidth = Screen.width;
					}
					return Yield(3, null);
				default:
					if (true)
					{
						return Yield(2, new WaitForSeconds(0.2f));
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

		internal GUIFunctions $self_347;

		public checkScreenSize$45(GUIFunctions self_)
		{
			$self_347 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_347);
		}
	}

	private bool CutScene;

	public Texture2D CutSceneBorder;

	private string MessageText;

	public float MessageTime;

	private float MessageTimer;

	private int CurrentScreenWidth;

	public Texture2D TextBackground;

	public GUIStyle LargeComicText;

	public GUIFunctions()
	{
		CutScene = true;
		MessageTime = 3f;
	}

	public void Start()
	{
		CurrentScreenWidth = Screen.width;
		cutSceneOn();
		childGUIOff();
		StartCoroutine("checkScreenSize");
	}

	public IEnumerator checkScreenSize()
	{
		return new checkScreenSize$45(this).GetEnumerator();
	}

	public void Update()
	{
		if (MessageTimer > 0f)
		{
			MessageTimer -= Time.deltaTime;
		}
	}

	public void OnGUI()
	{
		GUI.depth = 1;
		if (CutScene)
		{
			GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height / 8), CutSceneBorder);
			GUI.DrawTexture(new Rect(0f, checked(Screen.height - unchecked(Screen.height / 8)), Screen.width, Screen.height / 8), CutSceneBorder);
		}
		checked
		{
			if (MessageTimer > 0f)
			{
				GUI.DrawTexture(new Rect(unchecked(Screen.width / 2) - 160, unchecked(Screen.height / 2) - 15, 320f, 72f), TextBackground);
				GUI.Box(new Rect(unchecked(Screen.width / 2) - 100, unchecked(Screen.height / 2), 200f, 60f), MessageText, LargeComicText);
			}
		}
	}

	public void cutSceneOn()
	{
		CutScene = true;
		Camera.main.BroadcastMessage("thermalOff");
		Camera.main.BroadcastMessage("stallOff");
	}

	public void cutSceneOff()
	{
		CutScene = false;
	}

	public void displayMessage(string inString)
	{
		MessageTimer = MessageTime;
		MessageText = inString;
	}

	public void childGUIOff()
	{
		BroadcastMessage("turnGUIOff");
	}

	public void childGUIOn()
	{
		BroadcastMessage("turnGUIOn");
	}

	public void Main()
	{
	}
}
