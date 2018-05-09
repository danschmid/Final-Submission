using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public static int starting;
	public static int current;
	public Image flashPic;
	public float flash = 5f;
	public Color flashcolor = new Color (1f, 0f, 1f, 0.1f);
	public Slider slidy;
	bool damaged;
	bool dead;
	//Death Variable
	public Vector3 respawnPoint;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt("healthUpgrade1") == 1){
			starting = 132;
			slidy.maxValue = 132;
			slidy.value = 132;
		}
		else
			starting = 99;
		current = starting;
		respawnPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (damaged) {
			flashPic.color = flashcolor;
		} else {
			flashPic.color = Color.Lerp (flashPic.color, Color.clear, flash * Time.deltaTime);
		}
		damaged = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Respawn") {
			//Reset variables for gluttony level
			playercontroller.burgersEaten = 0f;
			CameraFollow.burgersEaten = 0f;
			projectileController.burgersEaten = 0f;
			transform.position = respawnPoint;
			current = starting;
			slidy.value = current;
		}

		else if(other.tag == "Checkpoint"){
			respawnPoint = other.transform.position;
			current = starting;
			slidy.value = current;
		}
	}	

	public void takeHit()
	{
		damaged = true;
		current -= 33;
		slidy.value = current;
		if (current <= 0 && !dead) {
			transform.position = respawnPoint;
			current = starting;
			slidy.value = current;
		}
	}
}
