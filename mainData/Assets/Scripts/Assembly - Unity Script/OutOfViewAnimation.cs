// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// OutOfViewAnimation
using System;
using UnityEngine;

[Serializable]
public class OutOfViewAnimation : MonoBehaviour
{
	public bool ParentAnimation;

	public OutOfViewAnimation()
	{
		ParentAnimation = true;
	}

	public void Start()
	{
		if (ParentAnimation)
		{
			transform.parent.animation.Stop();
		}
		else
		{
			animation.Stop();
		}
	}

	public void OnBecameVisible()
	{
		if (ParentAnimation)
		{
			transform.parent.animation.Play();
		}
		else
		{
			animation.Play();
		}
	}

	public void OnBecameInvisible()
	{
		if (ParentAnimation)
		{
			transform.parent.animation.Stop();
		}
		else
		{
			animation.Stop();
		}
	}

	public void Main()
	{
	}
}
