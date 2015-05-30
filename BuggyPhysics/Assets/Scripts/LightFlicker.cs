using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

	Light myLight;

	// Use this for initialization
	void Start () {
		myLight = GetComponent<Light> ();
		myLight.intensity = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		myLight.intensity = Random.Range(0.8f,1.0f);
	}
}
