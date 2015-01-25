using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EmptyHeart : MonoBehaviour {

    Vector2 outOfView = new Vector2(-1000, -1000);
    GameObject emptyHeart;
    List<GameObject> objectPool;
    public GenerateDisplayHearts generateDisplayHearts;


    public void TurnEmptyHeartOn(Vector2 position)
    {
        gameObject.SetActive(true);
        transform.position = position;
    }

    public void ResetEmptyHeart()
    {
        gameObject.SetActive(false);
        transform.position = outOfView;
    }

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
    
    }
}
