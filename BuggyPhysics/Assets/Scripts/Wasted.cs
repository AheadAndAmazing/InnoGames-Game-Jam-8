using UnityEngine;
using System.Collections;

public class Wasted : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		print ("COLLISION");
		print (collision.collider.name);
		if(collision.gameObject.tag == "Player")
		{
			Rigidbody rg = collision.gameObject.GetComponent<Rigidbody>();
			rg.constraints = RigidbodyConstraints.None;
			rg.AddExplosionForce(100, rg.transform.position, 20.0f);
		}
	}


}
