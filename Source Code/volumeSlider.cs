using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumeSlider : MonoBehaviour {


	// Update is called once per frame
	public void AdjustVolume(float newVolume){
		float volume = AudioListener.volume;
		volume = newVolume;
		AudioListener.volume = volume;
	}
}
