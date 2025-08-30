// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// HealthFaceControl
using System;
using UnityEngine;

[Serializable]
public class HealthFaceControl : MonoBehaviour
{
	private bool FaceAnimate;

	public float Stage1Timer;

	public float Stage2Timer;

	public float Stage3Timer;

	public int StartHealth;

	private float AnimateTimer;

	private int CurrentFace;

	public HealthFaceControl()
	{
		Stage1Timer = 0.2f;
		Stage2Timer = 0.1f;
		Stage3Timer = 0.1f;
		StartHealth = 5;
		CurrentFace = 1;
	}

	public void Update()
	{
		if (FaceAnimate)
		{
			AnimateTimer += Time.deltaTime;
			if (CurrentFace == 2 && AnimateTimer > Stage1Timer)
			{
				updateFace();
			}
			if (CurrentFace == 3 && AnimateTimer > Stage1Timer + Stage2Timer)
			{
				updateFace();
			}
			if (CurrentFace == 4 && AnimateTimer > Stage1Timer + Stage2Timer + Stage3Timer)
			{
				updateFace();
			}
		}
	}

	public void healthChange(int inHealth)
	{
		BroadcastMessage("updateHealthBar", inHealth);
		if (inHealth < StartHealth)
		{
			FaceAnimate = true;
			updateFace();
		}
	}

	public void updateFace()
	{
		checked
		{
			CurrentFace++;
			if (CurrentFace > 4)
			{
				CurrentFace = 1;
				AnimateTimer = 0f;
				FaceAnimate = false;
			}
			BroadcastMessage("changeFace", CurrentFace);
		}
	}

	public void Main()
	{
	}
}
