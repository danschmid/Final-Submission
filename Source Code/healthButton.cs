using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthButton : MonoBehaviour {

	public Slider slidy;
	public static bool healthUpgrade1;
	Image image;
	AudioSource audio;
	// Use this for initialization
	void Start () {
		image = GetComponent<Image> ();
		audio = GetComponent<AudioSource> ();
		if (PlayerPrefs.HasKey ("healthUpgrade1"))
			image.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick()
	{
		if (playercontroller.coinScore >= 3 && !PlayerPrefs.HasKey("healthUpgrade1")) {
			playercontroller.coinScore -= 3;
			CoinManager.coinScore -= 3;
			PlayerPrefs.SetInt("healthUpgrade1", 1);
			image.color = Color.green;
			PlayerHealth.starting = 132;
			PlayerHealth.current += 33;
			slidy.maxValue = 132;
			audio.Play ();
			slidy.value = PlayerHealth.current;
			}
		}
	}
