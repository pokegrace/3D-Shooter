using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script to manage health of enemy
// code from: https://www.youtube.com/watch?v=npSkMTEe2BI&index=6&list=PLiyfvmtjWC_XBKJVuCtMXrkNnMDNB16W9
public class enemyHealthManager : MonoBehaviour {

	public int health;
	private int currentHealth;

	// to make enemy flash if hurt
	public float flashLength;
	private float flashCounter;

	private Renderer rend;
	private Color storedColor;

	// to keep score
	public int pointScored;

	// Use this for initialization
	void Start () {

		currentHealth = health;

		rend = GetComponent<Renderer> ();

		// store original enemy material color
		storedColor = rend.material.GetColor("_Color");

	}
	
	// Update is called once per frame
	void Update () {

		// if our current health is below 0, destroy enemy
		if (currentHealth <= 0) 
		{
			Destroy (gameObject);
			scoreManager.Score += pointScored;
		}

		// makes enemy flash color
		if (flashCounter > 0) 
		{
			flashCounter -= Time.deltaTime;

			if (flashCounter <= 0) 
			{
				rend.material.SetColor ("_Color", storedColor);
			}

		}
	}

	public void HurtEnemy(int damage){

		currentHealth -= damage;
		flashCounter = flashLength;
		rend.material.SetColor ("_Color", Color.white);
	}
}
