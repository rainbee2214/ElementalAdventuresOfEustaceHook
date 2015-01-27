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
    List<GameObject> xpPool;
    int topOfXpPool;
    #endregion

    void Start()
    {
        anim = GetComponent<Animator>();
        GameController.controller.masterPool.GetPool(ref xpPool, "Xp");
    }

    void Open()
    {
        anim.SetTrigger("OpenChest");
        open = true;

        for (int i = 0; i < Random.Range(0, 10); i++)
        {
            //Debug.Log("Generating coins!");
        }
        for (int i = 0; i < Random.Range(1,6); i++)
        {
            Debug.Log("Generating xp!");
            xpPool[topOfXpPool].GetComponent<Xp>().TurnOn(transform.position);
            topOfXpPool++;
            if (topOfXpPool >= xpPool.Count) topOfXpPool++;
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
