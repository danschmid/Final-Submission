using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour {
	public int starting;
	public int current;
	SpriteRenderer sprite;
	int i;
	// Use this for initialization
	void Start () {
		current = starting;
		sprite = gameObject.GetComponent < SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Flash()
	{
		sprite.color = Color.white;
	}
		

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Projectile") {
			current -= 1;
			sprite.color = Color.clear;
			Invoke ("Flash", 0.075f);
		}

		if (current == 0)
		{
			Destroy(gameObject);
		}

	}
}
