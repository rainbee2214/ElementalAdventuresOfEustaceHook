using UnityEngine;
using System.Collections;

public class Xp : MonoBehaviour {

    Vector2 outOfView = new Vector2(-1000, -1000);
    public bool isTracking = false;
    public float speed = 8.5f;

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
        Vector2 playerPosition = GameObject.Find("Player").transform.position;
        transform.position = Vector2.MoveTowards(transform.position, playerPosition, Time.deltaTime * speed);
    }

    public void ResetXp()
    {
        gameObject.SetActive(false);
        transform.position = outOfView;
        isTracking = false;
    }

    public void TurnXpOn(Vector2 newPosition)
    {
        newPosition.x += Random.Range(-16.0f, 16.1f);
        newPosition.y += Random.Range(0f, 5.1f);
        if (newPosition.x < 5.0f && newPosition.x > -5.0f)
            newPosition.x += 12.0f;
        transform.position = new Vector2(newPosition.x, newPosition.y);
        gameObject.SetActive(true);
        isTracking = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ResetXp();
            isTracking = false;
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
