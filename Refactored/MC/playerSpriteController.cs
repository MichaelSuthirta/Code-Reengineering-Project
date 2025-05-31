using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class playerSpriteController : MonoBehaviour
{

    //Take rigid body 2d component from player object
    //Serialize field: The variable is still private, but accessible through editor
    private Rigidbody2D body;
    [SerializeField] private Animator animator = null;

    //Movement
    private bool isfacingRight = true;
    private float movementInput;

    public void setSprite(RigidBody2D spriteBody)
    {
        body = spriteBody;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void animateRun(float movementInput)
    {
        if (movementInput == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
            correctSpriteDirection();
        }
    }

    public void animateWhenFalling(bool isGrounded)
    {
        if (isGrounded)
        {
            animator.SetBool("isFalling", false);
        }
        else if (body.velocity.y < 0)
        {
            animator.SetBool("isFalling", true);
        }
    }

    public void animateJump()
    {
        animator.SetTrigger("jumpStart");
    }

    private void faceRightFlip()
    {
        isfacingRight = !isfacingRight;
    }

    private void correctSpriteDirection()
    {
        if ((movementInput < 0 && isfacingRight) || (movementInput > 0 && !isfacingRight))
        {
            faceRightFlip();

            //Scale x to -1 (Face left)
            transform.localScale = new Vector3((-1 * transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
}
