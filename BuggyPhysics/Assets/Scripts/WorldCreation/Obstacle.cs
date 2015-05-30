using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Obstacle : MonoBehaviour {

	public int SpawnSize;
	public int ObstacleDifficulty;
	private IList<SpawnPoint> occupiedSpawns = new List<SpawnPoint>();

	public bool TryRegisterOnSpawnPoint(SpawnPoint point)
	{
		if(point.OccupyingObstacle == null)
		{
			point.OccupyingObstacle = this;
			occupiedSpawns.Add(point);
			this.transform.parent = point.transform;
			return true;
		}
		return false;
	}

	public void RemoveFromSpawn()
	{
		foreach (var point in this.occupiedSpawns)
		{
			point.OccupyingObstacle = null;
		}
		this.occupiedSpawns.Clear();
	}
}
