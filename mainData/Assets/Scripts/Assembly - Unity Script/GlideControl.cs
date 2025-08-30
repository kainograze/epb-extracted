// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// GlideControl

// NOTE: this is NOT the iPhone control, fortunately! This is the WebDemo control.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class GlideControl : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class turnControlOff$72 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class $ : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int $___temp205$414;

			internal Vector3 $___temp206$415;

			internal int $___temp207$416;

			internal Vector3 $___temp208$417;

			internal GlideControl $self_418;

			public $(GlideControl self_)
			{
				$self_418 = self_;
			}

			public override bool MoveNext()
			{
				switch (_state)
				{
				default:
					return Yield(2, new WaitForSeconds(0.25f));
				case 2:
				{
					int num = ($___temp205$414 = 0);
					Vector3 vector = ($___temp206$415 = $self_418.transform.eulerAngles);
					float num2 = ($___temp206$415.x = $___temp205$414);
					Vector3 vector2 = ($self_418.transform.eulerAngles = $___temp206$415);
					int num3 = ($___temp207$416 = 0);
					Vector3 vector4 = ($___temp208$417 = $self_418.transform.eulerAngles);
					float num4 = ($___temp208$417.z = $___temp207$416);
					Vector3 vector5 = ($self_418.transform.eulerAngles = $___temp208$417);
					$self_418.audio.Stop();
					$self_418.BroadcastMessage("audioOff", 1);
					$self_418.Control = false;
					$self_418.rigidbody.isKinematic = true;
					Yield(1, null);
					break;
				}
				case 1:
					break;
				}
				bool result = default(bool);
				return result;
			}
		}

		internal GlideControl $self_419;

		public turnControlOff$72(GlideControl self_)
		{
			$self_419 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new $($self_419);
		}
	}

	public int Speed;

	public float StartSpeed;

	public float VerticalForce;

	public bool iPhoneControl;

	public int RotateSpeedPerSec;

	public int StallFallLimit;

	public int StallFallPull;

	public int StallFallExit;

	public int MinimumForwardSpeed;

	public int MaximumForwardForce;

	public int ThermalForcePerSec;

	public float SpeedGainPerSec;

	public float BoostTime;

	public int SpeedBoost;

	public int ForwardStallPoint;

	public int WindSpeedThreshold;

	private Color StartAmbientLight;

	private bool WindSpeedOn;

	private bool Control;

	private float BoostTimer;

	private bool InThermal;

	private bool LockedHorizontalRotate;

	private bool LockedVerticalRotate;

	private bool FuelOn;

	private int TouchArrayPositionFuel;

	private bool StallMessageSent;

	public GlideControl()
	{
		Speed = 10;
		RotateSpeedPerSec = 30;
		StallFallLimit = 60;
		StallFallPull = 10;
		StallFallExit = 20;
		MinimumForwardSpeed = 10;
		MaximumForwardForce = 125;
		ThermalForcePerSec = 18;
		SpeedGainPerSec = 5f;
		BoostTime = 1f;
		SpeedBoost = 5;
		ForwardStallPoint = 30;
		WindSpeedThreshold = 60;
		Control = true;
		BoostTimer = 0f;
		LockedHorizontalRotate = true;
		LockedVerticalRotate = true;
		FuelOn = false;
	}

	public void Start()
	{
		StartAmbientLight = RenderSettings.ambientLight;
		float z = (float)MaximumForwardForce * 0.75f;
		Vector3 relativeForce = constantForce.relativeForce;
		float num = (relativeForce.z = z);
		Vector3 vector = (constantForce.relativeForce = relativeForce);
	}

	public IEnumerator turnControlOff()
	{
		return new turnControlOff$72(this).GetEnumerator();
	}

	public void turnControlOn()
	{
		BroadcastMessage("audioOn", 1);
		Control = true;
		rigidbody.isKinematic = false;
	}

	public void FixedUpdate()
	{
		if (!rigidbody.isKinematic)
		{
			if (iPhoneControl)
			{
				rotateMovementiPhone();
			}
			else
			{
				rotateMovement();
				balanceOut();
			}
			if (BoostTimer > 0f)
			{
				speedBoost();
			}
		}
		if (constantForce.relativeForce.z < (float)MinimumForwardSpeed)
		{
			int minimumForwardSpeed = MinimumForwardSpeed;
			Vector3 relativeForce = constantForce.relativeForce;
			float num = (relativeForce.z = minimumForwardSpeed);
			Vector3 vector = (constantForce.relativeForce = relativeForce);
		}
		if (constantForce.relativeForce.z < (float)ForwardStallPoint)
		{
			if (!StallMessageSent)
			{
				StallMessageSent = true;
				Camera.main.BroadcastMessage("stallOn");
			}
			float y = constantForce.relativeForce.y - (float)StallFallPull * Time.deltaTime;
			Vector3 relativeForce2 = constantForce.relativeForce;
			float num2 = (relativeForce2.y = y);
			Vector3 vector3 = (constantForce.relativeForce = relativeForce2);
			if (constantForce.relativeForce.y < (float)(StallFallLimit * -1))
			{
				int num3 = StallFallLimit * -1;
				Vector3 relativeForce3 = constantForce.relativeForce;
				float num4 = (relativeForce3.y = num3);
				Vector3 vector5 = (constantForce.relativeForce = relativeForce3);
			}
			if (transform.eulerAngles.x < 50f && transform.eulerAngles.x > 35f)
			{
				float y2 = constantForce.relativeForce.y + (float)StallFallPull * Time.deltaTime;
				Vector3 relativeForce4 = constantForce.relativeForce;
				float num5 = (relativeForce4.y = y2);
				Vector3 vector7 = (constantForce.relativeForce = relativeForce4);
			}
		}
		else
		{
			if (StallMessageSent)
			{
				StallMessageSent = false;
				Camera.main.BroadcastMessage("stallOff");
			}
			if (constantForce.relativeForce.y < 0f)
			{
				int num6 = 0;
				Vector3 relativeForce5 = constantForce.relativeForce;
				float num7 = (relativeForce5.y = num6);
				Vector3 vector9 = (constantForce.relativeForce = relativeForce5);
			}
		}
		if (InThermal)
		{
			if (constantForce.relativeForce.y < 0f)
			{
				int num8 = 0;
				Vector3 relativeForce6 = constantForce.relativeForce;
				float num9 = (relativeForce6.y = num8);
				Vector3 vector11 = (constantForce.relativeForce = relativeForce6);
			}
			constantForce.relativeForce += Vector3.up * ((float)ThermalForcePerSec * Time.deltaTime);
			float z = constantForce.relativeForce.z + Time.deltaTime * 20f;
			Vector3 relativeForce7 = constantForce.relativeForce;
			float num10 = (relativeForce7.z = z);
			Vector3 vector13 = (constantForce.relativeForce = relativeForce7);
		}
		float num11 = default(float);
		if (transform.rotation.eulerAngles.x < 50f)
		{
			num11 = transform.rotation.eulerAngles.x / 15f;
		}
		if (constantForce.relativeForce.z > (float)MaximumForwardForce + num11 * (float)MaximumForwardForce)
		{
			float z2 = (float)MaximumForwardForce + num11 * (float)MaximumForwardForce;
			Vector3 relativeForce8 = constantForce.relativeForce;
			float num12 = (relativeForce8.z = z2);
			Vector3 vector15 = (constantForce.relativeForce = relativeForce8);
		}
		if (WindSpeedOn)
		{
			if (rigidbody.velocity.magnitude < (float)WindSpeedThreshold)
			{
				BroadcastMessage("windSpeedOff");
				WindSpeedOn = false;
			}
		}
		else if (rigidbody.velocity.magnitude > (float)WindSpeedThreshold)
		{
			BroadcastMessage("windSpeedOn");
			WindSpeedOn = true;
		}
	}

	public void balanceOut()
	{
		if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !LockedHorizontalRotate)
		{
			if (transform.eulerAngles.z < 60f)
			{
				float z = transform.eulerAngles.z - Time.deltaTime * 40f;
				Vector3 eulerAngles = transform.eulerAngles;
				float num = (eulerAngles.z = z);
				Vector3 vector = (transform.eulerAngles = eulerAngles);
			}
			if (transform.eulerAngles.z > 300f)
			{
				float z2 = transform.eulerAngles.z + Time.deltaTime * 40f;
				Vector3 eulerAngles2 = transform.eulerAngles;
				float num2 = (eulerAngles2.z = z2);
				Vector3 vector3 = (transform.eulerAngles = eulerAngles2);
			}
			if (Mathf.Abs(transform.eulerAngles.z - 0f) < 1f)
			{
				int num3 = 0;
				Vector3 eulerAngles3 = transform.eulerAngles;
				float num4 = (eulerAngles3.z = num3);
				Vector3 vector5 = (transform.eulerAngles = eulerAngles3);
				LockedHorizontalRotate = true;
			}
		}
		if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !LockedVerticalRotate)
		{
			if (transform.eulerAngles.x < 45f)
			{
				float x = transform.eulerAngles.x - Time.deltaTime * 25f;
				Vector3 eulerAngles4 = transform.eulerAngles;
				float num5 = (eulerAngles4.x = x);
				Vector3 vector7 = (transform.eulerAngles = eulerAngles4);
			}
			if (transform.eulerAngles.x > 325f)
			{
				float x2 = transform.eulerAngles.x + Time.deltaTime * 25f;
				Vector3 eulerAngles5 = transform.eulerAngles;
				float num6 = (eulerAngles5.x = x2);
				Vector3 vector9 = (transform.eulerAngles = eulerAngles5);
			}
			if (Mathf.Abs(transform.eulerAngles.x - 0f) < 1f)
			{
				int num7 = 0;
				Vector3 eulerAngles6 = transform.eulerAngles;
				float num8 = (eulerAngles6.x = num7);
				Vector3 vector11 = (transform.eulerAngles = eulerAngles6);
				LockedVerticalRotate = true;
			}
		}
		if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
		{
			constantForce.force = Vector3.up * 0f;
		}
	}

	public void rotateMovementiPhone()
	{
	}

	public void rotateMovement()
	{
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			float z = transform.eulerAngles.z - 1f;
			Vector3 eulerAngles = transform.eulerAngles;
			float num = (eulerAngles.z = z);
			Vector3 vector = (transform.eulerAngles = eulerAngles);
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			float z2 = transform.eulerAngles.z + 1f;
			Vector3 eulerAngles2 = transform.eulerAngles;
			float num2 = (eulerAngles2.z = z2);
			Vector3 vector3 = (transform.eulerAngles = eulerAngles2);
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			float x = transform.eulerAngles.x + 2f;
			Vector3 eulerAngles3 = transform.eulerAngles;
			float num3 = (eulerAngles3.x = x);
			Vector3 vector5 = (transform.eulerAngles = eulerAngles3);
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			float x2 = transform.eulerAngles.x - 2f;
			Vector3 eulerAngles4 = transform.eulerAngles;
			float num4 = (eulerAngles4.x = x2);
			Vector3 vector7 = (transform.eulerAngles = eulerAngles4);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			LockedHorizontalRotate = false;
			float y = transform.eulerAngles.y - Time.deltaTime * (float)RotateSpeedPerSec;
			Vector3 eulerAngles5 = transform.eulerAngles;
			float num5 = (eulerAngles5.y = y);
			Vector3 vector9 = (transform.eulerAngles = eulerAngles5);
			if (transform.eulerAngles.z < 55f || transform.eulerAngles.z > 305f)
			{
				float z3 = transform.eulerAngles.z + Time.deltaTime * 40f;
				Vector3 eulerAngles6 = transform.eulerAngles;
				float num6 = (eulerAngles6.z = z3);
				Vector3 vector11 = (transform.eulerAngles = eulerAngles6);
			}
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			LockedHorizontalRotate = false;
			float y2 = transform.eulerAngles.y + Time.deltaTime * (float)RotateSpeedPerSec;
			Vector3 eulerAngles7 = transform.eulerAngles;
			float num7 = (eulerAngles7.y = y2);
			Vector3 vector13 = (transform.eulerAngles = eulerAngles7);
			if (transform.eulerAngles.z > 305f || transform.eulerAngles.z < 55f)
			{
				float z4 = transform.eulerAngles.z - Time.deltaTime * 40f;
				Vector3 eulerAngles8 = transform.eulerAngles;
				float num8 = (eulerAngles8.z = z4);
				Vector3 vector15 = (transform.eulerAngles = eulerAngles8);
			}
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			LockedVerticalRotate = false;
			float z5 = constantForce.relativeForce.z + SpeedGainPerSec * Time.deltaTime;
			Vector3 relativeForce = constantForce.relativeForce;
			float num9 = (relativeForce.z = z5);
			Vector3 vector17 = (constantForce.relativeForce = relativeForce);
			if (transform.eulerAngles.x < 40f || transform.eulerAngles.x > 330f)
			{
				float x3 = transform.eulerAngles.x + Time.deltaTime * 40f;
				Vector3 eulerAngles9 = transform.eulerAngles;
				float num10 = (eulerAngles9.x = x3);
				Vector3 vector19 = (transform.eulerAngles = eulerAngles9);
			}
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			LockedVerticalRotate = false;
			if (BoostTimer == 0f && !InThermal)
			{
				float z6 = constantForce.relativeForce.z - SpeedGainPerSec * Time.deltaTime;
				Vector3 relativeForce2 = constantForce.relativeForce;
				float num11 = (relativeForce2.z = z6);
				Vector3 vector21 = (constantForce.relativeForce = relativeForce2);
			}
			if (transform.eulerAngles.x > 330f || transform.eulerAngles.x < 40f)
			{
				float x4 = transform.eulerAngles.x - Time.deltaTime * 30f;
				Vector3 eulerAngles10 = transform.eulerAngles;
				float num12 = (eulerAngles10.x = x4);
				Vector3 vector23 = (transform.eulerAngles = eulerAngles10);
			}
		}
		if (transform.eulerAngles.z > 55f && transform.eulerAngles.z < 170f)
		{
			int num13 = 55;
			Vector3 eulerAngles11 = transform.eulerAngles;
			float num14 = (eulerAngles11.z = num13);
			Vector3 vector25 = (transform.eulerAngles = eulerAngles11);
		}
		if (transform.eulerAngles.z < 330f && transform.eulerAngles.z > 170f)
		{
			int num15 = 330;
			Vector3 eulerAngles12 = transform.eulerAngles;
			float num16 = (eulerAngles12.z = num15);
			Vector3 vector27 = (transform.eulerAngles = eulerAngles12);
		}
		if (transform.eulerAngles.x > 40f && transform.eulerAngles.x < 180f)
		{
			int num17 = 40;
			Vector3 eulerAngles13 = transform.eulerAngles;
			float num18 = (eulerAngles13.x = num17);
			Vector3 vector29 = (transform.eulerAngles = eulerAngles13);
		}
		if (transform.eulerAngles.x < 330f && transform.eulerAngles.x > 180f)
		{
			int num19 = 330;
			Vector3 eulerAngles14 = transform.eulerAngles;
			float num20 = (eulerAngles14.x = num19);
			Vector3 vector31 = (transform.eulerAngles = eulerAngles14);
		}
	}

	public void speedBoost()
	{
		rigidbody.AddRelativeForce(Vector3.forward * Time.deltaTime * 27000f);
		if (constantForce.relativeForce.z < (float)MaximumForwardForce)
		{
			float z = constantForce.relativeForce.z + Time.deltaTime * (float)SpeedBoost;
			Vector3 relativeForce = constantForce.relativeForce;
			float num = (relativeForce.z = z);
			Vector3 vector = (constantForce.relativeForce = relativeForce);
		}
		BoostTimer -= Time.deltaTime;
		if (!(BoostTimer > 0f))
		{
			BroadcastMessage("speedBoostOff");
			gameObject.BroadcastMessage("flameOff");
			BoostTimer = 0f;
			RenderSettings.ambientLight = StartAmbientLight;
		}
	}

	public void boostOff()
	{
		BroadcastMessage("speedBoostOff");
		gameObject.BroadcastMessage("flameOff");
		BoostTimer = 0f;
	}

	public void fuelUse()
	{
	}

	public void fueliPhoneInput()
	{
	}

	public void fuelKeyboardInput()
	{
		if (Input.GetKeyDown("e") && !FuelOn)
		{
			FuelOn = true;
			gameObject.BroadcastMessage("flameOn");
		}
		if (Input.GetKeyUp("e"))
		{
			FuelOn = false;
			gameObject.BroadcastMessage("flameOff");
		}
	}

	public void OnTriggerEnter(Collider Hit)
	{
		if (Hit.gameObject.name == "Thermal")
		{
			Camera.main.BroadcastMessage("thermalOn");
			InThermal = true;
			renderer.material.color = Color.blue;
		}
		else if (Hit.gameObject.name == "SpeedRing")
		{
			BroadcastMessage("speedBoostOn");
			BroadcastMessage("audioOn", 3);
			BoostTimer = BoostTime;
		}
	}

	public void OnTriggerExit(Collider Hit)
	{
		if (Hit.gameObject.name == "Thermal")
		{
			Camera.main.BroadcastMessage("thermalOff");
			InThermal = false;
			int num = 0;
			Vector3 relativeForce = constantForce.relativeForce;
			float num2 = (relativeForce.y = num);
			Vector3 vector = (constantForce.relativeForce = relativeForce);
			renderer.material.color = Color.white;
		}
	}

	public void startFlying()
	{
		BroadcastMessage("audioOn", 5);
	}

	public void Main()
	{
	}
}
