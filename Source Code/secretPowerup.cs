using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secretPowerup : MonoBehaviour {

	public AudioSource CameraAudioSource;
	bool alreadyCollected = false;
	public GameObject Camera;

	public AudioClip secretSong;

	void Start()
	{
		Camera = GameObject.Find ("Camera");
		CameraAudioSource = Camera.GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (alreadyCollected == false) {
			alreadyCollected = true;

			//Despawn object
			gameObject.GetComponent<Renderer> ().enabled = false;

			//Set song on camera object
			CameraAudioSource.clip = secretSong;
			CameraAudioSource.Play();

			//Destroy object
			//Destroy (gameObject);
		}

	}

}
