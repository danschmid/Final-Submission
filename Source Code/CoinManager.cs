using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CoinManager : MonoBehaviour {

	public static int coinScore;

	Text text;
	// Use this for initialization
	void Awake () {
		text = GetComponent <Text> ();
		coinScore = playercontroller.coinScore;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Coins: " + coinScore;
	}
}
