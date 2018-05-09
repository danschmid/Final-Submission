using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour {
	float start;
	float turnAround;
	public float patrolDistance;
	bool flipped;
	public float walkingSpeed;
	SpriteRenderer sprite;
	// Use this for initialization
	void Start () {
		flipped = false;
		start = transform.position.x;
		turnAround = transform.position.x + patrolDistance;
		sprite = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (Mathf.PingPong (walkingSpeed * Time.time, turnAround - start) + start, transform.position.y, transform.position.z);
		if (transform.position.x >= turnAround - 0.15) {
			sprite.flipX = true;
			flipped = true;
		}
		else if (transform.position.x <= start +0.15 && flipped == true)
			sprite.flipX = false;
	}
}
