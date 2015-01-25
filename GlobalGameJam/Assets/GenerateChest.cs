using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateChest : MonoBehaviour {

    GameObject chest;
    public int poolSize = 10;
    List<GameObject> objectPool;
    Vector2 startingPosition = new Vector2(-5f, 1f); 

    void Awake()
    {
        CreatePool();
    }

    public void CreateChest()
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
            objectPool[i].transform.position = startingPosition;
            startingPosition.x -= 1.5f;
            objectPool[i].SetActive(true);
        }
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
        CreateChest();

    }

}
