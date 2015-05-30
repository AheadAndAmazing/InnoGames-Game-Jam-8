using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public bool isPresentationVersion;
	public GameObject splashScreen;
	public float splashScreenTime = 3.0f;
	float deltaTime;
	
	// Use this for initialization
	void Start () 
	{
		deltaTime = splashScreenTime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		deltaTime -= Time.deltaTime;

		if ((!isPresentationVersion && deltaTime <= 0.0f) || Input.GetButtonDown("Fire1"))
		{
			splashScreen.SetActive(false);
		}
	}
}
