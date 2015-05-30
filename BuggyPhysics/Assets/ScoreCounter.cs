using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreCounter : MonoBehaviour {

	public EierDestroyer eierDestroyer;
	public Text gameOverText;
	public Text scoreText;

	float time;
	float score;
	float bonusScore;

	Text text;
	bool scoreScreenWasShown = false;

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

}
