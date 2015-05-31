using UnityEngine;
using System.Collections;

public class WackelPudding : MonoBehaviour {

	public float TheWackelEffect = 2.5f;
	public float WackelSpeed = 4;

	private float targetRot;
	private float curRot;

	public Animator animator;


	void Start()
	{
		this.targetRot = TheWackelEffect;
		TheWackelEffect *= -1;
		curRot = 0;
	}

	void Update () {

		curRot += Time.deltaTime * WackelSpeed *  Mathf.Sign(targetRot);

		transform.rotation = Quaternion.Euler(0, 0, curRot);

		if(Mathf.Abs(curRot) >= Mathf.Abs(this.targetRot))
		{
			this.targetRot *= -1;
		}

		this.animator.speed = WorldTile.Speed / 6;
	}
}
