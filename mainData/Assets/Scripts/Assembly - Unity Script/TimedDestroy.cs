// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// TimedDestroy
using System;
using UnityEngine;

[Serializable]
public class TimedDestroy : MonoBehaviour
{
	private float LifeSpanTimer;

	public int LifeSpan;

	public TimedDestroy()
	{
		LifeSpan = 15;
	}

	public void Update()
	{
		LifeSpanTimer += Time.deltaTime;
		if (LifeSpanTimer > (float)LifeSpan)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
		if (LifeSpanTimer > (float)checked(LifeSpan - 2))
		{
			float a = ((float)LifeSpan - LifeSpanTimer) / 2f;
			Color color = renderer.material.color;
			float num = (color.a = a);
			Color color2 = (renderer.material.color = color);
		}
	}

	public void Main()
	{
	}
}
