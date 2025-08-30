// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// PirateBoat
using System;
using UnityEngine;

[Serializable]
public class PirateBoat : MonoBehaviour
{
	public int Distance;

	public GameObject Target;

	public PirateBoat()
	{
		Distance = 1500;
	}

	public void Start()
	{
		int num = 0;
		Color color = renderer.material.color;
		float num2 = (color.a = num);
		Color color2 = (renderer.material.color = color);
	}

	public void Update()
	{
		if (!Target)
		{
		}
	}

	public void Main()
	{
	}
}
