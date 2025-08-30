// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// IconGUI
using System;
using UnityEngine;

[Serializable]
public class IconGUI : MonoBehaviour
{
	public GUITexture gui;

	public float guiHeight;

	public int HeightAboveTarget;

	private bool Disabled;

	public IconGUI()
	{
		guiHeight = 2f;
		HeightAboveTarget = 40;
	}

	public void Update()
	{
		if (Disabled)
		{
			return;
		}
		Camera main = Camera.main;
		float magnitude = (main.transform.position - transform.position).magnitude;
		if (!main)
		{
			Debug.Log("no camera in the scene");
		}
		if (magnitude < 1500f)
		{
			Vector3 position = transform.position;
			position.y += HeightAboveTarget;
			Vector3 vector = main.transform.InverseTransformPoint(transform.position);
			Vector3 position2 = main.WorldToViewportPoint(position + Vector3.up * guiHeight);
			gui.transform.position = position2;
			Vector3 lhs = main.transform.TransformDirection(Vector3.forward);
			Vector3 rhs = transform.position - main.transform.position;
			if (Vector3.Dot(lhs, rhs) < 0f)
			{
				gui.enabled = false;
			}
			else
			{
				gui.enabled = true;
			}
		}
		else
		{
			gui.enabled = false;
		}
	}

	public void disableIcon()
	{
		Disabled = true;
		gui.enabled = false;
	}

	public void Main()
	{
	}
}
