using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upndown : MonoBehaviour {
	Vector3 startSpot;
	// Use this for initialization
	void Start () {
		startSpot = transform.position;
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (startSpot.x, startSpot.y + Mathf.PingPong (5*Time.time, 5), startSpot.z);
	}
}
