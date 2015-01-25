using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public PlayerPhysics playerPhysics;

    public bool ableToMove = true;

    void Awake()
    {
        playerPhysics = GetComponent<PlayerPhysics>();
    }

    void FixedUpdate()
    {
        if (ableToMove)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0) playerPhysics.Move(Input.GetAxisRaw("Horizontal"));
            else playerPhysics.Idle();

            if (Input.GetButtonDown("Jump")) playerPhysics.Jump();

            playerPhysics.IsGrounded();
        }
    }
}
