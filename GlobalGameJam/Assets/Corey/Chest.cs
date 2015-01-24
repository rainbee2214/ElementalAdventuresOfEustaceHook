using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chest : MonoBehaviour {

    public bool ChestOpen = false;
    GenerateCurrency createCoin;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (ChestOpen == false)
            {
                if(Input.GetButtonDown("Fire1"))
                {
                    OpenChest();
                    Debug.Log("Chest opened.");
                }
            }
        }
    }

    void OpenChest()
    {
        int num = Random.Range(0, 10);
        int num1 = num % 4;
        int num2 = num / 2;
        for (int i = 0; i < num1; i++)
        {
            createCoin.CreateCoin();
        }
        for (int i = 0; i < num2; i++)
        {
            //Same as above but for XP
        }
    }

    public void TurnChestOn(Vector2 newPosition)
    {
        gameObject.SetActive(true);
        transform.position = newPosition;
    }


    void Start () 
    {
        createCoin = GameObject.Find("CoinGenerator").GetComponent<GenerateCurrency>();
    }
    
    void Update () {
    
    }
}
