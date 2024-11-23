using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public BoxCollider2D groundCheck;
    public TrailRenderer trailRenderer;
    public LayerMask groundMask;
    public float groundSpeed;


    public float jumpSpeed;
    [Range(0f, 100f)] public float dashForce;
    [Range(0f, 1f)] public float groundDecay;
    [Range(0f, 1f)] public float gravityDecay;
    [Range(0f, 1f)] public float dashWaitTime;

    public bool grounded;
    public bool canDoubleJump;
    public bool canDash;
    public bool inControl = true;

    private bool lookingRight = true;

    public Animator animator;


    float xInput;
    float yInput;

    // Update is called once per frame
    void Update()
    {
        
        if (inControl)
        {
            GetInput();
            MoveWithInput();
            FlipCharacter();
            animator.SetFloat("Speed", Mathf.Abs(xInput));
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

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && !grounded && (xInput != 0 || yInput != 0))
        {
            Dash(xInput);
        }
    }

    void Dash(float input)
    {
        StopAllCoroutines();
        xInput = 0;
        yInput = 0;
        body.gravityScale = 0;
        gravityDecay = 0;
        animator.SetBool("isDashing", true);
        body.AddForce(new Vector2(input, 0) * dashForce, ForceMode2D.Impulse);
        inControl = false;
        canDash = false;
        trailRenderer.emitting = true;
        Vector3 currentScale = transform.localScale;
        currentScale.x = 1.25f;
        currentScale.y = 0.75f;
        transform.localScale = currentScale;

        StartCoroutine(waiter());
    }

    void MoveWithInput()
    {
        if (Mathf.Abs(xInput) > 0)
        {
            body.velocity = new Vector2(xInput * groundSpeed, body.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                body.velocity = new Vector2(body.velocity.x, yInput * jumpSpeed);
                animator.SetBool("isJumping", true);
                StartCoroutine(JumpEnd());
            }
            else if (canDoubleJump)
            {
                StopCoroutine(JumpEnd());
                
                //StopAllCoroutines();
                animator.SetBool("isJumping", false);
                StartCoroutine(DoubleJump());
                
                body.velocity = new Vector2(body.velocity.x, yInput * jumpSpeed);
                canDoubleJump = false;
                
            }
            
        }
    }

    void CheckGround()
    {
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
        if (grounded) canDoubleJump = false;
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

        Vector3 currentScale = transform.localScale;
        currentScale.x = 1.0f;
        currentScale.y = 1.0f;
        transform.localScale = currentScale;

        body.gravityScale = 3;
        gravityDecay = 1;
        inControl = true;
        trailRenderer.emitting = false;
    }

    IEnumerator JumpEnd()
    {

        yield return new WaitForSeconds(1f);

        animator.SetBool("isJumping", false);

    }

    IEnumerator DoubleJump()
    {

        yield return new WaitForSeconds(0.01f);

        animator.SetBool("isJumping", true);

        yield return new WaitForSeconds(1f);

        animator.SetBool("isJumping", false);

    }

    private void FlipCharacter()
    {

        if (body.velocity.x < 0 && lookingRight)
        {
            Flip();
        }
        else if (body.velocity.x > 0 && !lookingRight)
        {
            Flip();
        }
    
    }

    private void Flip()
    { 
    
        lookingRight = !lookingRight;
        transform.Rotate(0, 180, 0);

    }
}