using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateHearts : MonoBehaviour 
{
    string name = "Heart";
    GameObject heart;
    GameObject emptyHeart;
    public int poolSize = 20;

    List<GameObject> objectPool;
    Vector2 position;

    void CreatePool()
    {
        heart = Resources.Load("Prefabs/Heart", typeof(GameObject)) as GameObject;
        objectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            objectPool.Add(Instantiate(heart) as GameObject);
            objectPool[i].transform.parent = transform;
            objectPool[i].name = name + i;
            objectPool[i].SetActive(false);
        }
    }

    void Start () 
    {
        CreatePool();
    }

}
