using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chest : MonoBehaviour {

    public bool ChestOpen = false;
    GenerateCurrency createCoin;
    GenerateXp generateXp;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!ChestOpen)
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
        int num = 7;
        int num1 = num % 4;
        int num2 = num / 2;
        for (int i = 0; i < num1; i++)
        {
            createCoin.CreateCoin();
        }
        for (int i = 0; i < num2; i++)
        {
            generateXp.CreateXp();
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
        generateXp = GameObject.Find("XpGenerator").GetComponent<GenerateXp>();
    }
    
    void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            OpenChest();
            Debug.Log("Chest opened.");
        }
    }
}
