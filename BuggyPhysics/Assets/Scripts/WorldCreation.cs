using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldCreation : MonoBehaviour {

	private IDictionary<int, Obstacle> obstaclePool = new Dictionary<int, Obstacle>();
	
	private const float WORLDTILELENGTH = 100;
	private const float SPEEDINCREASE = 0.5f;
	
	public WorldTile ModulePrefab;
	public Obstacle[] Obstacles;
	
	public GameObject PlayerObject;
	
	private IList<WorldTile> currentWorldTiles = new List<WorldTile>();
	
	void Start()
	{
		WorldTile startTile = CreateNewWorlTile(this.transform.position);
		WorldTile followTile = CreateNewWorlTile(new Vector3(startTile.transform.position.x, startTile.transform.position.y, startTile.transform.position.z + WORLDTILELENGTH));
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerObject.transform.position.z >= currentWorldTiles[0].transform.position.z + WORLDTILELENGTH)
		{
			//TODO: Add Obstacles
			MoveWorldTileToNewPosition();
		}
		WorldTile.Speed += SPEEDINCREASE * Time.deltaTime;
	}
	
	private WorldTile MoveWorldTileToNewPosition()
	{
		WorldTile tileToMove = currentWorldTiles[0];
		currentWorldTiles.RemoveAt(0);
		Vector3 newTilePos = new Vector3(tileToMove.transform.position.x, tileToMove.transform.position.y, tileToMove.transform.position.z + WORLDTILELENGTH * 2);
		tileToMove.transform.position = newTilePos;
		currentWorldTiles.Add(tileToMove);

		return tileToMove;
	}
	
	private WorldTile CreateNewWorlTile(Vector3 spawnPosition)
	{
		WorldTile worldTile = GameObject.Instantiate<WorldTile>(ModulePrefab);
		worldTile.transform.position = spawnPosition;
		currentWorldTiles.Add(worldTile);
		return worldTile;
	}
}
