using UnityEngine;
using System.Collections;

public class MoveWorldTest : MonoBehaviour {
	
	public float speedFactor;
//	Rigidbody rigid;
	// Use this for initialization
	void Start () {
//		rigid = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Vertical") > 0.0f) {
			speedFactor += 1.0f * Time.deltaTime;
		}

		this.transform.Translate (0.0f, 0.0f, -speedFactor);
		//rigid.AddForce(0.0f, 0.0f, -speedFactor, ForceMode.VelocityChange);
	}
}
