// d4e5115e396b84ea8820f5b0a8f12827, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// TimedObjectDestructor
using System;
using UnityEngine;

[Serializable]
public class TimedObjectDestructor : MonoBehaviour
{
	public float timeOut;

	public bool detachChildren;

	public TimedObjectDestructor()
	{
		timeOut = 1f;
		detachChildren = false;
	}

	public void Awake()
	{
		Invoke("DestroyNow", timeOut);
	}

	public void DestroyNow()
	{
		if (detachChildren)
		{
			transform.DetachChildren();
		}
		UnityEngine.Object.DestroyObject(gameObject);
	}

	public void Main()
	{
	}
}
