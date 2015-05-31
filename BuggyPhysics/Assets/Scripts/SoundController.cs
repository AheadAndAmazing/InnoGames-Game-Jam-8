using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	public AudioClip[] allSoundeffects;

	private AudioSource source;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
	}

	public void randomChirp()
	{
		source.clip = allSoundeffects [Random.Range (0, 6)];
		source.Play ();
	}
	public void randomSplat()
	{
		source.clip = allSoundeffects [Random.Range (5,9)];
		source.Play ();
	}
	
}
