// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// HealthFace
using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class HealthFace : MonoBehaviour
{
	public int ID;

	public void Start()
	{
	}

	public void changeFace(object inID)
	{
		if (RuntimeServices.EqualityOperator(inID, ID))
		{
			int num = 1;
			Color color = guiTexture.color;
			float num2 = (color.a = num);
			Color color2 = (guiTexture.color = color);
		}
		else
		{
			int num3 = 0;
			Color color4 = guiTexture.color;
			float num4 = (color4.a = num3);
			Color color5 = (guiTexture.color = color4);
		}
	}

	public void Main()
	{
	}
}
