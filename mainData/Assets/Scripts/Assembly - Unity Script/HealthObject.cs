// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// HealthObject
using System;
using UnityEngine;

[Serializable]
public class HealthObject : MonoBehaviour
{
	public void OnTriggerEnter(Collider other)
	{
		other.gameObject.SendMessage("healthCollected");
		UnityEngine.Object.Destroy(gameObject);
	}

	public void Main()
	{
	}
}
