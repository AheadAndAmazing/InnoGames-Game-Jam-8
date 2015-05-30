using UnityEngine;
using System.Collections;

public class HandleEggCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Kugel") {
			other.transform.parent = this.transform;
		}
	}
}
