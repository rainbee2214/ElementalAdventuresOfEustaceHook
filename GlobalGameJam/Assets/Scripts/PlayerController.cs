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
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0 ||
            Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0) playerPhysics.Move();

        if (Input.GetButtonDown("Jump")) playerPhysics.Jump();

        playerPhysics.IsGrounded();
    }
}
