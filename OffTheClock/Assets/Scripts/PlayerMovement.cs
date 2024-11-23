using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public BoxCollider2D groundCheck;
    public LayerMask groundMask;
    public float groundSpeed;
    public float jumpSpeed;
    [Range(0f, 1f)] public float groundDecay;
    [Range(0f, 1f)] public float gravityDecay;
    //public float drag;
    private bool grounded;

    float xInput;
    float yInput;

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MoveWithInput();
    }

    private void FixedUpdate()
    {
        CheckGround();
        ApplyFriction();
    }

    void GetInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Jump");
    }

    void MoveWithInput()
    {
        if (Mathf.Abs(xInput) > 0)
        {
            body.velocity = new Vector2(xInput * groundSpeed, body.velocity.y);
        }

        if (Mathf.Abs(yInput) > 0 && grounded)
        {
            body.velocity = new Vector2(body.velocity.x, yInput * jumpSpeed);
        }
    }

    void CheckGround()
    {
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
    }

    void ApplyFriction()
    {
        if (xInput == 0 && yInput == 0)
        {
            //body.velocity *= groundDecay;
            body.velocity = new Vector2(body.velocity.x * groundDecay, body.velocity.y);
            body.velocity = new Vector2(body.velocity.x, body.velocity.y * gravityDecay);
        }
    }
}