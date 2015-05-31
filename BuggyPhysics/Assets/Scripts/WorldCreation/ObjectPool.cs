using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PrefabTypes
{
	WorldTile,
	Obstacle,
	Root
}

public class ObjectPool : MonoBehaviour {

	public static ObjectPool Current;
	public GameObject[] PooledObject;
	public int PooledAmount = 1;
	public bool WillGrow = true;

	public int WorldTilesObjectStart = 0;
	public int ObstacleObjectsStart = 1;
	public int RootObstacleStart = 6;

	private IList<GameObject> worldTiles;
	private IList<GameObject> obstacles;
	private IList<GameObject> roots;

	void Awake()
	{
		Current = this;
		worldTiles = new List<GameObject>();
		obstacles = new List<GameObject>();
		roots = new List<GameObject>();

		for (int i = 0; i < PooledAmount; i++)
		{
			GameObject obj = (GameObject)Instantiate(PooledObject[(int)PrefabTypes.WorldTile]);
			obj.SetActive(false);
			worldTiles.Add(obj);

			for (int k = 1; k < RootObstacleStart; k++)
			{
				GameObject obs = (GameObject)Instantiate(PooledObject[k]);
				obs.SetActive(false);
				obstacles.Add(obs);
			}

			GameObject obr = (GameObject)Instantiate(PooledObject[RootObstacleStart]);
			obr.SetActive(false);
			roots.Add(obr);
		}
	}

	public GameObject GetPooledObject(PrefabTypes type)
	{
		if(type == PrefabTypes.WorldTile)
		{
			for (int i = 0; i < worldTiles.Count; i++)
			{
				if (!worldTiles[i].activeInHierarchy)
				{
					return worldTiles[i];
				}
			}
		}
		else if(type == PrefabTypes.Obstacle)
		{
			for (int i = 0; i < obstacles.Count; i++)
			{
				if (!obstacles[i].activeInHierarchy)
				{
					return obstacles[i];
				}
			}
		}
		else
		{
			for (int i = 0; i < roots.Count; i++)
			{
				if(!roots[i].activeInHierarchy)
				{
					return roots[i];
				}
			}
		}
		
		if(WillGrow)
		{
			GameObject obj;
			if (type == PrefabTypes.WorldTile)
			{
				obj = (GameObject)Instantiate(PooledObject[Random.Range(WorldTilesObjectStart,ObstacleObjectsStart)]);
				worldTiles.Add(obj);
			}
			else if(type == PrefabTypes.Obstacle)
			{
				obj = (GameObject)Instantiate(PooledObject[Random.Range(ObstacleObjectsStart, RootObstacleStart)]);
				obstacles.Add(obj);
				PooledAmount++;
			}
			else
			{
				obj = (GameObject) Instantiate(PooledObject[RootObstacleStart]);
				roots.Add(obj);
			}
			obj.SetActive(false);
			return obj;
		}
		return null;
	}
}
