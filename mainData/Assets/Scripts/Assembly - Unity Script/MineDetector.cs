// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MineDetector
using System;
using UnityEngine;

[Serializable]
public class MineDetector : MonoBehaviour
{
	public void Start()
	{
		renderer.material.color = Color.yellow;
		float a = 0.2f;
		Color color = renderer.material.color;
		float num = (color.a = a);
		Color color2 = (renderer.material.color = color);
	}

	public void Update()
	{
	}

	public void OnTriggerEnter(Collider Other)
	{
		if (Other.gameObject.name == "GlideController")
		{
			transform.parent.SendMessage("Explode");
		}
	}

	public void destroyDetector()
	{
		UnityEngine.Object.Destroy(gameObject);
	}

	public void Main()
	{
	}
}
