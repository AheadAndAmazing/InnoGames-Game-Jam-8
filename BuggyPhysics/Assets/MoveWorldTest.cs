using UnityEngine;
using System.Collections;

public class MoveWorldTest : MonoBehaviour {
	
	float speedFactor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Vertical") > 0.0f) {
			speedFactor += 0.1f * Time.deltaTime;
		}

		this.transform.Translate (0.0f, 0.0f, -speedFactor);
	}
}
