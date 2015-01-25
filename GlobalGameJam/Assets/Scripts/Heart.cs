using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Heart : MonoBehaviour {

    Vector2 outOfView = new Vector2(-1000, -1000);
    GameObject heart;
    public int poolSize = 10;
    List<GameObject> objectPool;
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
        gameObject.SetActive(true);
        transform.position = position;
    }

    public void ResetHeart()
    {
        gameObject.SetActive(false);
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
