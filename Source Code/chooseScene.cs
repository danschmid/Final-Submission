using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class chooseScene : MonoBehaviour {
	// Use this for initialization
	Text txt;
	Image image;

	void Start () {
		image = GetComponent<Image> ();
		txt = gameObject.GetComponentInChildren<Text> ();

		if (PlayerPrefs.GetInt ("prideDone") == 1 && txt.text.ToString() == "Greed")
			image.color = Color.white;

		if (PlayerPrefs.GetInt ("greedDone") == 1 && txt.text.ToString() == "Envy")
			image.color = Color.white;

		if (PlayerPrefs.GetInt ("envyDone") == 1 && txt.text.ToString() == "Sloth")
			image.color = Color.white;

		if (PlayerPrefs.GetInt ("slothDone") == 1 && txt.text.ToString() == "Lust")
			image.color = Color.white;

		if (PlayerPrefs.GetInt ("lustDone") == 1 && txt.text.ToString() == "Gluttony")
			image.color = Color.white;
		
		if (PlayerPrefs.GetInt ("gluttonyDone") == 1 && txt.text.ToString() == "Wrath")
			image.color = Color.white;

	}
	
	public void OnClick()
	{
		if (txt.text.ToString () == "Pride") {
			SceneManager.LoadScene ("Pride");
		}

		else if(txt.text.ToString() == "Greed"){
			if(PlayerPrefs.GetInt("prideDone") == 1)
				SceneManager.LoadScene("Greed");
		}

		else if(txt.text.ToString() == "Envy"){
			if(PlayerPrefs.GetInt("greedDone") == 1)
				SceneManager.LoadScene("Envy");
		}

		else if (txt.text.ToString() == "Sloth") {
			if(PlayerPrefs.GetInt("envyDone") == 1)
				SceneManager.LoadScene ("Sloth");
		}

		else if(txt.text.ToString() == "Lust"){
			if(PlayerPrefs.GetInt("slothDone") == 1)
				SceneManager.LoadScene("Lust");
		}

		else if(txt.text.ToString() == "Gluttony"){
			if(PlayerPrefs.GetInt("lustDone") == 1)
				SceneManager.LoadScene("Gluttony");
		}
			
		else if(txt.text.ToString() == "Wrath"){
			if(PlayerPrefs.GetInt("gluttonyDone") == 1)
				SceneManager.LoadScene("Wrath");
		}
	}
}
