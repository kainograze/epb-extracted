// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Balloon
using System;
using UnityEngine;

[Serializable]
public class Balloon : MonoBehaviour
{
	public Transform Explosion;

	public Transform ContainedItem;

	public int Health;

	public Transform ExplodeSound;

	private GameObject ScoreObject;

	public Balloon()
	{
		Health = 1;
	}

	public void Start()
	{
		ScoreObject = GameObject.Find("Score");
	}

	public void Update()
	{
	}

	public void lockedOn()
	{
		renderer.material.color = Color.red;
	}

	public void Hit()
	{
		checked
		{
			Health--;
			if (Health <= 0)
			{
				popBalloon();
			}
		}
	}

	public void popBalloon()
	{
		transform.parent.SendMessage("balloonPopped");
		UnityEngine.Object.Instantiate(ExplodeSound, transform.position, Quaternion.identity);
		UnityEngine.Object.Instantiate(Explosion, transform.position, Quaternion.identity);
		UnityEngine.Object.Destroy(gameObject);
	}

	public void OnTriggerEnter(Collider other)
	{
		popBalloon();
	}

	public void Main()
	{
	}
}
