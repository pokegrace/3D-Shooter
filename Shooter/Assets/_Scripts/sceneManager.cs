using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// script used to change between scenes
public class sceneManager : MonoBehaviour {

	public void loadPlay(){
		SceneManager.LoadScene ("play");
	}

	public void gameOver(){
		SceneManager.LoadScene ("gameOver");
	}
}
