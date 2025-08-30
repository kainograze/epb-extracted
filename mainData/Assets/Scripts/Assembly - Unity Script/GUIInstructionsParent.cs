// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// GUIInstructionsParent
using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class GUIInstructionsParent : MonoBehaviour
{
	public Texture2D OrkaInst;

	public Texture2D ItemInst;

	public Texture2D ControlInst;

	public Texture2D FingerInst;

	public Texture2D CushionInst;

	public Texture2D NextButton;

	public Texture2D SkipButton;

	private bool ShowInstructions;

	private int InstructionNumber;

	private int InstructionLimit;

	public GUIStyle BlankStyle;

	public Vector2[] StartFinish;

	private bool Level1Instructions;

	private bool LandingInstructions;

	public void Start()
	{
	}

	public void Update()
	{
		checked
		{
			if (ShowInstructions && Input.GetKeyDown("space"))
			{
				InstructionNumber++;
			}
		}
	}

	public void OnGUI()
	{
		float num = default(float);
		int num2 = default(int);
		Rect rect = default(Rect);
		checked
		{
			if (Level1Instructions)
			{
				num = unchecked(Screen.height / 2) - unchecked(OrkaInst.height / 2) - 35;
				if (InstructionNumber == 0)
				{
					GUI.DrawTexture(new Rect(unchecked(Screen.width / 2) - unchecked(OrkaInst.width / 2), num, OrkaInst.width, OrkaInst.height), OrkaInst);
				}
				if (InstructionNumber == 1)
				{
					GUI.DrawTexture(new Rect(unchecked(Screen.width / 2) - unchecked(FingerInst.width / 2), num, FingerInst.width, FingerInst.height), FingerInst);
				}
				if (InstructionNumber == 2)
				{
					GUI.DrawTexture(new Rect(unchecked(Screen.width / 2) - unchecked(ControlInst.width / 2), num, ControlInst.width, ControlInst.height), ControlInst);
				}
				if (InstructionNumber == 3)
				{
					GUI.DrawTexture(new Rect(unchecked(Screen.width / 2) - unchecked(ItemInst.width / 2), num, ItemInst.width, ItemInst.height), ItemInst);
				}
			}
			if (LandingInstructions)
			{
				num = unchecked(Screen.height / 2) - unchecked(OrkaInst.height / 2) - 35;
				if (InstructionNumber == 0)
				{
					GUI.DrawTexture(new Rect(unchecked(Screen.width / 2) - unchecked(CushionInst.width / 2), num, CushionInst.width, CushionInst.height), CushionInst);
				}
				if (InstructionNumber == 1)
				{
					GUI.DrawTexture(new Rect(unchecked(Screen.width / 2) - unchecked(ItemInst.width / 2), num, ItemInst.width, ItemInst.height), ItemInst);
				}
			}
			if (!ShowInstructions)
			{
				return;
			}
			num2 = 13;
			num = unchecked(Screen.height / 2) + unchecked(OrkaInst.height / 2) - 35;
			rect = new Rect(unchecked(Screen.width / 2) - NextButton.width - num2, num, NextButton.width, NextButton.height);
			GUI.DrawTexture(rect, NextButton);
			if (GUI.Button(rect, string.Empty, BlankStyle))
			{
				InstructionNumber++;
			}
			if (InstructionNumber < InstructionLimit - 1)
			{
				rect.x += NextButton.width + num2;
				rect.width = SkipButton.width;
				rect.height = SkipButton.height;
				GUI.DrawTexture(rect, SkipButton);
				if (GUI.Button(rect, string.Empty, BlankStyle))
				{
					InstructionNumber = InstructionLimit;
				}
			}
			if (InstructionNumber == InstructionLimit)
			{
				GameObject.Find("LevelControl").SendMessage("endInstructions");
				ShowInstructions = false;
				Level1Instructions = false;
				LandingInstructions = false;
			}
		}
	}

	public void displayInstructions(int inID)
	{
		checked
		{
			if (inID == 1)
			{
				Level1Instructions = true;
				Vector2[] startFinish = StartFinish;
				InstructionNumber = (int)startFinish[RuntimeServices.NormalizeArrayIndex(startFinish, inID)].x;
				Vector2[] startFinish2 = StartFinish;
				InstructionLimit = (int)startFinish2[RuntimeServices.NormalizeArrayIndex(startFinish2, inID)].y;
				ShowInstructions = true;
			}
			if (inID == 2)
			{
				Vector2[] startFinish3 = StartFinish;
				InstructionNumber = (int)startFinish3[RuntimeServices.NormalizeArrayIndex(startFinish3, inID)].x;
				Vector2[] startFinish4 = StartFinish;
				InstructionLimit = (int)startFinish4[RuntimeServices.NormalizeArrayIndex(startFinish4, inID)].y;
				LandingInstructions = true;
				ShowInstructions = true;
			}
		}
	}

	public void Main()
	{
	}
}
