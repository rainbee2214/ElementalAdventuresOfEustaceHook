using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateDisplayHearts : MonoBehaviour {

    Vector2 outOfView = new Vector2(-1000, -1000);
    GameObject heart;
    GameObject emptyHeart;
    public int poolSize = 10;
    List<GameObject> objectPool;
    List<GameObject> objectPool2;
    public Vector2 HeartDisplayPosition;

    void CreatePool()
    {
        heart = Resources.Load("Prefabs/Heart", typeof(GameObject)) as GameObject;
        objectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            objectPool.Add(Instantiate(heart) as GameObject);
            objectPool[i].transform.parent = transform;
            objectPool[i].name = "Heart" + i;
            objectPool[i].SetActive(false);
        }

        heart = Resources.Load("Prefabs/EmptyHeart", typeof(GameObject)) as GameObject;
        objectPool2 = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            objectPool2.Add(Instantiate(emptyHeart) as GameObject);
            objectPool2[i].transform.parent = transform;
            objectPool2[i].name = "EmptyHeart" + i;
            objectPool2[i].SetActive(false);
        }
    }

    float ScreenW;
    float ScreenH;
    void DisplayHealth()
    {
        ScreenW = Screen.width;
        ScreenH = Screen.height;
        HeartDisplayPosition = new Vector2(ScreenW - ScreenW / 10f, ScreenH - ScreenH / 10f);
        for (int i = 0; i < GameController.controller.playerStats.Health; i++ )
        {
            objectPool[i].GetComponent<Heart>().TurnHeartOn(HeartDisplayPosition);
            HeartDisplayPosition.x += 1.5f;
        }
        for (int i = GameController.controller.playerStats.Health; i <= poolSize; i++)
        {
            objectPool[i].GetComponent<Heart>().TurnEmptyHeartOn(HeartDisplayPosition);
            HeartDisplayPosition.x += 1.5f;
        }
    }

	// Use this for initialization
	void Start () 
    {
	    CreatePool();
	}
	
	// Update is called once per frame
	void Update () 
    {
        DisplayHealth();
	}
}
