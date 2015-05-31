using UnityEngine;
using System.Collections;

public class FollowBug : MonoBehaviour {

	public Transform bug;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(bug.position.x,bug.position.y,bug.position.z + 0.97f);
		this.transform.rotation = bug.rotation;
	}
}
