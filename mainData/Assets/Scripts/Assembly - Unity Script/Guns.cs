// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Guns
using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class Guns : MonoBehaviour
{
	public Transform Bullet;

	private bool SpeedBoost;

	public Transform[] BulletArray;

	private Rigidbody ParentForce;

	private int NextBullet;

	private float SpeedMultiplier;

	private float CurrentSpeed;

	public void Start()
	{
		ParentForce = transform.parent.rigidbody;
		for (int i = 0; i < 5; i = checked(i + 1))
		{
			Transform[] bulletArray = BulletArray;
			bulletArray[RuntimeServices.NormalizeArrayIndex(bulletArray, i)] = (Transform)UnityEngine.Object.Instantiate(Bullet, transform.position, Quaternion.identity);
			Transform[] bulletArray2 = BulletArray;
			(bulletArray2[RuntimeServices.NormalizeArrayIndex(bulletArray2, i)].GetComponent("BulletsObject") as BulletsObject).setParentTransform(transform);
		}
	}

	public void Update()
	{
	}

	public void fireBullet()
	{
		for (int i = 0; i < 5; i = checked(i + 1))
		{
			Transform[] bulletArray = BulletArray;
			if (bulletArray[RuntimeServices.NormalizeArrayIndex(bulletArray, i)].position.x == 100000f)
			{
				determineBulletSpeed();
				Transform[] bulletArray2 = BulletArray;
				bulletArray2[RuntimeServices.NormalizeArrayIndex(bulletArray2, i)].SendMessage("makeActive", SpeedMultiplier);
				i = Extensions.get_length((System.Array)BulletArray);
			}
		}
	}

	public void determineBulletSpeed()
	{
		CurrentSpeed = ParentForce.velocity.magnitude;
		if (CurrentSpeed < 80f)
		{
			CurrentSpeed = 80f;
		}
		SpeedMultiplier = CurrentSpeed / 80f;
		float z = 3f + SpeedMultiplier * 1.8f;
		Vector3 localPosition = transform.localPosition;
		float num = (localPosition.z = z);
		Vector3 vector = (transform.localPosition = localPosition);
	}

	public void speedBoostOn()
	{
	}

	public void speedBoostOff()
	{
	}

	public void Main()
	{
	}
}
