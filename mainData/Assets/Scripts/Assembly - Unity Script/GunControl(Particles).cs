// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// GunControl(Particles)
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class GunControl(Particles) : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class playFirstAttackAudio$74 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal GunControl(Particles) $self_420;

			public $(GunControl(Particles) self_)
			{
				$self_420 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					$self_420.BroadcastMessage("audioOn", 6);
					return Yield(2, new WaitForSeconds(1f));
				case 2:
					$self_420.BroadcastMessage("audioOn", 7);
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal GunControl(Particles) $self_421;

		public playFirstAttackAudio$74(GunControl(Particles) self_)
		{
			$self_421 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_421);
		}
	}

	public bool iPhoneControl;

	public Transform BulletSplash;

	public Transform HitExplosion;

	private int TouchArrayPositionShoot;

	private bool iPhoneShooting;

	private GameObject LevelControl;

	public Vector3 relativeDirection;

	public int BulletsLeft;

	public float ReloadTime;

	public float BulletDisplayReloadTime;

	private float ReloadTimer;

	private float BulletDisplayReloadTimer;

	private bool Shooting;

	public GunControl(Particles)()
	{
		relativeDirection = Vector3.forward;
		BulletsLeft = 300;
		BulletDisplayReloadTime = 0.08f;
	}

	public void Start()
	{
		LevelControl = GameObject.Find("LevelControl");
	}

	public void Update()
	{
		if (!rigidbody.isKinematic)
		{
			if (iPhoneControl)
			{
				iPhoneShoot();
			}
			else
			{
				keyboardShoot();
			}
		}
		RaycastHit hitInfo = default(RaycastHit);
		Vector3 forward = Vector3.forward;
		Vector3 vector = default(Vector3);
		if (BulletsLeft <= 0 || !Shooting)
		{
			return;
		}
		ReloadTimer -= Time.deltaTime;
		BulletDisplayReloadTimer -= Time.deltaTime;
		if (ReloadTimer < 0f)
		{
			vector = transform.rotation * relativeDirection;
			if (Physics.Raycast(transform.position, vector, out hitInfo, 1400f))
			{
				if (RuntimeServices.EqualityOperator(RuntimeServices.GetProperty(RuntimeServices.GetProperty(hitInfo.collider, "gameObject"), "tag"), "Hittable"))
				{
					UnityRuntimeServices.Invoke(RuntimeServices.GetProperty(hitInfo.collider, "gameObject"), "SendMessage", new object[1] { "Hit" }, typeof(MonoBehaviour));
					UnityEngine.Object.Instantiate(HitExplosion, hitInfo.point, Quaternion.identity);
				}
				if (RuntimeServices.EqualityOperator(RuntimeServices.GetProperty(RuntimeServices.GetProperty(hitInfo.collider, "gameObject"), "name"), "WaterBottomLayer"))
				{
					UnityEngine.Object.Instantiate(BulletSplash, hitInfo.point, Quaternion.identity);
				}
			}
			ReloadTimer = ReloadTime;
		}
		if (BulletDisplayReloadTimer < 0f)
		{
			vector = transform.rotation * relativeDirection;
			if (Physics.Raycast(transform.position, vector, out hitInfo, 1000f) && RuntimeServices.EqualityOperator(RuntimeServices.GetProperty(RuntimeServices.GetProperty(hitInfo.collider, "gameObject"), "name"), "WaterBottomLayer"))
			{
				UnityEngine.Object.Instantiate(BulletSplash, hitInfo.point, Quaternion.identity);
			}
			BroadcastMessage("fireBullet");
			BulletDisplayReloadTimer = BulletDisplayReloadTime;
		}
	}

	public void iPhoneShoot()
	{
	}

	public void keyboardShoot()
	{
		if (Time.timeScale > 0f)
		{
			if (Input.GetKeyDown("space"))
			{
				audio.Play();
				BroadcastMessage("startShooting");
				Shooting = true;
			}
			if (Input.GetKeyUp("space"))
			{
				BroadcastMessage("stopShooting");
				audio.Stop();
				Shooting = false;
				ReloadTimer = 0f;
				BulletDisplayReloadTimer = 0f;
			}
		}
	}

	public void stopShooting()
	{
		BroadcastMessage("gunsOff");
		audio.Stop();
		Shooting = false;
		ReloadTimer = 0f;
		BulletDisplayReloadTimer = 0f;
	}

	public IEnumerator playFirstAttackAudio()
	{
		return new playFirstAttackAudio$74(this).GetEnumerator();
	}

	public void Main()
	{
	}
}
