// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Stall
using System;
using UnityEngine;

[Serializable]
public class Stall : MonoBehaviour
{
	private bool On;

	private bool DisplayGUITip;

	public GUIStyle NormalSizeComicText;

	public Texture2D TextBackground;

	public void Start()
	{
		renderer.material.SetColor("_EmissiveColor", Color.red);
	}

	public void Update()
	{
		if (On)
		{
			float y = Time.time * (0.5f * -1f);
			renderer.material.mainTextureOffset = new Vector2(0f, y);
			if (renderer.material.color.a < 0.5f)
			{
				float a = renderer.material.color.a + Time.deltaTime * 2f;
				Color color = renderer.material.color;
				float num = (color.a = a);
				Color color2 = (renderer.material.color = color);
			}
		}
		if (!On && renderer.material.color.a > 0f)
		{
			float a2 = renderer.material.color.a - Time.deltaTime * 2f;
			Color color4 = renderer.material.color;
			float num2 = (color4.a = a2);
			Color color5 = (renderer.material.color = color4);
		}
	}

	public void stallOn()
	{
		DisplayGUITip = true;
		On = true;
	}

	public void stallOff()
	{
		DisplayGUITip = false;
		On = false;
	}

	public void OnGUI()
	{
		checked
		{
			if (DisplayGUITip)
			{
				GUI.DrawTexture(new Rect(unchecked(Screen.width / 2) - 160, unchecked(Screen.height / 2) + unchecked(Screen.height / 4) - 15, 320f, 72f), TextBackground);
				GUI.Box(new Rect(unchecked(Screen.width / 2) - 100, unchecked(Screen.height / 2) + unchecked(Screen.height / 4), 200f, 60f), "Dive to prevent Stall!", NormalSizeComicText);
			}
		}
	}

	public void Main()
	{
	}
}
