using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script used to manage damage given to player
// code from: gamesplusjames
public class hurtPlayer : MonoBehaviour {

	public int damageToGive;

	// if collider "Is Trigger" is checked, use this to check collision
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			other.gameObject.GetComponent<playerHealthManager> ().HurtPlayer (damageToGive);
		}
	}
}
