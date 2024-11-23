using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public BoxCollider2D groundCheck;
    public LayerMask groundMask;
    public float groundSpeed;
    public float jumpSpeed;
    [Range(0f, 100f)] public float dashForce;
    [Range(0f, 1f)] public float groundDecay;
    [Range(0f, 1f)] public float gravityDecay;
    [Range(0f, 1f)] public float dashWaitTime;

    private bool grounded;
    private bool canDoubleJump;
    private bool inControl = true;


    float xInput;
    float yInput;

    // Update is called once per frame
    void Update()
    {
        if (inControl)
        {
            GetInput();
            MoveWithInput();
        }
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

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDoubleJump && !grounded && (xInput != 0 || yInput != 0))
        {
            Dash(xInput);
        }
    }

    void Dash(float input)
    {
        xInput = 0;
        yInput = 0;
        body.gravityScale = 0;
        gravityDecay = 0;
        body.AddForce(new Vector2(input, 0) * dashForce, ForceMode2D.Impulse);
        canDoubleJump = false;
        inControl = false;

        StartCoroutine(waiter());
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
        if (grounded && !canDoubleJump) canDoubleJump = true;
    }

    void ApplyFriction()
    {
        if (xInput == 0 && yInput == 0)
        {
            body.velocity = new Vector2(body.velocity.x * groundDecay, body.velocity.y);
            body.velocity = new Vector2(body.velocity.x, body.velocity.y * gravityDecay);
        }
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(dashWaitTime);

        body.gravityScale = 3;
        gravityDecay = 1;
        inControl = true;
    }
}