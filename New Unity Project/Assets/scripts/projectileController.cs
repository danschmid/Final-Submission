using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {

	public float bubbleSpeed;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		if (transform.rotation.z > 0) {
			transform.Rotate(new Vector3(180f,0, 0));
			rb.AddForce (new Vector2(-1,0) * bubbleSpeed, ForceMode2D.Impulse);
			print (transform.localRotation.z);
		} else {
			rb.AddForce (new Vector2(1,0) * bubbleSpeed, ForceMode2D.Impulse);
			print (transform.localRotation.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
