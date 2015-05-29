using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	Rigidbody rigid;

	public float speedFactor;
	// Use this for initialization
	void Start () 
	{
		rigid = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		rigid.AddForce (Input.GetAxis("Horizontal")*0.5f, 0.0f, 0.0f, ForceMode.VelocityChange);
		//this.transform.Translate (50* (Input.GetAxis ("Horizontal") * Time.deltaTime), 0.0f, Input.GetAxis("Vertical")*Time.deltaTime);
	}
}
