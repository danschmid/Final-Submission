using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dealDamage : MonoBehaviour {
		// Use this for initialization
	PlayerHealth playerHealth;
	GameObject player;

	// Update is called once per frame
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			playerHealth.takeHit();
		}
	}
}
