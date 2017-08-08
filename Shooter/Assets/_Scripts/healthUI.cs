using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script to display player's health
public class healthUI : MonoBehaviour {

	public static int playerHealth = 20;

	// displaying the score
	void OnGUI()
	{
		GUI.Box (new Rect (450, 50, 50, 50), "Health \n" + playerHealth.ToString ());
	}
}
