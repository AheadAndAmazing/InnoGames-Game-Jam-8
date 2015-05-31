using UnityEngine;
using System.Collections;

public class Wasted : MonoBehaviour {

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Player")
		{
			Rigidbody rg = other.gameObject.GetComponent<Rigidbody>();
			rg.constraints = RigidbodyConstraints.None;
			rg.AddExplosionForce(100, rg.transform.position, 20.0f);
		}
	}


}
