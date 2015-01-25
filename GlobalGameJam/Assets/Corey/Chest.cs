using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chest : MonoBehaviour {

    public bool ChestOpen = false;
    GenerateCurrency createCoin;
    GenerateXp generateXp;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player is touching chest...");
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Chest opened.");
                OpenChest();
            }
        }
    }

    void OpenChest()
    {
        int num = Random.Range(0, 10);

        int num1 = num % 4;
        int num2 = num / 2;

        if (num2 == 0) num2 = 1;
        Debug.Log(num1 + " " + num2);
        for (int i = 0; i < num1; i++)
        {
            //Debug.Log("Generating coins!");
            createCoin.CreateCoin();
        }
        for (int i = 0; i < num2; i++)
        {
            //Debug.Log("Generating xp!");
            generateXp.CreateXp();
        }

        TurnChestOff();
    }

    public void TurnChestOn(Vector2 newPosition)
    {
        gameObject.SetActive(true);
        transform.position = newPosition;
    }

    public void TurnChestOff()
    {
        gameObject.SetActive(false);
    }


    void Start () 
    {
        createCoin = GameObject.Find("CoinGenerator").GetComponent<GenerateCurrency>();
        generateXp = GameObject.Find("XpGenerator").GetComponent<GenerateXp>();
    }
    
    void Update () 
    {

    }
}
