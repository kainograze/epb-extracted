// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// OutOfViewStopRotation
using System;
using UnityEngine;

[Serializable]
public class OutOfViewStopRotation : MonoBehaviour
{
	public bool ParentAnimation;

	public OutOfViewStopRotation()
	{
		ParentAnimation = true;
	}

	public void Start()
	{
		if (ParentAnimation)
		{
			transform.parent.SendMessage("stopRotation");
		}
		else
		{
			SendMessage("stopRotation");
		}
	}

	public void OnBecameVisible()
	{
		if (ParentAnimation)
		{
			transform.parent.SendMessage("startRotation");
		}
		else
		{
			SendMessage("startRotation");
		}
	}

	public void OnBecameInvisible()
	{
		if (ParentAnimation)
		{
			transform.parent.SendMessage("stopRotation");
		}
		else
		{
			SendMessage("stopRotation");
		}
	}

	public void Main()
	{
	}
}
