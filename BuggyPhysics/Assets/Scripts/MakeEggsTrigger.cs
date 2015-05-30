using UnityEngine;
using System.Collections;

public class MakeEggsTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
			}
			else if(other.attachedRigidbody.velocity.y < -0.5f)
			{
				other.isTrigger = false;
			}

		}
	}
}
