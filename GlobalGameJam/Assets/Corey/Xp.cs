using UnityEngine;
using System.Collections;

public class Xp : MonoBehaviour {

    Vector2 outOfView = new Vector2(-1000, -1000);
    public Vector2 playerPosition = new Vector2(0,0);
    public bool isTracking = false;

    int amount;
    public int Amount
    {
        get { return amount; }
        set { amount += value; }
    }

    Color currentColor;
    public Color CurrentColor
    {
        get { return currentColor; }
        set { currentColor = value; }
    }

    void Track()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPosition, Time.deltaTime);
    }

    public void ResetXp()
    {
        gameObject.SetActive(false);
        transform.position = outOfView;
        isTracking = false;
    }

    public void TurnXpOn(Vector2 newPosition)
    {
        gameObject.SetActive(true);
        transform.position = newPosition;
        isTracking = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ResetXp();
            Debug.Log("You have gained Xp.");
        }
    }

    void Start () 
    {
    
    }
    
    void Update () 
    {
        if (isTracking)
        {
            Track();
        }
    }
}
