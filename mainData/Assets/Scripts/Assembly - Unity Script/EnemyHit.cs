// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// EnemyHit
using System;
using UnityEngine;

[Serializable]
public class EnemyHit : MonoBehaviour
{
	public Transform Explosion;

	public int Health;

	public int ScoreID;

	private GameObject ScoreObject;

	public EnemyHit()
	{
		Health = 1;
		ScoreID = 11;
	}

	public void Start()
	{
		ScoreObject = GameObject.Find("Score");
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
			UnityEngine.Object.Instantiate(Explosion, transform.position, Quaternion.identity);
			if (Health <= 0)
			{
				if (ScoreID > 0)
				{
					ScoreObject.SendMessage("sendScore", ScoreID);
				}
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}

	public void Main()
	{
	}
}
