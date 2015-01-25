using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HookshotController : MonoBehaviour
{
    public int currentLength = 6;
    float linkLength = 0.5f;
    Animator anim;
    public bool extend;
    bool attached = false;
    bool holding = false;
    float numberOfLinks;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire3")) extend = true;
        else if (Input.GetButton("Fire3"))
        {

        }
        else
        {
            attached = false;
        }
        if (extend) Extend();
        if (attached) Attach();
    }

    void Extend()
    {
        extend = false;
        ExtendAnimation(currentLength);
    }

    void Attach()
    {
        Debug.Log("ATTACHED!");
    }

    void CreateHookshot()
    {

    }

    void ExtendAnimation(int length)
    {
        anim.SetTrigger(length+"");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (Input.GetButton("Fire3"))
        {
            attached = true;
            Debug.Log("Holding button");
        }
        Vector2 point = other.contacts[0].point;
        float distance = Vector2.Distance(transform.position, point);
        numberOfLinks = distance / linkLength;
        //Debug.Log(other.gameObject.tag + " " + point + " Distance between point and player: " + distance + " and number of links: " + (int)links);
        anim.SetTrigger((int)numberOfLinks + "In");
    }
}
