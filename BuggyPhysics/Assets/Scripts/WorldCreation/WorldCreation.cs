﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class WorldCreation : MonoBehaviour {

	private const float WORLDTILELENGTH = 100;
	private float SPEEDINCREASE = 0.5f;

	public static int CurrentDifficultyLvl { get { return curDiff; } set { curDiff = Mathf.Clamp(value, 1, 14); } }
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
		SPEEDINCREASE = Mathf.Sqrt(WorldTile.Speed)/10.0f;
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
		AddEggToWorldTile(tileToMove);
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
			obst.RemoveFromSpawn();
			obst.transform.parent = null;
			obst.gameObject.SetActive(false);
		}
		tile.PlacedObstacles.Clear();
	}

	private void AddEggToWorldTile(WorldTile tile)
	{
		bool hasSpawned= false;
		int counter = 0;
		while (!hasSpawned)
		{
			int ChooseSpawnCluster = Random.Range(0, tile.ObstacleSpawnPoints.Length);
			int ChooseStartSpawnPoint = Random.Range(0, tile.ObstacleSpawnPoints[ChooseSpawnCluster].spawnPoints.Length);
			SpawnPoint point = tile.ObstacleSpawnPoints[ChooseSpawnCluster].spawnPoints[ChooseStartSpawnPoint];
			GameObject obj = ObjectPool.Current.GetPooledObject(PrefabTypes.Egg);
			obj.transform.position = point.transform.position;
			Obstacle obs = obj.GetComponent<Obstacle>();

			if (obs.TryRegisterOnSpawnPoint(point))
			{
				PickupKugel pick = obj.GetComponent<PickupKugel>();
				tile.PlacedObstacles.Add(obs);
				pick.tile = tile;
				obj.SetActive(true);
				hasSpawned = true;
			}
			else
			{
				counter++;
				hasSpawned = counter > 3;
			}
		}
	}

	private void AddObstaclesToWorldTile(WorldTile tile, int obstacleLvlPoints)
	{
		for (int i = 0; i < obstacleLvlPoints; i++)
			{
				int ChooseSpawnCluster = Random.Range(0, tile.ObstacleSpawnPoints.Length);
				int ChooseStartSpawnPoint = Random.Range(0, tile.ObstacleSpawnPoints[ChooseSpawnCluster].spawnPoints.Length);
				SpawnObstacle(tile.ObstacleSpawnPoints[ChooseSpawnCluster].spawnPoints[ChooseStartSpawnPoint], tile);
			}
		if(obstacleLvlPoints >= 5)
		{
			SpawnPoint point = tile.RootSpawns.spawnPoints[Random.Range(0, 2)];
			GameObject root = ObjectPool.Current.GetPooledObject(PrefabTypes.Root);
			root.transform.position = point.transform.position;
			Obstacle obs = root.GetComponent<Obstacle>();
			if(obs.TryRegisterOnSpawnPoint(point))
			{
				root.SetActive(true);
				tile.PlacedObstacles.Add(obs);
			}
		}
	}

	private void SpawnObstacle( SpawnPoint point, WorldTile tile)
	{
		GameObject obj = ObjectPool.Current.GetPooledObject(PrefabTypes.Obstacle);
		obj.transform.position = point.transform.position;

		Obstacle obs = obj.GetComponent<Obstacle>();
		if (obs.TryRegisterOnSpawnPoint(point))
		{
			obj.SetActive(true);
			tile.PlacedObstacles.Add(obs);
		}
	}
}
