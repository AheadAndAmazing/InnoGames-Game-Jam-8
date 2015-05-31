using UnityEngine;
using System.Collections;

public class MakeEggsTrigger : MonoBehaviour {

	SoundController soundControl;

	// Use this for initialization
	void Start () {
		soundControl = Camera.main.GetComponent<SoundController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Kugel") {
			if(other.attachedRigidbody.velocity.y > 0.0f)
			{
				other.isTrigger = true;
				soundControl.randomChirp();
			}
			else if(other.attachedRigidbody.velocity.y < -0.5f)
			{
				other.isTrigger = false;
			}

		}
	}
}
