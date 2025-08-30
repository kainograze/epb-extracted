// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// PanTo2D
using System;
using UnityEngine;

[Serializable]
public class PanTo2D : MonoBehaviour
{
	private Transform Target;

	public float PanSpeed;

	private Vector3 targetDir;

	private bool Active;

	public void Start()
	{
		Target = GameObject.Find("TwoD").transform;
	}

	public void Update()
	{
		if (Active)
		{
			targetDir = Target.position - transform.position;
			if (targetDir.magnitude < 3f)
			{
				Active = false;
				Camera.main.SendMessage("lookAt2D");
				Camera.main.SendMessage("zoomToTarget");
			}
			targetDir.Normalize();
			transform.position += targetDir * PanSpeed * Time.deltaTime * 330f;
		}
	}

	public void makeActive()
	{
		transform.position = Camera.main.transform.position;
		int num = 0;
		Vector3 position = transform.position;
		float num2 = (position.y = num);
		Vector3 vector = (transform.position = position);
		Active = true;
	}

	public void Main()
	{
	}
}
