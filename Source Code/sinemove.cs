using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinemove : MonoBehaviour {

	Vector3 start;
	public float distance = 12.5f;
	public float speed = 1.5f;
	bool flipped;
	SpriteRenderer sprite;
	// Use this for initialization
	void Start () {
		flipped = false;
		start = transform.position;
		sprite = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (start.x + Mathf.PingPong (speed*Time.time, distance), start.y + Mathf.Sin (speed*Time.time), start.z);
		if (transform.position.x >= distance + start.x - 0.15) {
			sprite.flipX = true;
			flipped = true;
		} else if (transform.position.x <= start.x + 0.15 && flipped == true)
			sprite.flipX = false;

	}
}
