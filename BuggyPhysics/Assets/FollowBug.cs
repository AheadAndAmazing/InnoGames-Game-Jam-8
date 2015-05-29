using UnityEngine;
using System.Collections;

public class FollowBug : MonoBehaviour {

	public Transform bug;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(bug.position.x,bug.position.y + 3.0f,bug.position.z);
	}
}
