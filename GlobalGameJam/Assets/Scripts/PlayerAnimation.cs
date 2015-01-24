using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Idle()
    {
        anim.SetBool("WalkLeft", false);
        anim.SetBool("WalkRight", false);
    }

    public void WalkLeft()
    {
        anim.SetBool("WalkLeft", true);
        anim.SetBool("WalkRight", false);
    }

    public void WalkRight()
    {
        anim.SetBool("WalkLeft", false);
        anim.SetBool("WalkRight", true);
    }
}
