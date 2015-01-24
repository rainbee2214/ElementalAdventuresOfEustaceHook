using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour
{
    PlayerPhysics playerPhysics;

    void Awake()
    {
        playerPhysics = GetComponent<PlayerPhysics>();
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0) playerPhysics.Move(Input.GetAxisRaw("Horizontal"));
        else playerPhysics.Idle();

        if (Input.GetButtonDown("Jump")) playerPhysics.Jump();

        playerPhysics.IsGrounded();
    }
}
