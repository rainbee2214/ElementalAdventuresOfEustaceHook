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
    List<GameObject> currencyPool;
    #endregion

    void Start()
    {
        anim = GetComponent<Animator>();
        GameController.controller.masterPool.GetPool(ref xpPool, "Xp");
        GameController.controller.masterPool.GetPool(ref currencyPool, "Currency");
    }

    void Open()
    {
        anim.SetTrigger("OpenChest");
        open = true;

        for (int i = 0; i < Random.Range(4, 10)%4; i++)
        {
            Debug.Log("Generating coins!");
            int topOfPool = GameController.controller.currencyController.TopOfPool;

            Vector2 offset = new Vector2(Random.Range(2, 5), Random.Range(0f, 0.5f));
            switch (Random.Range(0, 2))
            {
                case 0: offset.x *= -1; break;
                case 1: break;
                default: break;
            }
            offset.x += transform.position.x;
            offset.y += transform.position.y;
            currencyPool[topOfPool].GetComponent<Currency>().TurnOn(offset);
            topOfPool++;
            if (topOfPool >= currencyPool.Count) topOfPool = 0;
            GameController.controller.currencyController.TopOfPool = topOfPool;
        }
        for (int i = 0; i < Random.Range(1,6); i++)
        {
            Debug.Log("Generating xp!");
            int topOfPool = GameController.controller.xpController.TopOfPool;
            xpPool[topOfPool].GetComponent<Xp>().TurnOn(transform.position);
            topOfPool++;
            if (topOfPool >= xpPool.Count) topOfPool = 0;
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
