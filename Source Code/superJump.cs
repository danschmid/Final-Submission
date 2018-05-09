using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superJump : MonoBehaviour {

	public AudioSource audioSource;
	bool alreadyCollected = false;

	public float powerupTime = 10f;
	public float jumpMultiplier = 2f;
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
			float currentJumpHeight = playercontroller.jumpHeight;
			float currentWallJump = playercontroller.wallJumpDist;

			//Despawn object
			gameObject.GetComponent<Renderer> ().enabled = false;

			//Apply powerup to stats
			playercontroller.jumpHeight = currentJumpHeight * jumpMultiplier;
			playercontroller.wallJumpDist = currentWallJump * jumpMultiplier;

			//Zoom camera out - now done entirely in CameraFollow.cs
			//This was because it's kinda a pain to track yourself while you jump
			CameraFollow.burgersEaten += 2f;

			//Wait for the length of the powerup
			yield return new WaitForSeconds (powerupTime);

			//Revert stats
			playercontroller.jumpHeight = currentJumpHeight;
			playercontroller.wallJumpDist = currentWallJump;

			//Zoom camera back in
			CameraFollow.burgersEaten -= 2f;

			//Wait for additional time until respawning
			yield return new WaitForSeconds (respawnTime-powerupTime);
			gameObject.GetComponent<Renderer> ().enabled = true;
			alreadyCollected = false;

			/*
			//Destroy object
			Destroy (gameObject, powerupTime);
			*/
		}

	}

}
