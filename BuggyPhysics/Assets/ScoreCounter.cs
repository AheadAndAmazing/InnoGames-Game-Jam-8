using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class ScoreCounter : MonoBehaviour {

	public EierDestroyer eierDestroyer;
	public Text gameOverText;
	public Text scoreText;

	float time;
	float score;
	float bonusScore;

	Text text;
	bool scoreScreenWasShown = false;

	public string FileName;

	// Use this for initialization
	void Start () 
	{
		text = this.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (eierDestroyer.GetIsNotGameOver ()) {
			time += Time.deltaTime;
			score = ((Mathf.Round (time * Mathf.PI)) * 8.0f) + bonusScore;
			text.text = score.ToString ();
		} else {
			setupEndScoreScreen();
		}
	}

	void setupEndScoreScreen()
	{
		if (!scoreScreenWasShown) {
			print ("ScoreScreen!");
			scoreScreenWasShown = true;
			Time.timeScale = 0.0f;
			gameOverText.enabled = true;
			scoreText.enabled = true;
			scoreText.text += score.ToString ();
		}
	}

	void updateHighscoreList(float score)
	{
		 // This contains the name of the file. Don't add the ".txt"
		// Assign in inspector
		TextAsset asset; // Gets assigned through code. Reads the file.
		StreamWriter writer; // This is the writer that writes to the file

		asset = Resources.Load(FileName + ".txt") as TextAsset;
		writer = new StreamWriter("Resources/" + FileName + ".txt"); // Does this work?
		writer.WriteLine(score.ToString());

	}
	
}
