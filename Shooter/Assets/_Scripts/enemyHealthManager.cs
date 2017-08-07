using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script to manage health of enemy
// code from: https://www.youtube.com/watch?v=npSkMTEe2BI&index=6&list=PLiyfvmtjWC_XBKJVuCtMXrkNnMDNB16W9
public class enemyHealthManager : MonoBehaviour {

	public int health;
	private int currentHealth;

	// Use this for initialization
	void Start () {

		currentHealth = health;

	}
	
	// Update is called once per frame
	void Update () {

		// if our current health is below 0, destroy enemy
		if (currentHealth <= 0) 
		{
			Destroy (gameObject);
		}
	}

	public void HurtEnemy(int damage){

		currentHealth -= damage;
	}
}
