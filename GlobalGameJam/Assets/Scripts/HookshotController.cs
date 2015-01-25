using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HookshotController : MonoBehaviour
{
    float offset = 1f;
    GameObject head;
    GameObject tail;
    public int currentLength = 6;

    Animator anim;
    public bool extend;

    void Awake()
    {
        anim = GetComponent<Animator>();
        head = Resources.Load("Prefabs/Hookshot/Head", typeof(GameObject)) as GameObject;
        tail = Resources.Load("Prefabs/Hookshot/Tail", typeof(GameObject)) as GameObject;
    }

    void FixedUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePosition = mousePos;
        Debug.Log(mousePosition);
        if (Input.GetButtonDown("Fire3")) extend = true;
        if (extend) Extend(); 
    }

    void Extend()
    {
        extend = false;
        ExtendAnimation(currentLength);
    }

    void CreateHookshot()
    {

    }

    void ExtendAnimation(int length)
    {
        anim.SetTrigger(length+"");
    }
}
