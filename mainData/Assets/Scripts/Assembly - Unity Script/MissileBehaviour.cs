// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MissileBehaviour
using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class MissileBehaviour : MonoBehaviour
{
	public GameObject Target;

	public int MissileID;

	public float Speed;

	private bool LockOn;

	private Vector3 targetDir;

	public void Update()
	{
		if (LockOn)
		{
			targetDir = Target.transform.position - transform.position;
			targetDir.Normalize();
			rigidbody.velocity = targetDir * Speed;
		}
	}

	public void makeActive(object inID)
	{
		if (RuntimeServices.EqualityOperator(MissileID, inID))
		{
			LockOn = true;
			Target = (transform.parent.gameObject.GetComponent("MissileControl") as MissileControl).returnCurrentTarget();
		}
	}

	public void setTarget(object inTarget)
	{
		Target = (GameObject)RuntimeServices.Coerce(inTarget, typeof(GameObject));
		LockOn = true;
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Enemy")
		{
			other.SendMessage("Hit");
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	public void Main()
	{
	}
}
