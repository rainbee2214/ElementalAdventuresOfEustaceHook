using UnityEngine;
using System.Collections;

public class Heart : Collectable
{
    static Vector2 outOfView = new Vector2(-1000, -1000);

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameController.controller.playerStats.Health += 1;
            Reset();
        }
    }
}
