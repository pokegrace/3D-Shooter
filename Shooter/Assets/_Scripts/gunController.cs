using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script used to control player's gun
// code from: https://www.youtube.com/watch?v=JVibUZugFAQ&index=2&list=PLiyfvmtjWC_XBKJVuCtMXrkNnMDNB16W9
public class gunController : MonoBehaviour {

	public bool isFiring;

	public bulletController bullet;
	public float bulletSpeed; 

	public float timeBetweenShots;
	private float shotCounter;

	public Transform firePoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (isFiring) {
			// shotCounter counting down the whole time
			shotCounter -= Time.deltaTime;

			if (shotCounter <= 0) {
				// resetting shotCounter to full time
				shotCounter = timeBetweenShots;
				// creating bullet with all the properties of bulletController
				bulletController newBullet = Instantiate (bullet, firePoint.position, firePoint.rotation) as bulletController;
				newBullet.bulletSpeed = bulletSpeed;
			}
		} else {
			shotCounter = 0;
		}

	}
}
