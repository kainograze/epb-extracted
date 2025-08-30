// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// EnemyHealth
using System;
using UnityEngine;

[Serializable]
public class EnemyHealth : MonoBehaviour
{
	private float DisplayTimer;

	private int BarWidth;

	public float DisplayTime;

	private string DisplayName;

	private Rect BarDimensions;

	public GUIStyle NormalCartoonText;

	public Texture2D NameBackground;

	public void Start()
	{
		float num = guiTexture.pixelInset.width * -1f / 2f;
		Rect pixelInset = guiTexture.pixelInset;
		float num2 = (pixelInset.x = num);
		Rect rect = (guiTexture.pixelInset = pixelInset);
		int num4 = Screen.height / 10;
		Rect pixelInset2 = guiTexture.pixelInset;
		float num5 = (pixelInset2.y = num4);
		Rect rect3 = (guiTexture.pixelInset = pixelInset2);
		BarDimensions = guiTexture.pixelInset;
		BarWidth = checked((int)guiTexture.pixelInset.width);
	}

	public void Update()
	{
		if (DisplayTimer > 0f)
		{
			DisplayTimer -= Time.deltaTime;
			if (DisplayTimer < 1f)
			{
				float displayTimer = DisplayTimer;
				Color color = guiTexture.color;
				float num = (color.a = displayTimer);
				Color color2 = (guiTexture.color = color);
			}
		}
	}

	public void OnGUI()
	{
		checked
		{
			if (DisplayTimer > 0.5f)
			{
				GUI.DrawTexture(new Rect(unchecked(Screen.width / 2) - 64, (float)Screen.height / 3.43f, 128f, 32f), NameBackground);
				GUI.Box(new Rect(unchecked(Screen.width / 2) - 100, (float)Screen.height / 3.3f, 200f, 40f), DisplayName, NormalCartoonText);
			}
		}
	}

	public void enemyHit(float inPercentage)
	{
		DisplayTimer = DisplayTime;
		if (!(inPercentage > 0f))
		{
			inPercentage = 0f;
			DisplayTimer = 0f;
		}
		int num = 1;
		Color color = guiTexture.color;
		float num2 = (color.a = num);
		Color color2 = (guiTexture.color = color);
		BarDimensions.width = inPercentage * (float)BarWidth;
		guiTexture.pixelInset = BarDimensions;
	}

	public void receiveEnemyType(string inString)
	{
		DisplayName = inString;
	}

	public void alignGUI()
	{
		float num = guiTexture.pixelInset.width * -1f / 2f;
		Rect pixelInset = guiTexture.pixelInset;
		float num2 = (pixelInset.x = num);
		Rect rect = (guiTexture.pixelInset = pixelInset);
		int num4 = Screen.height / 10;
		Rect pixelInset2 = guiTexture.pixelInset;
		float num5 = (pixelInset2.y = num4);
		Rect rect3 = (guiTexture.pixelInset = pixelInset2);
		BarDimensions = guiTexture.pixelInset;
		BarWidth = checked((int)guiTexture.pixelInset.width);
	}

	public void Main()
	{
	}
}
