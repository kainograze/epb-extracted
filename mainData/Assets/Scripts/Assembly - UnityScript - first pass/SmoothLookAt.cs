// d4e5115e396b84ea8820f5b0a8f12827, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// SmoothLookAt
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
[AddComponentMenu("Camera-Control/Smooth Look At")]
public class SmoothLookAt : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class delayFollow$2 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal SmoothLookAt $self_20;

			public $(SmoothLookAt self_)
			{
				$self_20 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					return Yield(2, new WaitForSeconds(0.25f));
				case 2:
					$self_20.disableLookAt();
					$self_20.SendMessage("enableFollowZoom", 15);
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal SmoothLookAt $self_21;

		public delayFollow$2(SmoothLookAt self_)
		{
			$self_21 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_21);
		}
	}

	private Transform target;

	private Transform Glider;

	private Transform TwoDTarget;

	private Transform TwoDObject;

	public float damping;

	public bool smooth;

	private float TimeOnCam;

	private int PositionCount;

	public bool LookAtEnabled;

	public SmoothLookAt()
	{
		damping = 6f;
		smooth = true;
		TimeOnCam = 0.1f * -1f;
		PositionCount = 0;
		LookAtEnabled = false;
	}

	public void Start()
	{
		GameObject.Find("GlideController");
		target = Glider;
		if ((bool)rigidbody)
		{
			rigidbody.freezeRotation = true;
		}
		TwoDTarget = GameObject.Find("CamFollowPoint").transform;
		TwoDObject = GameObject.Find("TwoD").transform;
	}

	public void LateUpdate()
	{
		if (LookAtEnabled && (bool)target)
		{
			if (smooth)
			{
				Quaternion to = Quaternion.LookRotation(target.position - transform.position);
				transform.rotation = Quaternion.Slerp(transform.rotation, to, Time.deltaTime * damping);
			}
			else
			{
				transform.LookAt(target);
			}
		}
		if (!(TimeOnCam < 0f))
		{
			TimeOnCam -= Time.deltaTime;
			if (TimeOnCam < 0f)
			{
				GameObject.Find("WhiteFade").SendMessage("setFadeIn");
				StartCoroutine_Auto(delayFollow());
			}
		}
	}

	public IEnumerator delayFollow()
	{
		return new delayFollow$2(this).GetEnumerator();
	}

	public void enableLookAt()
	{
		checked
		{
			if (!LookAtEnabled)
			{
				LookAtEnabled = true;
				PositionCount++;
				TimeOnCam = 2.5f;
			}
		}
	}

	public void lookAt2D()
	{
		target = TwoDObject;
	}

	public void enablePanLook()
	{
		LookAtEnabled = true;
		target = TwoDTarget;
		GameObject.Find("CamFollowPoint").SendMessage("makeActive");
	}

	public void disableLookAt()
	{
		LookAtEnabled = false;
	}

	public void defaultTarget()
	{
		target = Glider;
	}

	public void Main()
	{
	}
}
