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
	[HideInInspector]
	public WorldTile tile;

	void OnEnable()
	{
		destroyer = GameObject.Find("DerEierDestroyer").GetComponent<EierDestroyer>();
		rigid = this.GetComponent<Rigidbody>();
		coll = this.GetComponent<Collider>();
		if (this.GetComponent<ParticleSystem>() != null)
		{
			particle = this.GetComponent<ParticleSystem>();
			particle.emissionRate = 0;
		}
	}

	void Update () 
	{

		if (moveToPlayer) {
			transform.position = Vector3.MoveTowards(this.transform.position, newPosition, Time.deltaTime * 20.0f);
			particle.emissionRate = Mathf.Lerp(0, 100,Time.deltaTime * 20.0f);
			this.tag = "Kugel";
			this.gameObject.layer = 8;
			this.tile.PlacedObstacles.Remove(this.GetComponent<Obstacle>());
			ObjectPool.Current.eggs.Remove(this.gameObject);
			//this.transform.localScale = Vector3.MoveTowards(this.transform.localScale,new Vector3(.1f,.1f,.1f),Time.deltaTime * 8.0f);
		}
		if (this.transform.position == newPosition) {
			moveToPlayer = false;
			rigid.isKinematic = false;
			this.transform.localScale = new Vector3(.2f,.2f,.2f);
			rigid.AddForce(new Vector3(0.0f,-50.0f,0.0f));
			Debug.Log("I was here");
			destroyer.AddEiAmount(1);
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
			//this.transform.localScale = new Vector3(.1f,.1f,.1f);
			newPosition = new Vector3(other.transform.position.x,other.transform.position.y + 4.0f,other.transform.position.z - .4f);
			//this.transform.position = newPosition;
			moveToPlayer = true;
			ObjectPool.Current.eggs.Remove(this.gameObject);
			this.GetComponent<Obstacle>().RemoveFromSpawn();
			this.transform.parent = null;


		}
	}
}
