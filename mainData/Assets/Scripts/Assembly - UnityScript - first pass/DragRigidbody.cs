// d4e5115e396b84ea8820f5b0a8f12827, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// DragRigidbody
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

	private SpringJoint springJoint;

	public DragRigidbody()
	{
		spring = 50f;
		damper = 5f;
		drag = 10f;
		angularDrag = 5f;
		distance = 0.2f;
		attachToCenterOfMass = false;
	}

	public void Main()
	{
	}
}
