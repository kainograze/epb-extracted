using System;
using UnityEngine;

[Serializable]
public class Positions : MonoBehaviour
{
	public Vector3 BattlePos;
	public Quaternion BattleRot;
	public Vector3 ReturnLegPos;
	public Quaternion ReturnLegRot;
	public Transform[] RespawnPoints;
}
