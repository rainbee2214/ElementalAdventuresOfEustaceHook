using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MasterPool : MonoBehaviour
{
    string[] objects = new string[4]
    {
        "Heart", "Xp", "Currency", "Chest"
    };

    public int[] sizes = new int[4]
    {
        10, 10, 10, 10
    };
    List<List<GameObject>> pools;
    List<GameObject> poolOrganizers;

    public void GetPool(ref List<GameObject> pool, string name)
    {
        if (pool == null) pool = new List<GameObject>();
        switch (name)
        {
            case "Heart": pool = pools[0]; break;
            case "Xp": pool = pools[1]; break;
            case "Currency": pool = pools[2]; break;
            case "Chest": pool = pools[3]; break;
            default: break;
        }
    }
    void Awake()
    {
        CreatePools();
    }

    void CreatePools()
    {
        pools = new List<List<GameObject>>();
        poolOrganizers = new List<GameObject>();
        int count = 0;
        foreach (string s in objects)
        {
            GameObject poolOrganizer = new GameObject(s);
            poolOrganizer.transform.parent = transform;
            poolOrganizers.Add(poolOrganizer);
            pools.Add(CreatePool(poolOrganizer.transform, s, sizes[count]));
            count++;
        }
    }

    List<GameObject> CreatePool(Transform parent, string name, int poolSize)
    {
        GameObject poolObject = Resources.Load("Prefabs/PoolObjects/" + name, typeof(GameObject)) as GameObject;
        return CreatePool(parent, poolObject, name, poolSize);
    }

    List<GameObject> CreatePool(Transform parent, GameObject poolObject, string name, int poolSize)
    {
        List<GameObject> pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            pool.Add(Instantiate(poolObject) as GameObject);
            pool[i].name = name + i;
            pool[i].transform.parent = parent;
            pool[i].SetActive(false);
        }
        return pool;
    }
}
