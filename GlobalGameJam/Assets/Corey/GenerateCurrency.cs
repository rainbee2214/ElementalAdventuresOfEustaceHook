using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateCurrency : MonoBehaviour 
{
    Vector2 startPosition = new Vector2(5f, 2f);
    static int startCounter = 5;
    GameObject coin;
    public int poolSize = 10;
    List<GameObject> objectPool;
    public int counter = 0;

    public void CreateCoin()
    {
        objectPool[counter].transform.position = startPosition;
        objectPool[counter].SetActive(true);
        counter++;
        if (counter >= objectPool.Count)
            counter = startCounter;
    }

    public void CreateCoinFromChest(Vector2 chestPosition)
    {
        chestPosition.x += Random.Range(-4.0f, 4.1f);
        chestPosition.y += Random.Range(0f, 1.1f);
        if (chestPosition.x < 1.0 && chestPosition.x > -1.0)
        {
            chestPosition.x += 2.0f;
        }
        objectPool[counter].transform.position = chestPosition;
        objectPool[counter].SetActive(true);
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
            startPosition.x += -1.5f;
        }
    }

    void Start () {
    
    }
    
    void Update () {
    
    }
}
