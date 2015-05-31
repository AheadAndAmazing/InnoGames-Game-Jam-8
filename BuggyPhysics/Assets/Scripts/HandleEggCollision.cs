using UnityEngine;
using System.Collections;

public class HandleEggCollision : MonoBehaviour {

	public GameObject bugSplatter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Kugel") {
			other.transform.parent = this.transform;


			if(!other.attachedRigidbody.isKinematic)
			{
				GameObject currentSplatter = Instantiate(bugSplatter) as GameObject;
				currentSplatter.transform.parent = other.transform;
				currentSplatter.transform.localPosition = Vector3.zero;
			}
			other.attachedRigidbody.isKinematic = true;


		}
	}
}
