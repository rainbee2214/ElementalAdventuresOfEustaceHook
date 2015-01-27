using UnityEngine;
using System.Collections;

public class Xp : Collectable
{
    #region Public
    public bool isTracking = false;
    #endregion

    #region Private
    float speed = 16f;
    int amount;
    Color currentColor;
    GameObject player;
    Vector2 targetPosition;
    float value = 0.1f;
    #region
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

    void Start()
    {
        player = GameController.player;
    }

    void FixedUpdate()
    {
        if (isTracking)
        {
            Track();
        }
    }

    void Track()
    {
        targetPosition = player.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
    }

    public override void Reset()
    {
        base.Reset();
        isTracking = false;
    }

    public override void TurnOn(Vector2 newPosition)
    {
        newPosition.x += Random.Range(-16.0f, 16.1f);
        newPosition.y += Random.Range(0f, 5.1f);
            
        base.TurnOn(newPosition);
        isTracking = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameController.controller.GainXp(value);
            Reset();
        }
    }

}
