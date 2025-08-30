// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MenuGUITemp
using System;
using UnityEngine;

[Serializable]
public class MenuGUITemp : MonoBehaviour
{
	public Transform Music;

	public void Start()
	{
		UnityEngine.Object.Instantiate(Music, transform.position, Quaternion.identity);
	}

	public void Main()
	{
	}
}
