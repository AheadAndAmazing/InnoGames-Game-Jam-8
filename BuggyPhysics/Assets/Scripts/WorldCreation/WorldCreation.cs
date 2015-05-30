using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class WorldCreation : MonoBehaviour {


	private const float WORLDTILELENGTH = 100;
	private const float SPEEDINCREASE = 0.5f;

	public static int CurrentDifficultyLvl { get { return curDiff; } set { curDiff = Mathf.Clamp(value, 0, 5); } }
	private static int curDiff = 1;
	
	public GameObject PlayerObject;
	
	private IList<WorldTile> currentWorldTiles = new List<WorldTile>();
	
	void Start()
	{
		WorldTile startTile = CreateNewWorlTile(this.transform.position);
		WorldTile followTile = CreateNewWorlTile(new Vector3(startTile.transform.position.x, startTile.transform.position.y, startTile.transform.position.z + WORLDTILELENGTH));
		WorldTile endTile = CreateNewWorlTile(new Vector3(followTile.transform.position.x, followTile.transform.position.y, followTile.transform.position.z + WORLDTILELENGTH));
		currentWorldTiles.Add(startTile);
		currentWorldTiles.Add(followTile);
		currentWorldTiles.Add(endTile);
		AddObstaclesToWorldTile(startTile, CurrentDifficultyLvl);
		AddObstaclesToWorldTile(followTile, CurrentDifficultyLvl);
		AddObstaclesToWorldTile(endTile, CurrentDifficultyLvl);
		
	}
	
	void Update () {
		if(PlayerObject.transform.position.z >= currentWorldTiles[0].transform.position.z + WORLDTILELENGTH*2)
		{
			MoveWorldTileToNewPosition();
		}
		WorldTile.Speed += SPEEDINCREASE * Time.deltaTime;
	}

	private WorldTile MoveWorldTileToNewPosition()
	{
		WorldTile tileToMove = currentWorldTiles[0];
		currentWorldTiles.RemoveAt(0);
		Vector3 newTilePos = new Vector3(tileToMove.transform.position.x, tileToMove.transform.position.y, tileToMove.transform.position.z + WORLDTILELENGTH * 3);
		tileToMove.transform.position = newTilePos;
		currentWorldTiles.Add(tileToMove);
		FreeObstacleFromWorldTile(tileToMove);
		
		AddObstaclesToWorldTile(tileToMove, CurrentDifficultyLvl);
		CurrentDifficultyLvl++;
		return tileToMove;
	}
	
	private WorldTile CreateNewWorlTile(Vector3 spawnPosition)
	{
		GameObject worldTile = ObjectPool.Current.GetPooledObject(PrefabTypes.WorldTile);
		worldTile.transform.position = spawnPosition;
		worldTile.SetActive(true);
		
		return worldTile.GetComponent<WorldTile>();
	}

	private void FreeObstacleFromWorldTile(WorldTile tile)
	{
		foreach(Obstacle obst in tile.PlacedObstacles)
		{
			obst.transform.parent = null;
			obst.gameObject.SetActive(false);
		}
		tile.PlacedObstacles.Clear();
	}

	private void AddObstaclesToWorldTile(WorldTile tile, int obstacleLvlPoints)
	{
		for (int i = 0; i < obstacleLvlPoints; i++)
			{
				int ChooseSpawnCluster = Random.Range(0, tile.ObstacleSpawnPoints.Length);
				int ChooseStartSpawnPoint = Random.Range(0, tile.ObstacleSpawnPoints[ChooseSpawnCluster].spawnPoints.Length);
				int obstacleCost = SpawnObstacle(tile.ObstacleSpawnPoints[ChooseSpawnCluster].spawnPoints[ChooseStartSpawnPoint], tile);
			}
	}

	private int SpawnObstacle( SpawnPoint point, WorldTile tile)
	{
		GameObject obj = ObjectPool.Current.GetPooledObject(PrefabTypes.Obstacle);
		obj.transform.position = point.transform.position;

		int obstacleCost = 0;
		Obstacle obs = obj.GetComponent<Obstacle>();
		if (obs.TryRegisterOnSpawnPoint(point))
		{
			obj.SetActive(true);
			tile.PlacedObstacles.Add(obs);
			obstacleCost = obs.ObstacleDifficulty;
		}
		
		return obstacleCost;
	}
}
