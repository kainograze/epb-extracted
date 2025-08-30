// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// PirateBoatColliders
using System;
using UnityEngine;

[Serializable]
public class PirateBoatColliders : MonoBehaviour
{
	public void Hit()
	{
		transform.parent.transform.parent.SendMessage("Hit");
	}

	public void Main()
	{
	}
}
