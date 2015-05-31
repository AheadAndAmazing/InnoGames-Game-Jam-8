using UnityEngine;
using System.Collections;

public class EierDestroyer : MonoBehaviour {

	int eierse;
	bool isNotGameOver = true;
	public GameObject eierseParent;

	void Start()
	{
		eierse = eierseParent.transform.childCount;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Kugel") {
			Destroy(other.gameObject);
			eierse --;
			if(eierse == 0)
			{
				print ("YOU LOSE");
				isNotGameOver = false;
			}
		}
	}

	public bool GetIsNotGameOver()
	{
		return isNotGameOver;
	}

	public void AddEiAmount(int amount)
	{
		eierse += amount;
	}

}
