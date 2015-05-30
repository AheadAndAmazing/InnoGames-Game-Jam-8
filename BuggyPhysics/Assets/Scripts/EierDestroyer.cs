using UnityEngine;
using System.Collections;

public class EierDestroyer : MonoBehaviour {

	public int eierse;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Kugel") {
			Destroy(other.gameObject);
			eierse --;
			if(eierse == 0)
			{
				//TODO: Lose
				print ("YOU LOSE");
			}
		}
	}

}
