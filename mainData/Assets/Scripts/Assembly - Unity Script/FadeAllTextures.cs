// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// FadeAllTextures
using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class FadeAllTextures : MonoBehaviour
{
	private bool FadeOut;

	public void Update()
	{
		if (FadeOut)
		{
			for (int i = 0; i < Extensions.get_length((System.Array)renderer.materials); i = checked(i + 1))
			{
				Material[] materials = renderer.materials;
				float a = materials[RuntimeServices.NormalizeArrayIndex(materials, i)].color.a - Time.deltaTime;
				Material[] materials2 = renderer.materials;
				Color color = materials2[RuntimeServices.NormalizeArrayIndex(materials2, i)].color;
				float num = (color.a = a);
				Material[] materials3 = renderer.materials;
				Color color2 = (materials3[RuntimeServices.NormalizeArrayIndex(materials3, i)].color = color);
			}
			if (renderer.materials[0].color.a < 0f)
			{
				UnityEngine.Object.Destroy(transform.parent.gameObject);
			}
		}
	}

	public void fadeOut()
	{
		FadeOut = true;
	}

	public void Main()
	{
	}
}
