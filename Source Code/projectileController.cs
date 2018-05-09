using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {

	public float bubbleSpeed;

	//For gluttony level
	public static float burgersEaten = 0f;
	public float growthMultiplier = 1.1f; //MAKE SURE THIS VALUE MATCHES SUPERSIZE.CS AND PLAYERCONTROLLER.CS


	Rigidbody2D rb;

	//Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		if (transform.rotation.z < 0) {
			transform.Rotate(new Vector3(180f,0, 0));
			rb.AddForce (new Vector2(-1,0) * bubbleSpeed * Mathf.Pow(growthMultiplier,burgersEaten), ForceMode2D.Impulse);
			print (transform.localRotation.z);
		} else {
			rb.AddForce (new Vector2(1,0) * bubbleSpeed * Mathf.Pow(growthMultiplier,burgersEaten), ForceMode2D.Impulse);
			print (transform.localRotation.z);
		}

		//burgersEaten = 0f;
	}

	//Make bullet be destroyed by objects
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag != "Player" && other.tag != "SwordsFall" && other.tag != "SwordsDamage" && other.tag != "Swords")
			Destroy (gameObject, 0.05f);
	}


	/*
	//Update is called once per frame
	void Update () {
		
	}*/
}
