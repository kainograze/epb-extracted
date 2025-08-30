// d4e5115e396b84ea8820f5b0a8f12827, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// SmoothFollow
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
[AddComponentMenu("Camera-Control/Smooth Follow")]
public class SmoothFollow : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class enableFollowZoom$1 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal SmoothFollow $self_18;

			public $(SmoothFollow self_)
			{
				$self_18 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					return Yield(2, new WaitForSeconds(0.25f));
				case 2:
					$self_18.FollowEnabled = true;
					$self_18.distance = 0f;
					$self_18.ZoomIn = true;
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal SmoothFollow $self_19;

		public enableFollowZoom$1(SmoothFollow self_)
		{
			$self_19 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_19);
		}
	}

	private Transform target;

	public float distance;

	public float height;

	public float heightDamping;

	public float rotationDamping;

	public bool FollowEnabled;

	private bool DisableScript;

	private float CameraShakeTimer;

	private float CameraShakeTime;

	private bool ZoomIn;

	private bool LookAtOff;

	private bool m_SmoothFollow;

	public SmoothFollow()
	{
		distance = 10f;
		height = 5f;
		heightDamping = 2f;
		rotationDamping = 3f;
		FollowEnabled = true;
		ZoomIn = false;
		LookAtOff = false;
		m_SmoothFollow = true;
	}

	public void Start()
	{
		target = GameObject.Find("GlideController").transform;
	}

	public void LateUpdate()
	{
		if (DisableScript || !m_SmoothFollow)
		{
			return;
		}
		if (FollowEnabled)
		{
			if (!target)
			{
				return;
			}
			float y = target.eulerAngles.y;
			float b = target.position.y + height;
			float y2 = transform.eulerAngles.y;
			float y3 = transform.position.y;
			y2 = Mathf.LerpAngle(y2, y, rotationDamping * Time.deltaTime);
			y3 = Mathf.Lerp(y3, b, heightDamping * Time.deltaTime);
			Quaternion quaternion = Quaternion.Euler(0f, y2, 0f);
			transform.position = target.position;
			transform.position -= quaternion * Vector3.forward * distance;
			float y4 = y3;
			Vector3 position = transform.position;
			float num = (position.y = y4);
			Vector3 vector = (transform.position = position);
			if (!LookAtOff)
			{
				transform.LookAt(target);
			}
		}
		if (ZoomIn)
		{
			distance -= Time.deltaTime * 15f;
			if (distance < 0f)
			{
				ZoomIn = false;
				distance = 0f;
				height = -1f;
				LookAtOff = true;
				SendMessage("enablePanLook");
			}
		}
		float num2 = default(float);
		num2 = ((!(target.transform.eulerAngles.x > 310f)) ? target.transform.eulerAngles.x : (target.transform.eulerAngles.x - 360f));
		num2 /= 20f;
		num2 -= 0.5f;
		if (Mathf.Abs(num2 - height) > 0.05f)
		{
			if (height < num2)
			{
				height += Time.deltaTime * 0.85f;
			}
			else
			{
				height -= Time.deltaTime * 0.85f;
			}
		}
		if (height < -2f)
		{
			height = -2f;
		}
		if (height > 1f)
		{
			height = 1f;
		}
		float z = target.transform.eulerAngles.z;
		Vector3 eulerAngles = transform.eulerAngles;
		float num3 = (eulerAngles.z = z);
		Vector3 vector3 = (transform.eulerAngles = eulerAngles);
		if (CameraShakeTimer > 0f)
		{
			Vector3 vector5 = new Vector3(UnityEngine.Random.Range(-1, 1), UnityEngine.Random.Range(-1, 1), 0f);
			vector5 *= 0.025f;
			transform.localPosition += vector5;
			CameraShakeTimer -= Time.deltaTime;
		}
	}

	public void toggleAim()
	{
		if (distance == 3f)
		{
			distance = 1f;
			height = 0.2f;
		}
		else
		{
			distance = 3f;
			height = 1f;
		}
	}

	public void disableFollow()
	{
		FollowEnabled = false;
	}

	public void enableFollow()
	{
		FollowEnabled = true;
		distance = 3f;
		height = 1f;
		target.SendMessage("turnControlOn");
		LookAtOff = false;
	}

	public void disableScripts()
	{
		DisableScript = true;
	}

	public void lookAtOff()
	{
		LookAtOff = true;
	}

	public void cameraShake()
	{
		CameraShakeTimer = CameraShakeTime;
	}

	public void setShakeTime(float inTime)
	{
		CameraShakeTime = inTime;
	}

	public IEnumerator enableFollowZoom(int inDistance)
	{
		return new enableFollowZoom$1(this).GetEnumerator();
	}

	public void endLevelCam()
	{
		m_SmoothFollow = false;
	}

	public void Main()
	{
	}
}
