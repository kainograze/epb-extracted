// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// ParentActivate
using System;
using UnityEngine;

[Serializable]
public class ParentActivate : MonoBehaviour
{
	public void deactivate()
	{
		gameObject.SetActiveRecursively(state: false);
	}

	public void activate()
	{
		gameObject.SetActiveRecursively(state: true);
	}

	public void Main()
	{
	}
}
