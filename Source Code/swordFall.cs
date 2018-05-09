using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordFall : MonoBehaviour {


	public Rigidbody2D rb;
	void Awake(){
		rb.Sleep ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
			rb.WakeUp ();
	}
}
