using System;
using UnityEngine;

[Serializable]
public class GlideControl : MonoBehaviour
{
	public int Speed;
	public float StartSpeed;
	public float VerticalForce;
	public bool iPhoneControl;
	public bool iPhoneStick;
	public bool iPhoneDPad;
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
	public Matrix4x4 calibrationMatrix;
}
