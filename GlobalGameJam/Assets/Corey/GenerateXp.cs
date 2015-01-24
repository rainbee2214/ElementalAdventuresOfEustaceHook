using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateXp : MonoBehaviour {

    GameObject xp;
    public int poolSize = 20;
    List<GameObject> objectPool;

    public void CreateXp()
    {
        for (int i = 0; i < objectPool.Count; i++)
            objectPool[i].transform.position = Vector2.zero;
    }

    void CreatePool()
    {
        xp = Resources.Load("Prefabs/Xp", typeof(GameObject)) as GameObject;
        objectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            objectPool.Add(Instantiate(xp) as GameObject);
            objectPool[i].transform.parent = transform;
            objectPool[i].name = "Xp" + i;
            objectPool[i].SetActive(false);
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
