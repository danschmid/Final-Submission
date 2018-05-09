using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {
	Text stopwatch;
	public float milliseconds, seconds, minutes;

	// Use this for initialization
	void Start () {
		stopwatch = GetComponent<Text> () as Text;
	}
	
	// Update is called once per frame
	void Update () {
		minutes = (int)(Time.timeSinceLevelLoad / 60f);
		seconds = (int)(Time.timeSinceLevelLoad % 60f);
		milliseconds = (int)(Time.timeSinceLevelLoad * 1000f) % 1000;
		stopwatch.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
	}
}
