using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superSpeed : MonoBehaviour {

	public AudioSource audioSource;
	bool alreadyCollected = false;

	public float powerupTime = 5f;
	public float speedMultiplier = 2f; // Multiplier on speed
	public float respawnTime = 15f;

	void Start()
	{
		audioSource = GetComponent<AudioSource> ();
	}

	IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		if (alreadyCollected == false && other.gameObject.name == "Player") {
			alreadyCollected = true;

			//Play sound
			audioSource.Play ();
		
			//Get player's current stats
			float currentSpeed = playercontroller.maxSpeed;

			//De-render object
			gameObject.GetComponent<Renderer> ().enabled = false;

			//Apply powerup to stats
			playercontroller.maxSpeed = currentSpeed * speedMultiplier;

			//Wait for the length of the powerup
			yield return new WaitForSeconds (powerupTime);

			//Revert stats
			playercontroller.maxSpeed = currentSpeed;

			//Wait for additional time until respawning
			yield return new WaitForSeconds (respawnTime-powerupTime);
			gameObject.GetComponent<Renderer> ().enabled = true;
			alreadyCollected = false;
			/*
			Destroy (gameObject);
			*/
		}
	}

}
