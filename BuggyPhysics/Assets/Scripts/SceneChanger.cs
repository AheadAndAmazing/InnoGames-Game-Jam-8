using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour {

	public GameObject splashScreen;

	public void StartGame()
	{
		if (!splashScreen.activeInHierarchy) {
			Application.LoadLevel("Scene1");
		}

	}

	public void ExitGame()
	{
		Application.Quit ();
	}

	public void StartCredits()
	{
		Application.LoadLevel("Credits");
	}
}


