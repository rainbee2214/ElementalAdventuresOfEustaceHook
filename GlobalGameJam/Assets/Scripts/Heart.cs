using UnityEngine;
using System.Collections;

public class Heart : Collectable
{
    int value = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameController.controller.playerStats.Health = value;
            Reset();
        }
    }
}
