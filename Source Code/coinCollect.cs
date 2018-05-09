using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCollect : MonoBehaviour {

	public AudioSource audioSource;
	public static int count = 0;
	bool alreadyCollected = false;

	void Start()
	{
		audioSource = GetComponent<AudioSource> ();
		// Sets alreadyCollectd to false for any given coin
		alreadyCollected = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" || other.tag == "Companion") {
			if (alreadyCollected == false) {
				audioSource.Play ();
				alreadyCollected = true;
				CoinManager.coinScore += 1;
				playercontroller.coinScore += 1;
		
				// De-render object
				gameObject.GetComponent<Renderer> ().enabled = false;

				// Wait for 1 second to let the sound play before object is destroyed
				if (gameObject.transform.parent.childCount == 1) {
					// If that was the last coin in the parent gameObject, destroy that whole thing
					Destroy (transform.parent.gameObject, 0.35f);
				} else {
					Destroy (gameObject, 0.35f);
				}

			}
		}

	}



}
