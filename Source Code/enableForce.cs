using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableForce : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.parent.gameObject.GetComponent<ConstantForce2D>().enabled = false;
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player")
			transform.parent.gameObject.GetComponent<ConstantForce2D>().enabled = true;
	}
}
