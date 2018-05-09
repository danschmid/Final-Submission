using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {

	Scene scene;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		scene = SceneManager.GetActiveScene();
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		//Reset variables for gluttony level
		playercontroller.burgersEaten = 0f;
		CameraFollow.burgersEaten = 0f;
		projectileController.burgersEaten = 0f;

		if (coll.gameObject.tag == "Checkpoint") {
			SceneManager.LoadScene (scene.name);
		}
	}
			
}
