using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour {

	public void StartGame()
	{
		Application.LoadLevel("Scene1");
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


