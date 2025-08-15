using System;
using UnityEngine;

[Serializable]
public class DragRigidbody : MonoBehaviour
{
	public float spring;
	public float damper;
	public float drag;
	public float angularDrag;
	public float distance;
	public bool attachToCenterOfMass;
}
