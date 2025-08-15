using System;
using UnityEngine;

[Serializable]
public class Movement2D : MonoBehaviour
{
	public Transform[] waypoints;
	public float waypointRadius;
	public float damping;
	public bool loop;
	public float startspeed;
	public bool faceHeading;
	public Transform EscapePos;
	public bool IsAPlane;
	public int StartPos;
}
