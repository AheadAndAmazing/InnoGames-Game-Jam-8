using UnityEngine;
using System.Collections;

public class Wasted : MonoBehaviour {

	void OnTriggerEnter(Collider collision)
	{
		print ("COLLISION");
		//print (collision.collider.name);
		if(collision.gameObject.tag == "Player")
		{
			Rigidbody rg = collision.gameObject.GetComponent<Rigidbody>();
			rg.constraints = RigidbodyConstraints.None;
			//rg.AddExplosionForce(100, rg.transform.position, 20.0f);
			rg.AddForce(Vector3.up * 100.0f);
			rg.AddTorque(new Vector3(Random.Range(0,100),0.0f,0.0f));
		}
	}


}
