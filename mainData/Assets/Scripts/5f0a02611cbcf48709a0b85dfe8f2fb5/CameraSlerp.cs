using System;
using UnityEngine;

[Serializable]
public class CameraSlerp : MonoBehaviour
{
	public Vector3 CurrentStart;
	public Vector3 CurrentEnd;
	public Vector3[] StartPositions;
	public Vector3[] EndPositions;
	public Vector3[] CentreOffSet;
	public bool SlerpCam;
}
