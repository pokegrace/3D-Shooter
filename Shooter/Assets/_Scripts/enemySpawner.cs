using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script manages enemy spawning
// code from https://www.youtube.com/watch?v=WGn1zvLSndk
public class enemySpawner : MonoBehaviour {

	// array of different enemies
	//public GameObject[] enemies;
	public GameObject enemy;

	public Vector3 spawnValues;
	public float spawnWait;
	public float spawnMostWait;
	public float spawnLeastWait;
	public int startWait;
	public bool stop;

	// integer to decide which enemy to spawn
	//int randEnemy;

	// Use this for initialization
	void Start () {

		StartCoroutine (waitSpawner ());

	}
	
	// Update is called once per frame
	void Update () {

		// making spawnWait a random value
		spawnWait = Random.Range(spawnLeastWait, spawnMostWait);

	}

	// coroutine that runs to spawn enemies
	IEnumerator waitSpawner()
	{
		// controlling how long it waits before it starts spawning
		yield return new WaitForSeconds (startWait);

		// neverending loop right now
		while (!stop) 
		{
			// picking random enemy to spawn
			// randEnemy = Random.Range (0, 4);

			// picking where to spawn enemy
			Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z)); // (x, y, z)

			// to actually spawn objects
			// (what to spawn, where to spawn, and rotation)
			Instantiate (enemy, spawnPosition + transform.TransformPoint(0,0,0), gameObject.transform.rotation);

			yield return new WaitForSeconds (spawnWait);
		}

	}
}
