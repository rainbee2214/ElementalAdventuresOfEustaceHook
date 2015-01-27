using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MasterPool : MonoBehaviour
{
    List<string> objects = 
    new List<string>{
        "Heart", "Xp", "Currency", "Chest"
    };

    void Start()
    {
        foreach (string s in objects) Debug.Log(s);
    }
    public List<GameObject> CreatePool(Transform parent, string name, int poolSize)
    {
        GameObject poolObject = Resources.Load("Prefabs/PoolObjects/" + name, typeof(GameObject)) as GameObject;
        return CreatePool(parent, poolObject, name, poolSize);
    }

    public List<GameObject> CreatePool(Transform parent, GameObject poolObject, string name, int poolSize)
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
