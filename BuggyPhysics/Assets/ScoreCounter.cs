using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreCounter : MonoBehaviour {

	float time;
	Text text;
	// Use this for initialization
	void Start () 
	{
		text = this.GetComponent<Text> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		text.text = (Mathf.Floor(time)).ToString();

	
	}
}
