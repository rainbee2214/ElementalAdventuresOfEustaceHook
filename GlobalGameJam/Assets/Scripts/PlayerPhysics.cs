using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerAnimation))]
public class PlayerPhysics : MonoBehaviour
{
    //static string layer1 = "Enemies";
    static string layer2 = "Ground";
    static float delta = 0.25f;

    PlayerAnimation playerAnimation;

    Vector2 position;
    public float speed = 1f;

    bool grounded = true;
    public bool jumping = false;
    Vector2 jumpLocation;

    public float jumpDistance = 2f;
    public float gravityScale = 2f;
    public float jumpSpeed = 1f;

    void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        jumpDistance += delta;  
    }

    void FixedUpdate()
    {
        
        if (jumping)
        {
            rigidbody2D.gravityScale = 0;
            transform.position = Vector2.Lerp(transform.position, jumpLocation, Time.deltaTime * jumpSpeed);
            if (Mathf.Abs(transform.position.y) + delta > Mathf.Abs(jumpLocation.y))
            {
                jumping = false;
            }
        }
        else rigidbody2D.gravityScale = gravityScale;
    }

    public bool Grounded
    {
        get { return grounded; }
        set { grounded = value; }
    }

    public void Move(float x)
    {
        position = transform.position;

        position.x += x * speed * Time.deltaTime;

        if (x > 0)
        {
            playerAnimation.WalkRight();
        }
        else if (x < 0)
        {
            playerAnimation.WalkLeft();
        }

        transform.position = position;
    }

    public void Idle()
    {
        playerAnimation.Idle();
    }

    public void Jump()
    {
        if (grounded && !jumping)
        {
            jumpLocation = transform.position;
            jumpLocation.y += jumpDistance;
            jumping = true;
        }
        else if (!grounded)
        {
            //Debug.Log("Can't jump.");
        }
    }

    public void IsGrounded()
    {
        int layerMask = 1 << LayerMask.NameToLayer(layer2);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1.5f, layerMask);
        if (hit.collider != null)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

    }
}
