// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// WhaleAnimation
using System;
using UnityEngine;

[Serializable]
public class WhaleAnimation : MonoBehaviour
{
	public void Start()
	{
		AnimationEvent animationEvent = new AnimationEvent();
		animationEvent.time = animation["swim"].clip.length;
		animationEvent.functionName = "DoSplash";
		animation["swim"].clip.AddEvent(animationEvent);
	}

	public void DoSplash(AnimationEvent animEvent)
	{
		gameObject.BroadcastMessage("SplashTailParticles", SendMessageOptions.DontRequireReceiver);
	}

	public void Main()
	{
	}
}
