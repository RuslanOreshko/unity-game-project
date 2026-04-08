using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundCheck))]
[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerJumo : MonoBehaviour
{
    [SerializeField] private float jupmForce = 7f;

    private Rigidbody2D rb;
    private GroundCheck groundCheck;
    private PlayerInputHandler input;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<GroundCheck>();
        input = GetComponent<PlayerInputHandler>();
    }

    private void FixedUpdate()
    {
        if(!groundCheck.IsGrounded) return;

        if(input.ConsumeJumpBuffered())
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                jupmForce
            );
        }
    }
}
