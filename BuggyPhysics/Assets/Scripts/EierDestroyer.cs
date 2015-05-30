using UnityEngine;
using System.Collections;

public class EierDestroyer : MonoBehaviour {

	public int eierse;
	bool isNotGameOver = true;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Kugel") {
			Destroy(other.gameObject);
			eierse --;
			if(eierse == 0)
			{
				//TODO: Lose
				print ("YOU LOSE");
				isNotGameOver = false;
			}
		}
	}

	public bool GetIsNotGameOver()
	{
		return isNotGameOver;
	}

}
