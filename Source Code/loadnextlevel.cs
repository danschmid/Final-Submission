using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadnextlevel : MonoBehaviour {
	Scene current;
	public Sprite door;
	public Sprite closed;
	float minutes;
	float seconds;
	float millis;
	private SpriteRenderer doorSpriteRenderer;


	// Use this for initialization
	void Start () {
		current = SceneManager.GetActiveScene();
		doorSpriteRenderer = GetComponent<SpriteRenderer> ();

	}
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other)
	{
		minutes = GameObject.Find ("Time").GetComponent<timer> ().minutes;
		seconds = GameObject.Find ("Time").GetComponent<timer> ().seconds;
		millis = GameObject.Find ("Time").GetComponent<timer> ().milliseconds;
		
		if(other.tag == "Player"){
			doorSpriteRenderer.sprite = closed;
			if (current.name == "Pride") {
				PlayerPrefs.SetInt("prideDone",1); //set global variable for level select menu
				PlayerPrefs.Save ();
				SceneManager.LoadScene ("Greed");

			} else if (current.name == "Greed") {
				PlayerPrefs.SetInt ("greedDone", 1); //set global variable for level select menu
				if (PlayerPrefs.HasKey ("greedSeconds") &&
					minutes <= PlayerPrefs.GetFloat ("greeMinutes") &&
					seconds <= PlayerPrefs.GetFloat ("greedSeconds") &&
					millis < PlayerPrefs.GetFloat ("greedMillis")) {
					PlayerPrefs.SetFloat ("greedMinutes", minutes);
					PlayerPrefs.SetFloat ("greedSeconds", seconds);
					PlayerPrefs.SetFloat ("greedMillis", millis);
				} else if(!PlayerPrefs.HasKey("greedSeconds")) {
					PlayerPrefs.SetFloat ("greedMinutes", minutes);
					PlayerPrefs.SetFloat ("greedSeconds", seconds);
					PlayerPrefs.SetFloat ("greedMillis", millis);
				}

				PlayerPrefs.Save ();
				SceneManager.LoadScene ("Envy");

			} else if (current.name == "Envy") {
				PlayerPrefs.SetInt ("envyDone", 1); //set global variable for level select menu
				if (PlayerPrefs.HasKey ("envySeconds") &&
				    minutes <= PlayerPrefs.GetFloat ("envyMinutes") &&
				    seconds <= PlayerPrefs.GetFloat ("envySeconds") &&
				    millis < PlayerPrefs.GetFloat ("envyMillis")) {
					PlayerPrefs.SetFloat ("envyMinutes", minutes);
					PlayerPrefs.SetFloat ("envySeconds", seconds);
					PlayerPrefs.SetFloat ("envyMillis", millis);
				} else if(!PlayerPrefs.HasKey("envySeconds")) {
					PlayerPrefs.SetFloat ("envyMinutes", minutes);
					PlayerPrefs.SetFloat ("envySeconds", seconds);
					PlayerPrefs.SetFloat ("envyMillis", millis);
				}

				PlayerPrefs.Save ();
				SceneManager.LoadScene ("Sloth");

			} else if (current.name == "Sloth") {
				PlayerPrefs.SetInt ("slothDone", 1); //set global variable for level select menu
				if (PlayerPrefs.HasKey ("slothSeconds") &&
					minutes <= PlayerPrefs.GetFloat ("slothMinutes") &&
					seconds <= PlayerPrefs.GetFloat ("slothSeconds") &&
					millis < PlayerPrefs.GetFloat ("slothMillis")) {
					PlayerPrefs.SetFloat ("slothMinutes", minutes);
					PlayerPrefs.SetFloat ("slothSeconds", seconds);
					PlayerPrefs.SetFloat ("slothMillis", millis);
				} else if(!PlayerPrefs.HasKey("slothSeconds")) {
					PlayerPrefs.SetFloat ("slothMinutes", minutes);
					PlayerPrefs.SetFloat ("slothSeconds", seconds);
					PlayerPrefs.SetFloat ("slothMillis", millis);
				}

				PlayerPrefs.Save ();
				SceneManager.LoadScene ("Lust");

			} else if (current.name == "Lust") {
				PlayerPrefs.SetInt ("lustDone", 1); //set global variable for level select menu
				if (PlayerPrefs.HasKey ("lustSeconds") &&
					minutes <= PlayerPrefs.GetFloat ("lustMinutes") &&
					seconds <= PlayerPrefs.GetFloat ("lustSeconds") &&
					millis < PlayerPrefs.GetFloat ("lustMillis")) {
					PlayerPrefs.SetFloat ("lustMinutes", minutes);
					PlayerPrefs.SetFloat ("lustSeconds", seconds);
					PlayerPrefs.SetFloat ("lustMillis", millis);
				} else if(!PlayerPrefs.HasKey("lustSeconds")) {
					PlayerPrefs.SetFloat ("lustMinutes", minutes);
					PlayerPrefs.SetFloat ("lustSeconds", seconds);
					PlayerPrefs.SetFloat ("lustMillis", millis);
				}

				PlayerPrefs.Save ();
				SceneManager.LoadScene ("Gluttony");

			}
			  else if (current.name == "Gluttony"){
				PlayerPrefs.SetInt ("gluttonyDone", 1); //set global variable for level select menu
				if (PlayerPrefs.HasKey ("gluttonySeconds") &&
					minutes <= PlayerPrefs.GetFloat ("gluttonyMinutes") &&
					seconds <= PlayerPrefs.GetFloat ("gluttonySeconds") &&
					millis < PlayerPrefs.GetFloat ("gluttonyMillis")) {
					PlayerPrefs.SetFloat ("gluttonyMinutes", minutes);
					PlayerPrefs.SetFloat ("gluttonySeconds", seconds);
					PlayerPrefs.SetFloat ("gluttonyMillis", millis);
				} else if(!PlayerPrefs.HasKey("gluttonySeconds")) {
					PlayerPrefs.SetFloat ("gluttonyMinutes", minutes);
					PlayerPrefs.SetFloat ("gluttonySeconds", seconds);
					PlayerPrefs.SetFloat ("gluttonyMillis", millis);
				}

				PlayerPrefs.Save ();
				SceneManager.LoadScene ("Wrath");

			}

		}
	}
}
