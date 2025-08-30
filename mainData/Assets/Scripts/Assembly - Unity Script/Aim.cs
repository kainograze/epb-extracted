// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Aim
using System;
using UnityEngine;

[Serializable]
public class Aim : MonoBehaviour
{
	public void Update()
	{
	}

	public void OnGUI()
	{
		if (GUI.Button(new Rect(5f, checked(Screen.height - 55), 50f, 50f), "AIM"))
		{
			Camera.main.SendMessage("toggleAim");
			gameObject.BroadcastMessage("toggleHide");
		}
	}

	public void Main()
	{
	}
}
