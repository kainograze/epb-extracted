// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MissileControl
using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class MissileControl : MonoBehaviour
{
	private GameObject CurrentTarget;

	public Transform Missile;

	private float LockTimer;

	public float LockTime;

	private bool TargetLocked;

	public MissileControl()
	{
		LockTimer = 0f;
	}

	public void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo = default(RaycastHit);
			if (!TargetLocked && Physics.Raycast(ray, out hitInfo, 1000f))
			{
				if (RuntimeServices.EqualityOperator(RuntimeServices.GetProperty(RuntimeServices.GetProperty(hitInfo.collider, "gameObject"), "name"), "Enemy") || RuntimeServices.EqualityOperator(RuntimeServices.GetProperty(RuntimeServices.GetProperty(hitInfo.collider, "gameObject"), "name"), "CannonBall"))
				{
					LockTimer += Time.deltaTime;
					MonoBehaviour.print(LockTimer);
					if (LockTimer > LockTime)
					{
						CurrentTarget = (GameObject)RuntimeServices.Coerce(RuntimeServices.GetProperty(hitInfo.collider, "gameObject"), typeof(GameObject));
						CurrentTarget.SendMessage("lockedOn");
						TargetLocked = true;
					}
				}
				else
				{
					LockTimer = 0f;
				}
			}
		}
		if (Input.GetMouseButtonUp(0))
		{
			LockTimer = 0f;
			if (TargetLocked)
			{
				TargetLocked = false;
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(Missile.gameObject, transform.position, Quaternion.identity);
				(gameObject.GetComponent("MissileBehaviour") as MissileBehaviour).setTarget(CurrentTarget);
			}
		}
	}

	public GameObject returnCurrentTarget()
	{
		return CurrentTarget;
	}

	public void Main()
	{
	}
}
