// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// AnimationLoop
using System;
using UnityEngine;

[Serializable]
public class AnimationLoop : MonoBehaviour
{
	public void Start()
	{
		BroadcastMessage("splashParticles");
	}

	public void Update()
	{
		if (!animation.isPlaying)
		{
			animation.Play();
			BroadcastMessage("splashParticles");
		}
	}

	public void Main()
	{
	}
}
