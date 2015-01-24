using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateChest : MonoBehaviour {

    GameObject chest;
    public int poolSize = 10;
    List<GameObject> objectPool;

    public void CreateCoin()
    {
        for (int i = 0; i < objectPool.Count; i++)
            objectPool[i].transform.position = Vector2.zero;
    }

    void CreatePool()
    {
        chest = Resources.Load("Prefabs/Chest", typeof(GameObject)) as GameObject;
        objectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            objectPool.Add(Instantiate(chest) as GameObject);
            objectPool[i].transform.parent = transform;
            objectPool[i].name = "Chest" + i;
            objectPool[i].SetActive(false);
        }
        for (int i = 0; i < 5; i++)
        {
            CreateCoin();
        }
    }

    void Awake()
    {
        CreatePool();
    }

    void Start () {
    
    }
    
    void Update () {
    
    }
}
