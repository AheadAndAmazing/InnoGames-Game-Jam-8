using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PrefabTypes
{
	WorldTile,
	Obstacle
}

public class ObjectPool : MonoBehaviour {

	public static ObjectPool Current;
	public GameObject[] PooledObject;
	public int PooledAmount = 3;
	public bool WillGrow = true;

	private IList<GameObject> worldTiles;
	private IList<GameObject> obstacles;

	void Awake()
	{
		Current = this;
		worldTiles = new List<GameObject>();
		obstacles = new List<GameObject>();
		for (int i = 0; i < PooledAmount; i++)
		{
			GameObject obj = (GameObject)Instantiate(PooledObject[(int)PrefabTypes.WorldTile]);
			obj.SetActive(false);
			worldTiles.Add(obj);

			for (int k = 1; k < PooledObject.Length; k++)
			{
				GameObject obs = (GameObject)Instantiate(PooledObject[k]);
				obs.SetActive(false);
				obstacles.Add(obs);
			}

		}
	}

	void Start () {
		
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
		else
		{
			for (int i = 0; i < obstacles.Count; i++)
			{
				if (!obstacles[i].activeInHierarchy)
				{
					return obstacles[i];
				}
			}
		}
		
		if(WillGrow)
		{
			GameObject obj;
			if (type == PrefabTypes.WorldTile)
			{
				obj = (GameObject)Instantiate(PooledObject[(int)type]);
				worldTiles.Add(obj);
			}
			else
			{
				obj = (GameObject)Instantiate(PooledObject[Random.Range(1, PooledObject.Length)]);
				obstacles.Add(obj);
				PooledAmount++;
			}
			obj.SetActive(false);
			return obj;
		}
		return null;
	}
}
