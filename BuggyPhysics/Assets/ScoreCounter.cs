using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
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
	string directory;
	string path;

	List<string> highScoreList = new List<string>();

	// Use this for initialization
	void Start () 
	{
		text = this.GetComponent<Text> ();
		directory = "Resources/";
		path = directory + FileName + ".txt";
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

			updateHighscoreList(score);
		}
	}

	void updateHighscoreList(float score)
	{
		TextAsset asset;
		StreamWriter writer;

		if (!File.Exists (path)) {
			if (!Directory.Exists (directory)) {
				Directory.CreateDirectory (directory);
			}
			File.CreateText (path).Dispose ();
		}


		StreamReader reader = new StreamReader (path);
		bool fileEnded = false;
		while (fileEnded) {
			if(highScoreList[highScoreList.Count] != null)
			{
				highScoreList.Add(reader.ReadLine());
			}
			else
			{
				fileEnded = true;
			}
		}

		reader.Close ();


		asset = Resources.Load(FileName + ".txt") as TextAsset;
		writer = new StreamWriter(path, true);
		writer.WriteLine(score.ToString());
		writer.Close ();


		//StreamReader reader = new StreamReader (path);
		print ("Highscore recorded: "+reader.ReadLine ());
		reader.Close ();

	}
	
}
