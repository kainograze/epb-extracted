// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Drop
using System;
using UnityEngine;

[Serializable]
public class Drop : MonoBehaviour
{
	public bool AltitudeCheck;

	public int SeaLevel;

	public Drop()
	{
		SeaLevel = -32;
	}

	public void Update()
	{
		if (AltitudeCheck && transform.position.y < (float)SeaLevel)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	public void altitudeCheck()
	{
		AltitudeCheck = true;
	}

	public void Main()
	{
	}
}
