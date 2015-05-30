using UnityEngine;
using System.Collections;

public class Gravitation : MonoBehaviour {

	Rigidbody rigid;
	// Use this for initialization
	void Start () 
	{
		rigid = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//rigid.AddForce (0.0f, -100.0f, 0.0f);\
//		print (rigid.velocity.y);
		//Vector3 fixedVelocity = new Vector3(rigid.velocity.x, Mathf.Clamp(rigid.velocity.y,0.0f,,rigid.velocity.z);
		//rigid.velocity = fixedVelocity;
	}
}
