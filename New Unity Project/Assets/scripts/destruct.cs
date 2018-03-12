using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruct : MonoBehaviour {

	public float time;

	void Awake () {
		if (gameObject != null) {
			Destroy(gameObject, time);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
