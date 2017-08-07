using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script to control enemy movement
// code from: https://www.youtube.com/watch?v=2LQ27NV_bpQ&index=5&list=PLiyfvmtjWC_XBKJVuCtMXrkNnMDNB16W9
public class enemyController : MonoBehaviour {

	private Rigidbody rb;

	public float enemySpeed;
	public playerMovement player;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();
		player = FindObjectOfType<playerMovement> ();

	}
	
	// Update is called once per frame
	void Update () {

		// to make enemy look at the player
		transform.LookAt (player.transform.position);
	}

	void FixedUpdate(){

		// putting velocity on rigidbody
		rb.velocity = (transform.forward * enemySpeed);

	}
}
