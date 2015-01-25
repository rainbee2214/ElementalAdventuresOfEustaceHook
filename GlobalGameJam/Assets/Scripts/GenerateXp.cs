using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateXp : MonoBehaviour {

    GameObject xp;
    public int poolSize = 10;
    List<GameObject> objectPool;
    public int current = 0;

    public void CreateXp(Vector2 chestPosition)
    {
        objectPool[current].GetComponent<Xp>().TurnXpOn(chestPosition);
        current++;
        if(current >= 10)
        {
            current = 0;
        }
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
