// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Tutorial
using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class Tutorial : MonoBehaviour
{
	private GameObject Player;

	private bool Collided;

	public Transform TutorialObject;

	public void Update()
	{
	}

	public void OnTriggerEnter(Collider other)
	{
		if (!Collided)
		{
			Player = other.gameObject;
			Collided = true;
			UnityRuntimeServices.Invoke(Camera.main.GetComponent("SmoothLookAt"), "changeTarget", new object[1] { TutorialObject }, typeof(MonoBehaviour));
		}
	}

	public void Main()
	{
	}
}
