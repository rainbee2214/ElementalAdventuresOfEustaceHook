using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour
{
    string layer1 = "Enemies";
    string layer2 = "Ground";

    Vector2 position;
    float speed = 1f;

    bool grounded = true;
    float jumpDistance = 2f;

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
        if (grounded)
        {
            //Jumping logic
            transform.Translate(new Vector3(0f, jumpDistance, 0f));
            Debug.Log("Jump!");
        }
        else
        {
            Debug.Log("Can't jump.");
        }
    }

    public void IsGrounded()
    {
        Debug.DrawRay(transform.position, -Vector2.up*2.25f, Color.white);

        int layerMask = 1 << LayerMask.NameToLayer(layer1) | 1 << LayerMask.NameToLayer(layer2);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.55f, layerMask);
        if (hit.collider != null)
        {
            Debug.Log("Ray is hitting something.");
            grounded = true;
        }
        else
        {
            //Debug.Log("Ray is not hitting something.");
            grounded = false;
        }

    }
}
