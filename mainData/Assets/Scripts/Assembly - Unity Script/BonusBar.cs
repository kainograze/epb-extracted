// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// BonusBar
using System;
using UnityEngine;

[Serializable]
public class BonusBar : MonoBehaviour
{
	public void Update()
	{
	}

	public void bonusCollected(int inID)
	{
		BroadcastMessage("bonusOn", inID);
	}

	public void turnGUIOff()
	{
		BroadcastMessage("bonusesOff");
	}

	public void turnGUIOn()
	{
		BroadcastMessage("bonusesOn");
	}

	public void Main()
	{
	}
}
