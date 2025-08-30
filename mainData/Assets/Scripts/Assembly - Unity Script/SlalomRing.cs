// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// SlalomRing
using System;
using UnityEngine;

[Serializable]
public class SlalomRing : MonoBehaviour
{
	public Transform SlalomRingAudio;

	public void Update()
	{
	}

	public void destroy()
	{
		UnityEngine.Object.Instantiate(SlalomRingAudio, transform.position, Quaternion.identity);
		UnityEngine.Object.Destroy(transform.parent.gameObject);
	}

	public void Main()
	{
	}
}
