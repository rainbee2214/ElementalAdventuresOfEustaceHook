using UnityEngine;
using System.Collections;

public class Currency : Collectable
{
    #region Public

    #endregion

    #region Private
    Element element;
    int amount;
    Color currentColor;

    #region Properties
    public Element Element
    {
        get { return element; }
        set { element = value; }
    }
    public int Amount
    {
        get { return amount; }
        set { amount += value; }
    }
    public Color CurrentColor
    {
        get { return currentColor; }
        set { currentColor = value; }
    }
    #endregion
    #endregion

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player1")
        {
            Reset();
        }
    }
}