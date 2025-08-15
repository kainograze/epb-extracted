using System;
using UnityEngine;

[Serializable]
public class WhaleSeek : MonoBehaviour
{
	public Transform[] waypoints;
	public float waypointRadius;
	public float damping;
	public float speed;
	public States state;
}
