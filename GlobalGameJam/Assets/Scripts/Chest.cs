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

        for (int i = 0; i < Random.Range(0, 10)%4; i++)
        {
            //Debug.Log("Generating coins!");
        }
        for (int i = 0; i < Random.Range(1,6); i++)
        {
            Debug.Log("Generating xp!");
            int topOfPool = GameController.controller.xpController.TopOfPool;
            xpPool[topOfPool].GetComponent<Xp>().TurnOn(transform.position);
            topOfPool++;
            if (topOfPool >= xpPool.Count) topOfPool++;
            GameController.controller.xpController.TopOfPool = topOfPool;
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
