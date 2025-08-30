// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Hide
using System;
using UnityEngine;

[Serializable]
public class Hide : MonoBehaviour
{
	public void Update()
	{
	}

	public void toggleHide()
	{
		renderer.enabled = !renderer.enabled;
	}

	public void hideObject()
	{
		renderer.enabled = false;
	}

	public void showObject()
	{
		renderer.enabled = true;
	}

	public void Main()
	{
	}
}
