// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// FlightReadOuts
using System;
using UnityEngine;

[Serializable]
public class FlightReadOuts : MonoBehaviour
{
	private bool Control;

	private int Health;

	private GameObject PlayerGUI;

	public int SeaLevel;

	public FlightReadOuts()
	{
		Control = true;
		SeaLevel = -32;
	}

	public void Start()
	{
		PlayerGUI = GameObject.Find("GameGUI");
	}

	public void Update()
	{
	}

	public void OnGUI()
	{
		int num = checked((int)Mathf.Round(transform.position.y - (float)SeaLevel));
		PlayerGUI.BroadcastMessage("updateAltimeter", num);
		PlayerGUI.BroadcastMessage("updateSpeed", Mathf.Round(rigidbody.velocity.magnitude));
	}

	public void turnControlOff()
	{
		Control = false;
	}

	public void turnControlOn()
	{
		Control = true;
	}

	public void setGUIHealth(object inHealth)
	{
		PlayerGUI.SendMessage("healthChange", inHealth);
	}

	public void enemyTargetted(string inString)
	{
		PlayerGUI.BroadcastMessage("receiveEnemyType", inString);
	}

	public void bonusCollected(object inID)
	{
		PlayerGUI.BroadcastMessage("bonusCollected", inID);
	}

	public void Main()
	{
	}
}
