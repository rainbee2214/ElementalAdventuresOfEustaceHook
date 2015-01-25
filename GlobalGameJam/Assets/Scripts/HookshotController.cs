using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AimHookshot))]
public class HookshotController : MonoBehaviour
{
    Animator anim;
    AimHookshot hookshot;

    public int currentLength = 6;
    public bool extend;
    public float moveSpeed = 1f;

    float linkLength = 0.5f;
    float numberOfLinks;

    bool attached = false;
    bool holding = false;
    bool ableToShoot = true;

    Vector2 collisionPoint;
    GameObject player;
    PlayerController playerController;

    float movePlayerDelay = 1f;
    float movePlayerTime;
    bool movePlayer;

    float delta = 0.25f;

    void Awake()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        hookshot = GetComponent<AimHookshot>();
    }

    void FixedUpdate()
    {
        if (ableToShoot) hookshot.AimHookShot();
        if (Input.GetButtonDown("Fire3")) extend = true;
        else if (Input.GetButton("Fire3")) ;//Do nothing
        else
        {
            ableToShoot = true;
            playerController.ableToMove = true;
            anim.enabled = true;
            attached = false;
        }

        if (extend) Extend();
        if (attached) Attach();
        if (movePlayer && Time.time > movePlayerTime) MovePlayerToPoint();
    }

    void Extend()
    {
        extend = false;
        ExtendAnimation(currentLength);
    }

    void Attach()
    {
        anim.enabled = false;
        ableToShoot = false;
        playerController.ableToMove = false;
        //Set a delay, after that delay move the player
        //Move the player to the CollisionPoint
        movePlayer = true;
        movePlayerTime = Time.time + movePlayerDelay;
    }

    void MovePlayerToPoint()
    {
        //if (player.transform.position.x + delta > collisionPoint.x && player.transform.position.y + delta > collisionPoint.y)
        //{
        //    player.rigidbody2D.gravityScale = playerController.playerPhysics.gravityScale;
        //    Debug.Log("Reach collision point!");
        //    movePlayer = false;
        //}
        //else
        //{
        //    //player.rigidbody2D.gravityScale = 0f;
        //    //player.transform.position = Vector2.Lerp(player.transform.position, collisionPoint, Time.deltaTime * moveSpeed);
        //    //Debug.Log("Moving player " + player.transform.position + " " + collisionPoint);
        //}
    }

    void ExtendAnimation(int length)
    {
        anim.SetTrigger(length+"");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (ableToShoot)
        {
            if (Input.GetButton("Fire3"))
            {
                attached = true;
            }
            collisionPoint = other.contacts[0].point;
            float distance = Vector2.Distance(transform.position, collisionPoint);
            numberOfLinks = distance / linkLength;
            //Debug.Log(other.gameObject.tag + " " + point + " Distance between point and player: " + distance + " and number of links: " + (int)links);
            if (numberOfLinks < 2) numberOfLinks = 2;
            anim.SetTrigger((int)numberOfLinks + "In");
        }
    }
}
