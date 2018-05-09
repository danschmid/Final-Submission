using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTrigger : MonoBehaviour {

	public Story story;
	// Use this for initialization
	void Start () {
		FindObjectOfType<StoryManager> ().StartStory (story);
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	//public void TriggerStory()
	//{
//		FindObjectOfType<StoryManager> ().StartStory (story);
	//}
}
