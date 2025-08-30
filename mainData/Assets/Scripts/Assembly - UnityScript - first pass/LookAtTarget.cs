// d4e5115e396b84ea8820f5b0a8f12827, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// LookAtTarget
using System;
using UnityEngine;

[Serializable]
public class LookAtTarget : MonoBehaviour
{
	private Transform TwoD;

	private bool HavinALook;

	private bool HaveAPan;

	public Transform EscapePos;

	public void Update()
	{
		if (HavinALook)
		{
			transform.LookAt(TwoD);
			if (HaveAPan)
			{
				float z = transform.position.z - Time.deltaTime * 25f;
				Vector3 position = transform.position;
				float num = (position.z = z);
				Vector3 vector = (transform.position = position);
			}
		}
	}

	public void haveALookAt2D()
	{
		TwoD = GameObject.Find("TwoD").transform;
		HavinALook = true;
		HaveAPan = true;
		transform.position = TwoD.position;
		float y = transform.position.y + 350f;
		Vector3 position = transform.position;
		float num = (position.y = y);
		Vector3 vector = (transform.position = position);
		float x = transform.position.x + 300f;
		Vector3 position2 = transform.position;
		float num2 = (position2.x = x);
		Vector3 vector3 = (transform.position = position2);
		float z = transform.position.z + 100f;
		Vector3 position3 = transform.position;
		float num3 = (position3.z = z);
		Vector3 vector5 = (transform.position = position3);
		SendMessage("disableFollow");
	}

	public void stopHavinALook()
	{
		HavinALook = false;
		SendMessage("enableFollow");
	}

	public void escapeCutScene()
	{
		transform.position = EscapePos.position;
		TwoD = GameObject.Find("TwoD").transform;
		HavinALook = true;
		HaveAPan = false;
		int num = 230;
		Vector3 eulerAngles = transform.eulerAngles;
		float num2 = (eulerAngles.y = num);
		Vector3 vector = (transform.eulerAngles = eulerAngles);
		SendMessage("disableFollow");
	}

	public void Main()
	{
	}
}
