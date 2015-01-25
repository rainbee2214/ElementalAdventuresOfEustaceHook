using UnityEngine;
using System.Collections;

public class Currency : MonoBehaviour
{
    Vector2 outOfView = new Vector2(-1000, -1000);

    ElementType element;
    public ElementType Element
    {
        get { return element; }
        set { element = value; }
    }

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

    public void ResetCoin()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        transform.position = outOfView;
    }

    public void TurnCoinOn(Vector2 newPosition)
    {
        gameObject.transform.parent.gameObject.SetActive(true);
        transform.position = newPosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ResetCoin();
            //Debug.Log("You have gained a coin.");
        }
    }
}