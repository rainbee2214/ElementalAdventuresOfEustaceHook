using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Heart : MonoBehaviour {

    Vector2 outOfView = new Vector2(-1000, -1000);
    GameObject heart;
    GameObject emptyHeart;
    public int poolSize = 10;
    List<GameObject> objectPool;
    List<GameObject> objectPool2;
    public int current = 0;
    public GenerateDisplayHearts generateDisplayHearts;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GameController.controller.playerStats.Health += 1;
            ResetHeart();
        }
    }

    public void TurnHeartOn(Vector2 position)
    {
        heart.SetActive(true);
        if (position == generateDisplayHearts.HeartDisplayPosition)
        {
            heart.collider2D.enabled = false;
        }
        transform.position = position;
    }

    public void TurnEmptyHeartOn(Vector2 position)
    {
        emptyHeart.SetActive(true);
        transform.position = position;
    }

    public void ResetHeart()
    {
        heart.SetActive(false);
        emptyHeart.SetActive(false);
        transform.position = outOfView;
    }

    // Use this for initialization
    void Start () 
    {
        generateDisplayHearts = GameObject.FindGameObjectWithTag("DisplayHearts").GetComponent<GenerateDisplayHearts>();
    }
    
    // Update is called once per frame
    void Update () 
    {

    }
}
