using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chest : Collectable
{
    #region Public
    public bool open = false;
    Animator anim;
    #endregion

    #region Private
    #endregion

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Open()
    {
        anim.SetTrigger("OpenChest");
        open = true;

        int num = Random.Range(0, 10);
        int num1 = num % 4;
        int num2 = num / 2;
        if (num2 == 0) num2 = 1;

        for (int i = 0; i < num1; i++)
        {
            //Debug.Log("Generating coins!");
        }
        for (int i = 0; i < num2; i++)
        {
            //Debug.Log("Generating xp!");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && !open && Input.GetButtonDown("Fire1"))
        {
            Open();
        }
    }
}
