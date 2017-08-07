using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script to control bullet movement
// code from: https://www.youtube.com/watch?v=JVibUZugFAQ&index=2&list=PLiyfvmtjWC_XBKJVuCtMXrkNnMDNB16W9
public class bulletController : MonoBehaviour {

	public float bulletSpeed;
	public float lifetime;

	public int bulletDamage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// go forward at bulletSpeed at whichever direction player is facing
		transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime); 

		// destroy bullet after certain amount of time
		lifetime -= Time.deltaTime;
		if (lifetime <= 0)
			Destroy (gameObject);
	}

	// when bullet collides with enemy, deal damage
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "enemy") 
		{
			other.gameObject.GetComponent<enemyHealthManager> ().HurtEnemy (bulletDamage);

			// bullet will destroy when colliding with enemy
			Destroy (gameObject);
		}
	}
}
