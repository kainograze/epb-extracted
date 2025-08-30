// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// WaterSplash
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class WaterSplash : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class splashTime$47 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float $___temp185$350;

			internal Vector3 $___temp186$351;

			internal float $___temp187$352;

			internal Vector3 $___temp188$353;

			internal float $___temp189$354;

			internal Vector3 $___temp190$355;

			internal float $___temp191$356;

			internal Color $___temp192$357;

			internal WaterSplash $self_358;

			public $(WaterSplash self_)
			{
				$self_358 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				case 2:
				{
					$self_358.Increase = (float)$self_358.SplashSpeed * $self_358.Frequency;
					float num = ($___temp185$350 = $self_358.transform.localScale.z + 3f * $self_358.Increase);
					Vector3 vector = ($___temp186$351 = $self_358.transform.localScale);
					float num2 = ($___temp186$351.z = $___temp185$350);
					Vector3 vector2 = ($self_358.transform.localScale = $___temp186$351);
					float num3 = ($___temp187$352 = $self_358.transform.localScale.x + 1.5f * $self_358.Increase);
					Vector3 vector4 = ($___temp188$353 = $self_358.transform.localScale);
					float num4 = ($___temp188$353.x = $___temp187$352);
					Vector3 vector5 = ($self_358.transform.localScale = $___temp188$353);
					float num5 = ($___temp189$354 = $self_358.transform.localScale.y + 1.5f * $self_358.Increase);
					Vector3 vector7 = ($___temp190$355 = $self_358.transform.localScale);
					float num6 = ($___temp190$355.y = $___temp189$354);
					Vector3 vector8 = ($self_358.transform.localScale = $___temp190$355);
					if (!$self_358.FadeSplash && $self_358.transform.localScale.z > (float)$self_358.RandHeight * 0.85f)
					{
						$self_358.FadeSplash = true;
					}
					if ($self_358.transform.localScale.z > (float)$self_358.RandHeight)
					{
						$self_358.SplashSpeed *= -1;
					}
					if ($self_358.FadeSplash)
					{
						float num7 = ($___temp191$356 = $self_358.renderer.material.color.a - $self_358.Frequency);
						Color color = ($___temp192$357 = $self_358.renderer.material.color);
						float num8 = ($___temp192$357.a = $___temp191$356);
						Color color2 = ($self_358.renderer.material.color = $___temp192$357);
						if ($self_358.renderer.material.color.a < 0f)
						{
							UnityEngine.Object.Destroy($self_358.transform.parent.gameObject);
						}
					}
					return Yield(3, null);
				}
				default:
					if (true)
					{
						return Yield(2, new WaitForSeconds($self_358.Frequency));
					}
					Yield(1, null);
					break;
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal WaterSplash $self_359;

		public splashTime$47(WaterSplash self_)
		{
			$self_359 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_359);
		}
	}

	public int SplashSpeed;

	private bool FadeSplash;

	private int RandZAngle;

	private int RandHeight;

	private Transform TransformRef;

	public float Frequency;

	private float Increase;

	public WaterSplash()
	{
		SplashSpeed = 3;
		Frequency = 0.05f;
	}

	public void Start()
	{
		RandZAngle = UnityEngine.Random.Range(0, 360);
		RandHeight = UnityEngine.Random.Range(2, 9);
		int randZAngle = RandZAngle;
		Vector3 eulerAngles = transform.eulerAngles;
		float num = (eulerAngles.z = randZAngle);
		Vector3 vector = (transform.eulerAngles = eulerAngles);
		TransformRef = transform;
		StartCoroutine("splashTime");
	}

	public IEnumerator splashTime()
	{
		return new splashTime$47(this).GetEnumerator();
	}

	public void Main()
	{
	}
}
