// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MissileControl(Tone)
using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class MissileControl(Tone) : MonoBehaviour
{
	public void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo = default(RaycastHit);
		if (Input.GetMouseButton(0) && Physics.Raycast(ray, out hitInfo, 1000f))
		{
			MonoBehaviour.print(RuntimeServices.GetProperty(RuntimeServices.GetProperty(hitInfo.collider, "gameObject"), "name"));
		}
	}

	public void Main()
	{
	}
}
