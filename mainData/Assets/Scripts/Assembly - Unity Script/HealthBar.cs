// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// HealthBar
using System;
using UnityEngine;

[Serializable]
public class HealthBar : MonoBehaviour
{
	public float BarLength;

	public float TotalHealth;

	public HealthBar()
	{
		BarLength = 178f;
		TotalHealth = 5f;
	}

	public void Start()
	{
		checked
		{
			guiTexture.pixelInset = new Rect(unchecked(Screen.width * -1 / 2) + 45, unchecked(Screen.height / 2) - 21, BarLength, 19f);
		}
	}

	public void updateHealthBar(int inHealth)
	{
		float num = default(float);
		num = (float)inHealth / TotalHealth * BarLength;
		num = Mathf.Round(num);
		checked
		{
			guiTexture.pixelInset = new Rect(unchecked(Screen.width * -1 / 2) + 45, unchecked(Screen.height / 2) - 23, num, 19f);
		}
	}

	public void turnGUIOff()
	{
		guiTexture.enabled = false;
	}

	public void turnGUIOn()
	{
		guiTexture.enabled = true;
	}

	public void alignGUI()
	{
		checked
		{
			guiTexture.pixelInset = new Rect(unchecked(Screen.width * -1 / 2) + 45, unchecked(Screen.height / 2) - 21, BarLength, 19f);
		}
	}

	public void Main()
	{
	}
}
