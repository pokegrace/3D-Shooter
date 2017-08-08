using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// script to manage player health
// code from: gamesplusjames
public class playerHealthManager : MonoBehaviour {

	private int currentHealth;

	// to make player flash if hurt
	public float flashLength;
	private float flashCounter;

	private Renderer rend;
	private Color storedColor;

	// Use this for initialization
	void Start () {

		currentHealth = 20;

		rend = GetComponent<Renderer> ();

		// store original player material color
		storedColor = rend.material.GetColor("_Color");

	}
	
	// Update is called once per frame
	void Update () {

		if (currentHealth <= 0) 
		{
			SceneManager.LoadScene ("gameOver");
		}

		// makes player flash color
		if (flashCounter > 0) 
		{
			flashCounter -= Time.deltaTime;

			if (flashCounter <= 0) 
			{
				rend.material.SetColor ("_Color", storedColor);
			}

		}


	}

	// manage color flash and health
	public void HurtPlayer(int damageAmount)
	{
		currentHealth -= damageAmount;
		flashCounter = flashLength;
		rend.material.SetColor ("_Color", Color.red);

		healthUI.playerHealth -= damageAmount;
	}
}
