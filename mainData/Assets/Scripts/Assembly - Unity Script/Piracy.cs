// b0ccb79dce9874e36b47331c15528183, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Piracy
using System;
using UnityEngine;

[Serializable]
public class Piracy : MonoBehaviour
{
	public void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
		bool flag = false;
		string rhs = "gorillaz.com";
		string rhs2 = "http://gorillaz.com/plastic-beach-experience/Escape-To-Plastic-Beach-BETA";
		Application.ExternalEval("if(document.location.host != \"" + rhs + "\") {  document.location=\"" + rhs2 + "\"; }");
	}

	public void Main()
	{
	}
}
