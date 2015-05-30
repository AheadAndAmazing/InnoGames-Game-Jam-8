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
		speedFactor = Input.GetAxis("Horizontal")*0.1f;
		if (this.transform.position.x > 7.0f && speedFactor > 0.0f) {
			speedFactor = 0.0f;
		} else if (this.transform.position.x < -7.0f && speedFactor < 0.0f) {
			speedFactor = 0.0f;
		}
		rigid.AddForce (speedFactor * 7.0f, 0.0f, 0.0f, ForceMode.VelocityChange);
		//this.transform.Translate (50* (Input.GetAxis ("Horizontal") * Time.deltaTime), 0.0f, Input.GetAxis("Vertical")*Time.deltaTime);
	}
}
