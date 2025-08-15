using System;
using UnityEngine;

[Serializable]
public class Joystick : MonoBehaviour
{
	public bool touchPad;
	public Rect touchZone;
	public Vector2 deadZone;
	public bool normalize;
	public Vector2 position;
	public int tapCount;
}
