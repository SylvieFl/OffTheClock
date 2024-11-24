using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

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
    public bool canDoubleJump = false;
    public bool canDash;
    public bool inControl = true;

    private bool lookingRight = true;

    public Animator animator;
    
    public RawImage noDash;

    public GameOver gameOverScript;


    float xInput;
    float yInput;

    private bool isPerformingJump = false;

    public int health = 3;

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

        if (health < 1)
        {
            GameObject.Find("CoffeeUI").SetActive(false);
            GameObject.Find("DashFull").SetActive(false);
            noDash.enabled = false;
            gameOverScript.GameOverUI();
            //Debug.Log("GAME OVER");
        }

        if (GetComponent<SpriteRenderer>().color.g < 1.0f)
        {
            Color currentColor = GetComponent<SpriteRenderer>().color;
            currentColor.g += 0.01f;
            currentColor.b += 0.01f;
            GetComponent<SpriteRenderer>().color = currentColor;
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

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
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
        if (GetComponent<SpriteRenderer>().flipX)
        {
            body.AddForce(new Vector2(-1, 0) * dashForce, ForceMode2D.Impulse);
        }
        else
        {
            body.AddForce(new Vector2(1, 0) * dashForce, ForceMode2D.Impulse);
        }
        
        inControl = false;
        canDash = false;
        noDash.enabled = true;
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

                StartCoroutine(CoPerformJump());
                //body.velocity = new Vector2(body.velocity.x, yInput * jumpSpeed);
                //animator.SetBool("isJumping", true);
                //StartCoroutine(JumpEnd());
            }
            else if (canDoubleJump)
            {
                //StopCoroutine(JumpEnd());

                //StopAllCoroutines();
                Color color = GameObject.Find("CoffeeUI").GetComponent<RawImage>().color;
                color.r /= 2;
                color.g /= 2;
                color.b /= 2;
                GameObject.Find("CoffeeUI").GetComponent<RawImage>().color = color;
                animator.SetBool("isJumping", false);
                StartCoroutine(CoPerformDoubleJump());
                //StartCoroutine(DoubleJump());

                //body.velocity = new Vector2(body.velocity.x, yInput * jumpSpeed);
                //canDoubleJump = false;
                
            }
            
        }
    }

    void CheckGround()
    {
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
        if(isPerformingJump)
        {
            return;
        }
        if (grounded)
        {
            //Debug.Log("grounded: ");
            //canDoubleJump = false;
            animator.SetBool("isJumping", false);
        }
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
        animator.SetBool("isDashing", false);
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
    
    IEnumerator CoPerformJump()
    {
        body.velocity = new Vector2(body.velocity.x, yInput * jumpSpeed);
        //canDoubleJump = true;
        animator.SetBool("isJumping", true);
        isPerformingJump = true;
        while(grounded)
        {
            yield return null;
        }
        isPerformingJump = false;
    }

    IEnumerator CoPerformDoubleJump()
    {
        body.velocity = new Vector2(body.velocity.x, yInput * jumpSpeed);
        canDoubleJump = false;
        yield return new WaitForSeconds(0.01f);
        animator.SetBool("isJumping", true);
        isPerformingJump = true;
        while (grounded)
        {
            yield return null;
        }
        isPerformingJump = false;
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
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        //transform.Rotate(0, 180, 0);

    }

    public void Hurt()
    {
        //Debug.Log("Hurt");
        health -= 1;
        //float t = 0;
        //while (t < 1)
        //{
        GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.4f, 0.4f);
            //t += 0.05f;
        //}

    }
}