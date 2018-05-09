using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour {

	private Queue<string> lines;

	public Text storyText;

	// Use this for initialization
	void Start () {
		lines = new Queue<string> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartStory(Story story)
	{
		lines.Clear ();

		foreach (string line in story.lines) {
			lines.Enqueue (line);
		}
		GetNextLine ();
	}

	public void GetNextLine()
	{
		if (lines.Count == 0) {
			End ();
			return;
		}

		string line = lines.Dequeue ();
		StopAllCoroutines ();
		StartCoroutine (WriteLine (line));
	}

	IEnumerator WriteLine (string line)
	{
		storyText.text = "";
		foreach(char letter in line.ToCharArray())
		{
			storyText.text += letter;
			yield return null;
		}
	}

	void End()
	{
		Application.LoadLevel ("Pride");
	}
}
