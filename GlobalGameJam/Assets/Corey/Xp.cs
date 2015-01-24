using UnityEngine;
using System.Collections;

public class Xp : MonoBehaviour {

    Vector2 outOfView = new Vector2(-1000, -1000);

    Vector2 trackPlayer = new Vector2(20, 20);

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

    public void ResetXp()
    {
        gameObject.SetActive(false);
        transform.position = outOfView;
    }

    public void TurnXpOn(Vector2 newPosition)
    {
        gameObject.SetActive(true);
        transform.position = newPosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ResetXp();
            Debug.Log("You have gained Xp.");
        }
    }

    void Start () {
    
    }
    
    void Update () {
    
    }
}
