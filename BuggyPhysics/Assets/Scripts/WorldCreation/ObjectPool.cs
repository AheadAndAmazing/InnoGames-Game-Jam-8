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

	private IDictionary<PrefabTypes, IList<GameObject>> pooledObjects;
	private IList<GameObject> worldTiles;
	private IList<GameObject> obstacles;

	void Awake()
	{
		Current = this;
		pooledObjects = new Dictionary<PrefabTypes, IList<GameObject>>();
		worldTiles = new List<GameObject>();
		obstacles = new List<GameObject>();
		pooledObjects.Add(PrefabTypes.WorldTile, worldTiles);
		pooledObjects.Add(PrefabTypes.Obstacle, obstacles);
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
		IList<GameObject> curList;
		this.pooledObjects.TryGetValue(type, out curList);

		for (int i = 0; i < pooledObjects.Count; i++)
		{
			if(!curList[i].activeInHierarchy)
			{
				return curList[i];
			}
		}
		if(WillGrow)
		{
			GameObject obj;
			if (type == PrefabTypes.WorldTile)
			{
				obj = (GameObject)Instantiate(PooledObject[(int)type]);
				curList.Add(obj);
			}
			else
			{
				obj = (GameObject)Instantiate(PooledObject[Random.Range(1, PooledObject.Length)]);
				curList.Add(obj);
			}
			return obj;
		}
		return null;
	}
}
