using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform bug;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,bug.position.z - 4.5f);
	}
}
