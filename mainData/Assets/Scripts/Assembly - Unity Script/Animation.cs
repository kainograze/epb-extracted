// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Animation
using System;
using UnityEngine;

[Serializable]
public class Animation : MonoBehaviour
{
	public void Update()
	{
		if (transform.eulerAngles.z > 15f && transform.eulerAngles.z < 50f)
		{
			if (!animation.IsPlaying("TurnRight"))
			{
				playTurnRight();
			}
		}
		else if (transform.eulerAngles.z > 310f && transform.eulerAngles.z < 345f)
		{
			if (!animation.IsPlaying("TurnLeft"))
			{
				playTurnLeft();
			}
		}
		else if (!animation.IsPlaying("idle"))
		{
			playIdle();
		}
	}

	public void playIdle()
	{
		animation.Play("idle");
	}

	public void playTurnRight()
	{
		animation.Play("TurnRight");
	}

	public void playTurnLeft()
	{
		animation.Play("TurnLeft");
	}

	public void Main()
	{
	}
}
