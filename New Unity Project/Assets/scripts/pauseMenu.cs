using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour {

	public static bool gamePaused = false;
	public GameObject pauseMenuScene;


	void Start () {
		pauseMenuScene.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
				if(gamePaused)
				{
					Resume();
				}
				else
				{
					Pause();
				}
			}
	}

	public void Resume(){
		pauseMenuScene.SetActive (false);
		Time.timeScale = 1f;
		gamePaused = false;
	}

	void Pause(){
		pauseMenuScene.SetActive (true);
		Time.timeScale = 0f;
		gamePaused = true;
	}

	public void Quit(){
		Application.Quit ();
	}
}
