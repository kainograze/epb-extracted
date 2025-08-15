using System;
using UnityEngine;

[Serializable]
public class GunControl(Particles) : MonoBehaviour
{
	public bool iPhoneControl;
	public Transform BulletSplash;
	public Transform HitExplosion;
	public Vector3 relativeDirection;
	public int BulletsLeft;
	public float ReloadTime;
	public float BulletDisplayReloadTime;
}
