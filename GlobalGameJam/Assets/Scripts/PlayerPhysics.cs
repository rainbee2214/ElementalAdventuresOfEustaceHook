using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour
{
    static string layer1 = "Enemies";
    static string layer2 = "Ground";
    static float delta = 0.25f;

    Vector2 position;
    float speed = 1f;

    bool grounded = true;
    public bool jumping = false;
    Vector2 jumpLocation;

    public float jumpDistance = 2f;
    public float gravityScale = 2f;
    public float jumpSpeed = 1f;

    void Awake()
    {
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
                Debug.Log("Reached location.");
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

    public void Move()
    {
        position = transform.position;

        position.x += Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;

        transform.position = position;
    }

    public void Jump()
    {
        if (grounded && !jumping)
        {
            jumpLocation = transform.position;
            jumpLocation.y += jumpDistance;
            jumping = true;
        }
        else
        {
            jumping = false;
            Debug.Log("Can't jump.");
        }
    }

    public void IsGrounded()
    {
        Debug.DrawRay(transform.position, new Vector2(0f, -1.5f), Color.white);

        int layerMask = 1 << LayerMask.NameToLayer(layer2);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1.5f, layerMask);
        if (hit.collider != null)
        {
            //Debug.Log("Ray is hitting something.");
            grounded = true;
        }
        else
        {
            //Debug.Log("Ray is not hitting something.");
            grounded = false;
        }

    }
}
