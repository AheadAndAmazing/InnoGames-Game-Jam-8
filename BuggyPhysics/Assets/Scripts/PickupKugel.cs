using UnityEngine;
using System.Collections;

public class PickupKugel : MonoBehaviour 
{
	EierDestroyer destroyer;
	Rigidbody rigid;
	Collider coll;
	ParticleSystem particle;
	Vector3 newPosition;
	bool moveToPlayer;

	void Start () 
	{
		destroyer = GameObject.Find ("DerEierDestroyer").GetComponent<EierDestroyer>();
		rigid = this.GetComponent<Rigidbody>();
		coll = this.GetComponent<Collider> ();
		if (this.GetComponent<ParticleSystem> () != null) {
			particle = this.GetComponent<ParticleSystem> ();
		}
		particle.emissionRate = 0;
	}

	void Update () 
	{

		if (moveToPlayer) {
			transform.position = Vector3.MoveTowards(this.transform.position, newPosition, Time.deltaTime * 20.0f);
			particle.emissionRate = Mathf.Lerp(0, 100,Time.deltaTime * 20.0f);
			//this.transform.localScale = Vector3.MoveTowards(this.transform.localScale,new Vector3(.1f,.1f,.1f),Time.deltaTime * 8.0f);
		}
		if (this.transform.position == newPosition) {
			moveToPlayer = false;
			rigid.isKinematic = false;
			this.transform.localScale = new Vector3(.1f,.1f,.1f);
			rigid.AddForce(new Vector3(0.0f,-50.0f,0.0f));
			if(particle !=null)
			{
				particle.emissionRate = 0;
			}
			
		}

	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			particle.emissionRate = 100;
			destroyer.eierse++;
			//this.transform.localScale = new Vector3(.1f,.1f,.1f);
			newPosition = new Vector3(other.transform.position.x,other.transform.position.y + 4.0f,other.transform.position.z - .4f);
			//this.transform.position = newPosition;
			moveToPlayer = true;
			this.transform.parent = null;


		}
	}
}
