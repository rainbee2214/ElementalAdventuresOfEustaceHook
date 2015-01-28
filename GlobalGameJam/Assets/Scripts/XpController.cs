using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class XpController : MonoBehaviour 
{
    #region Public
    public List<GameObject> pool;
    public int TopOfPool
    {
        set { topOfPool = value; }
        get { return topOfPool; }
    }
    #endregion

    #region Private
    int topOfPool;
    string name = "Xp";
    #endregion

    void Start()
    {
        GameController.controller.masterPool.GetPool(ref pool, name);
    }

}
