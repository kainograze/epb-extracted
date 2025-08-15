using System;
using UnityEngine;

[Serializable]
public class SpeedboatMove : MonoBehaviour
{
	public float DistancePerSec;
	public float IncrementSpeed;
	public Vector3 Direction;
	public int EscapeZPoint;
	public Transform[] Positions;
}
