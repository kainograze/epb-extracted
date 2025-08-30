// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// EnemyNameDisplay
using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class EnemyNameDisplay : MonoBehaviour
{
	private float DisplayTimer;

	private bool Disabled;

	public EnemyNameDisplay()
	{
		Disabled = true;
	}

	public void Start()
	{
		float num = guiTexture.pixelInset.width * -1f / 2f;
		Rect pixelInset = guiTexture.pixelInset;
		float num2 = (pixelInset.x = num);
		Rect rect = (guiTexture.pixelInset = pixelInset);
		int num4 = Screen.height / 7;
		Rect pixelInset2 = guiTexture.pixelInset;
		float num5 = (pixelInset2.y = num4);
		Rect rect3 = (guiTexture.pixelInset = pixelInset2);
		guiTexture.enabled = false;
	}

	public void Update()
	{
		if (DisplayTimer > 0f)
		{
			DisplayTimer -= Time.deltaTime;
		}
		else if (!Disabled)
		{
			Disabled = true;
			guiTexture.enabled = false;
		}
	}

	public void displayNameBackground(object inTime)
	{
		DisplayTimer = RuntimeServices.UnboxSingle(inTime);
		Disabled = false;
		guiTexture.enabled = true;
	}

	public void alignGUI()
	{
		float num = guiTexture.pixelInset.width * -1f / 2f;
		Rect pixelInset = guiTexture.pixelInset;
		float num2 = (pixelInset.x = num);
		Rect rect = (guiTexture.pixelInset = pixelInset);
		int num4 = Screen.height / 7;
		Rect pixelInset2 = guiTexture.pixelInset;
		float num5 = (pixelInset2.y = num4);
		Rect rect3 = (guiTexture.pixelInset = pixelInset2);
		guiTexture.enabled = false;
	}

	public void Main()
	{
	}
}
