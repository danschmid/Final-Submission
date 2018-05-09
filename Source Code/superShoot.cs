using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superShoot : MonoBehaviour {

	public AudioSource audioSource;
	bool alreadyCollected = false;

	public float powerupTime = 15f;
	public float firerateMultiplier = 4f; // Multiplier on fire rate (actually divides)
	public float respawnTime = 60f;

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

			//De-render object
			gameObject.GetComponent<Renderer> ().enabled = false;

			//Get player's current stats
			float currentFireRate = playercontroller.fireRate;

			//Apply powerup to stats
			playercontroller.fireRate = currentFireRate / firerateMultiplier;
			playercontroller.shootPowerupActive = true;

			//Wait for the length of the powerup
			yield return new WaitForSeconds (powerupTime);

			//Revert stats
			playercontroller.fireRate = currentFireRate;
			playercontroller.shootPowerupActive = false;

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
