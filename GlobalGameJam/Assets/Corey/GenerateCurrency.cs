using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateCurrency : MonoBehaviour {

    static int startCounter = 5;
    GameObject coin;
    public int poolSize = 10;
    List<GameObject> objectPool;
    public int counter = 0;

    public void CreateCoin()
    {
        objectPool[counter].transform.position = Vector2.zero;
        counter++;
        if (counter >= objectPool.Count)
            counter = startCounter;
    }

    void Awake()
    {
        CreatePool();
    }

    void CreatePool()
    {
        coin = Resources.Load("Prefabs/Coin", typeof(GameObject)) as GameObject;
        objectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            objectPool.Add(Instantiate(coin) as GameObject);
            objectPool[i].transform.parent = transform;
            objectPool[i].name = "Coin" + i;
            objectPool[i].SetActive(false);
        }
        for (int i = 0; i < 5; i++)
        {
            CreateCoin();
        }
    }

    void Start () {
    
    }
    
    void Update () {
    
    }
}
