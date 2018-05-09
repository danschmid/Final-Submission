using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointControl : MonoBehaviour {

	public bool checkpointReached;
	public Animator anim;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			
			checkpointReached = true;
			anim.SetBool("checkpointReached", checkpointReached);
		}
	}
}
