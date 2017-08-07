using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// controls player movement
// code from: https://www.youtube.com/watch?v=lkDGk3TjsIE&list=PLiyfvmtjWC_XBKJVuCtMXrkNnMDNB16W9
public class playerMovement : MonoBehaviour {

	public float moveSpeed;
	private Rigidbody rb;

	private Vector3 moveInput;
	private Vector3 moveVelocity;

	private Camera mainCamera;

	public gunController theGun;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();
		mainCamera = FindObjectOfType<Camera> ();

	}
	
	// Update is called once per frame
	void Update () {

		// since this is 3D, 'z' value will move player "up" and "down"; y-value will move player into sky
		moveInput = new Vector3 (Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
		// determining velocity 
		moveVelocity = moveInput * moveSpeed;

		// to handle player looking at mouse position
		// creating a ray from camera to wherever mouse currently is
		Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
		// creating an abstract plane facing up at position 0 - for raycast to hit
		Plane groundPlane = new Plane (Vector3.up, Vector3.zero);

		float rayLength;

		// if raycast hits another object in the world (and measure ray length)
		if (groundPlane.Raycast (cameraRay, out rayLength)) 
		{			
			// create a point to look at 
			Vector3 pointToLook = cameraRay.GetPoint (rayLength);
			// for debugging purposes
			Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

			// actually making player look at the mouse position, at the SAME level (y is constant)
			transform.LookAt (new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
		}

		// activating/deactivating gun
		if (Input.GetMouseButtonDown (0)) 
			theGun.isFiring = true;
		
		if (Input.GetMouseButtonUp (0))
			theGun.isFiring = false;
	}

	// fixed update will always be the same, no matter what frame rate, etc.
	// use this for consistency in physics forces (movement)
	void FixedUpdate () {

		// setting rigidbody velocity to what we declared in Update
		rb.velocity = moveVelocity;

	}

}
