// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MakeBlack
using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class MakeBlack : MonoBehaviour
{
	public bool Only1stTexture;

	public void Update()
	{
	}

	public void makeBlack()
	{
		if (!Only1stTexture)
		{
			for (int i = 0; i < Extensions.get_length((System.Array)renderer.materials); i = checked(i + 1))
			{
				Material[] materials = renderer.materials;
				materials[RuntimeServices.NormalizeArrayIndex(materials, i)].color = Color.black;
			}
		}
		else
		{
			renderer.materials[0].color = Color.black;
		}
	}

	public void Main()
	{
	}
}
