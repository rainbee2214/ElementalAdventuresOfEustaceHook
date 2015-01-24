using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HookshotController : MonoBehaviour
{
    float offset = 1f;
    GameObject head;
    GameObject tail;
    int currentLength = 2;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        head = Resources.Load("Prefabs/Hookshot/Head", typeof(GameObject)) as GameObject;
        tail = Resources.Load("Prefabs/Hookshot/Tail", typeof(GameObject)) as GameObject;
    }

    void FixedUpdate()
    {

    }

    void Extend()
    {
        ExtendAnimation(currentLength);
    }

    void CreateHookshot()
    {

    }

    void ExtendAnimation(int length)
    {
        switch (length)
        {
            case 1: break;
            case 2: break;
            case 3: break;
            case 4: break;
            case 5: break;
            case 6: break;
            case 7: break;
            case 8: break;
            case 9: break;
            case 10: break;
            case 11: break;
            case 12: break;
            case 13: break;
            case 14: break;
            case 15: break;
            case 16: break;
            case 17: break;
            case 18: break;
            case 19: break;
            case 20: break;
            default: break;
        }
    }
}
