// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Inventory
using System;
using UnityEngine;

[Serializable]
public class Inventory : MonoBehaviour
{
	private float Fuel;

	public Inventory()
	{
		Fuel = 100f;
	}

	public void Update()
	{
	}

	public void collectedFuel(float inAmount)
	{
		Fuel += inAmount;
	}

	public float returnFuel()
	{
		return Fuel;
	}

	public void useFuel(float inAmount)
	{
		Fuel -= inAmount;
	}

	public void OnGUI()
	{
	}

	public void Main()
	{
	}
}
