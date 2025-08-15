using System;
using UnityEngine;

[Serializable]
public class Mine : MonoBehaviour
{
	public bool AltitudeCheck;
	public Transform Explosion;
	public int SeaLevel;
	public int FlightSpeed;
	public GameObject TargetHit;
	public Transform MineWaterExplodeAudio;
}
