using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superSize : MonoBehaviour {

	public AudioSource audioSource;
	bool alreadyCollected = false;

	public GameObject playerObj;
	public GameObject cameraObj;

	public float growthMultiplier = 1.1f; //MAKE SURE THIS VALUE MATCHES PROJECTILECONTROLLER.CS AND PROJECTILECONTROLLER.CS
	public float minSizeRatio = 12f; //How many times bigger the player needs to be than powerup
	public float maxSizeRatio = 100f; //How many times bigger the player can be before they can't collect powerup
	//public float respawnTime = 15f;

	void Start()
	{
		//Get audio source
		audioSource = GetComponent<AudioSource> ();

		//Get player object
		playerObj = GameObject.Find ("Player");
		cameraObj = GameObject.Find ("Camera");
	}

	IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		//Calculate size ratio of player to powerup
		float currentRatio = playerObj.transform.localScale.y / gameObject.transform.localScale.y;

		if (alreadyCollected == false && currentRatio >= minSizeRatio && currentRatio <= maxSizeRatio && other.gameObject.name == "Player") {
			alreadyCollected = true;

			//Play sound
			audioSource.Play ();

			//De-render powerup
			gameObject.GetComponent<Renderer> ().enabled = false;

			//Zoom camera out - now done entirely in CameraFollow.cs
			CameraFollow.burgersEaten += 1f;
			/*
			Vector3 cameraPos = cameraObj.transform.localPosition;
			//Debug.Log (cameraPos.z);
			//Debug.Log (growthMultiplier);
			float newZ = cameraPos.z - 2f;
			cameraPos.z = newZ;
			//Debug.Log (cameraPos);
			//cameraObj.transform.localPosition = cameraPos;
			*/

			//Apply growth
			playerObj.transform.localScale = playerObj.transform.localScale*growthMultiplier;
			playercontroller.burgersEaten += 1f;
			projectileController.burgersEaten += 1f;
			//Slightly increase player's mass to reduce jump height
			playerObj.GetComponent<Rigidbody2D> ().mass *= Mathf.Pow (growthMultiplier, 0.5f);

			//Wait for a bit for audio to play
			yield return new WaitForSeconds (1f);

			/*
			//Wait for additional time until respawning
			yield return new WaitForSeconds (respawnTime-powerupTime);
			gameObject.GetComponent<Renderer> ().enabled = true;
			alreadyCollected = false;
			*/

			Destroy (gameObject);

		}
	}

}
