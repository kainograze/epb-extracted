// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Waypoint
using System;
using UnityEngine;

[Serializable]
public class Waypoint : MonoBehaviour
{
	public void OnDrawGizmos()
	{
		Gizmos.DrawIcon(transform.position, "WaypointFlag.tif");
	}

	public void Main()
	{
	}
}
