using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireballController : MonoBehaviour
{
    #region Public
    public List<GameObject> pool;
    public int topOfPool = 0;
    #endregion

    #region Private
    string name = "Fireball";
    #endregion

    void Start()
    {
        GameController.controller.masterPool.GetPool(ref pool, name);
        //foreach (GameObject currency in pool) currency.SetActive(true);
    }
    
    public void Fire(Vector2 position)
    {
        pool[topOfPool].GetComponent<Fireball>().Fire(position);
        topOfPool++; if (topOfPool >= pool.Count) topOfPool = 0;
    }
}
