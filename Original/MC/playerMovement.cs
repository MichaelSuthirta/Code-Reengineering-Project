using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    //Take rigid body 2d component from player object
    //Serialize field: The variable is still private, but accessible through editor
    [SerializeField] private Rigidbody2D body;
    private Animator animator = null;

    //Movement
    public float speed;
    private bool isfacingRight = true;
    private float movementInput;

    //Jumping
    public float jumpForce;
    private float jumpTimerCounter;
    [SerializeField]private float jumpHoldTimer;
    private bool canExtendJump;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    private bool isGrounded;
    public LayerMask ground;

    public playerFightControl fightControl;

    // Awake function for when object is initialized
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void faceRightFlip()
    {
        isfacingRight = !isfacingRight;
    }

    private void flip()
    {
        if ((movementInput < 0 && isfacingRight) || (movementInput > 0 && !isfacingRight))
        {
            faceRightFlip();

            //Scale x to -1 (Face left)
            transform.localScale = new Vector3((-1 * transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }


    // Update is called once per frame
    private void Update()
    {
        if (!fightControl.skillPerformed)
        {
            //Running
            movementInput = Input.GetAxisRaw("Horizontal");

            //Adjust animation
            if (movementInput == 0)
            {
                animator.SetBool("isRunning", false);
            }
            else
            {
                animator.SetBool("isRunning", true);
                flip();
            }            
        }

        //Jumping
        //Check if player touches ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);

        //Check grounded status
        Debug.Log("Grounded: " + isGrounded);

        if (isGrounded)
        {
            animator.SetBool("isFalling", false);
        }
        else if (body.velocity.y < 0)
        {
            animator.SetBool("isFalling", true);
        }

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("jumpStart");
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            canExtendJump = true;
            jumpTimerCounter = jumpHoldTimer;
        }

        if (Input.GetKey(KeyCode.Space) && canExtendJump == true)
        {
            if (jumpTimerCounter > 0)
            {
                body.velocity = new Vector2(body.velocity.x, jumpForce);
                jumpTimerCounter -= Time.deltaTime;
            }

            else
            {
                canExtendJump = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            canExtendJump = false;
        }
    }
    
    // Change velocity using vector
    private void FixedUpdate()
    {
        if (!fightControl.skillPerformed)
        {
            //Running
            body.velocity = new Vector2(movementInput * speed, body.velocity.y);
        }

        //Keeping player in map
        Vector3 clampedPosition = transform.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -20.82f, 20.82f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -11.662f, 11.662f);
        transform.position = clampedPosition;
    }
}
