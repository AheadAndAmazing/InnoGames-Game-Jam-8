using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldTile : MonoBehaviour {

	public SpawnPointCluster[] ObstacleSpawnPoints;
	private const float MAXSPEED = 25.0f;

	[HideInInspector]
	public IList<Obstacle> PlacedObstacles = new List<Obstacle>();

	public static float Speed { 
		get { return speed; } 
		set { speed = Mathf.Clamp(value, 0, MAXSPEED); } 
	}
	
	private static float speed = 2.0f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(0.0f, 0.0f, -Speed * Time.deltaTime);
	}
}
