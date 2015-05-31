using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ScoreCounter : MonoBehaviour {

	public EierDestroyer eierDestroyer;
	public Text gameOverText;
	public Text scoreText;
	public Text returnToMainMenuText;

	float time;
	float score;
	float bonusScore;

	Text text;
	bool scoreScreenWasShown = false;

	public string FileName;
	string directory;
	string path;

	List<int> highScoreList = new List<int>();

	bool gameOver = false;

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
			gameOver = true;
		}

		if (gameOver && Input.anyKeyDown) {
			Time.timeScale = 1.0f;
			WorldCreation.CurrentDifficultyLvl = 0;
			WorldTile.Speed = 2.0f;
			Application.LoadLevel("MainMenu");
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
			returnToMainMenuText.enabled = true;
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

		string[] highScoreArray = File.ReadAllLines (path);
		for (int i=0; i<highScoreArray.Length; i++) {
			highScoreList.Add(int.Parse(highScoreArray[i]));
		}
		highScoreList.Add ((int) score);

		highScoreList.Sort ();
		highScoreList.Reverse ();

		File.Create (path).Close ();

		asset = Resources.Load(FileName + ".txt") as TextAsset;
		writer = new StreamWriter(path, true);
		print ("Saved Highscores: "+highScoreList.Count);
		foreach(int scoreString in highScoreList)
		{
			writer.WriteLine(scoreString);
		}
		writer.Close ();
	}
	
}
