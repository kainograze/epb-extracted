// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// ItemCollider
using System;
using UnityEngine;

[Serializable]
public class ItemCollider : MonoBehaviour
{
	public GameObject LevelControl;

	public void OnTriggerEnter(Collider Hit)
	{
		if (Hit.gameObject.name == "Rubbish")
		{
			UnityEngine.Object.Destroy(Hit.gameObject);
			LevelControl.SendMessage("rubbishCollected");
		}
	}

	public void Main()
	{
	}
}
