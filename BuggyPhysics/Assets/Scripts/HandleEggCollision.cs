using UnityEngine;
using System.Collections;

public class HandleEggCollision : MonoBehaviour {

	public GameObject bugSplatter;
	Camera mainCam;
	SoundController soundControl;

	// Use this for initialization
	void Start () {
		mainCam = Camera.main;
		soundControl = mainCam.GetComponent<SoundController>();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Kugel") {
			other.transform.parent = this.transform;
			other.attachedRigidbody.isKinematic = true;
			soundControl.randomSplat();

			if(other.transform.childCount == 0.0f)
			{
				GameObject currentSplatter = Instantiate(bugSplatter) as GameObject;
				currentSplatter.transform.parent = other.transform;
				currentSplatter.transform.localPosition = Vector3.zero;
			}

		}
	}
}
