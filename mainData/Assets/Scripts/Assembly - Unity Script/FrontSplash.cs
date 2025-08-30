// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// FrontSplash
using System;
using UnityEngine;

[Serializable]
public class FrontSplash : MonoBehaviour
{
	public void Update()
	{
		if (transform.position.y < 0.5f)
		{
			particleEmitter.emit = true;
		}
		else
		{
			particleEmitter.emit = false;
		}
	}

	public void Main()
	{
	}
}
