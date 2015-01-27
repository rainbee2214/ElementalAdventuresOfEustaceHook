using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeartController : MonoBehaviour 
{    
    #region Public
    public List<GameObject> pool;
    #endregion

    #region Private
    string name = "Heart";
    #endregion

    void Start()
    {
        GameController.controller.masterPool.GetPool(ref pool, name);
        //foreach (GameObject currency in pool) currency.SetActive(true);
    }

}
