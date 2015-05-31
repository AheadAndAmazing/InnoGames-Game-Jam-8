using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class MainMenu : MonoBehaviour {

	public bool isPresentationVersion;
	public GameObject splashScreen;
	public GameObject creditsButton;
	public GameObject startButton;
	public Text highScores;
	public Image credits;
	public float splashScreenTime = 3.0f;

	float deltaTime;
	
	// Use this for initialization
	void Start () 
	{
		deltaTime = splashScreenTime;
		ShowHighscores ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		deltaTime -= Time.deltaTime;

		if ((!isPresentationVersion && deltaTime <= 0.0f) || Input.GetButtonDown("Fire1"))
		{
			splashScreen.SetActive(false);
		}

		if (credits.enabled && Input.anyKeyDown) {
			//ToggleCredits();
		}
	}

	public void StartGame()
	{
		if (!splashScreen.activeInHierarchy) {
			Application.LoadLevel("Scene1");
		}
	}
	
	public void GoBackToMainMenu()
	{
		Application.LoadLevel ("MainMenu");
		splashScreen.SetActive (false);
	}

	public void ToggleCredits()
	{
		if (!splashScreen.activeInHierarchy) {
			print ("ToogleCredits()");
			startButton.SetActive(credits.enabled);
			credits.enabled = !credits.enabled;
		}
	}

	void ShowHighscores()
	{
		string path = "Resources/Highscore.txt";
		if (File.Exists (path)) {
			string highScoresFromFile = File.ReadAllText (path);
			highScores.text = highScoresFromFile;
		} else {
			highScores.text = "No Highscore recorded! :(";
		}
	}
}
