// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// PlaneFaceCam
using System;
using UnityEngine;

[Serializable]
public class PlaneFaceCam : MonoBehaviour
{
	public void Update()
	{
		transform.LookAt(Camera.main.transform);
	}

	public void Main()
	{
	}
}
