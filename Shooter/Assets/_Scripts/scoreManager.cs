using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script manages player score
public class scoreManager : MonoBehaviour {

	public static int Score = 0;

	// displaying the score
	void OnGUI()
	{
		GUI.Box (new Rect (50, 50, 50, 50), "Score \n" + Score.ToString ());
	}
}
