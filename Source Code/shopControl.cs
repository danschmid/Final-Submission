using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopControl : MonoBehaviour {

	public GameObject shopPanel;
	AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
			OpenShop ();
	}

	void OpenShop()
	{
		shopPanel.SetActive (true);
		Time.timeScale = 0f;
	}

	public void CloseShop()
	{
		audio.Play ();
		shopPanel.SetActive (false);
		Time.timeScale = 1f;
	}
}
