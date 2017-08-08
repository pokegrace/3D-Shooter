using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script used to make camera follow player
// code from https://www.youtube.com/watch?v=Ta7v27yySKs
public class cameraManager : MonoBehaviour {


	// what the camera will be looking at
	public Transform lookAt;
	// the transform of the camera
	public Transform camTransform;

	private Camera cam;

	// distance between player and camera
	private float distance = 10.0f;

	// used to calculate position
	private float currentX = 0.0f;
	private float currentY = 0.0f;
	private float sensivityX = 4.0f;
	private float sensivityY = 1.0f;

	private void Start()
	{
		camTransform = transform;
		cam = Camera.main;
	}

	// late update will enable us to calculate position of camera AFTER player moves
	private void LateUpdate()
	{
		Vector3 dir = new Vector3 (0, 10, -4);
		Quaternion rotation = Quaternion.Euler (currentY, currentX, 0);

		// placing camera right above player position, then applying the angle
		camTransform.position = lookAt.position + rotation * dir;
	}
}
