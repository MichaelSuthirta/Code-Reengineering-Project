using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class playerSpriteController : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private Animator animator = null;
    private bool isfacingRight = true;
    private float movementInput;

    public static void setSprite(RigidBody2D spriteBody)
    {
        body = spriteBody;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public static void animateRun(float movementInput)
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

    public static void animateWhenFalling(bool isGrounded)
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

    public static void animateJump()
    {
        animator.SetTrigger("jumpStart");
    }

    private static void faceRightFlip()
    {
        isfacingRight = !isfacingRight;
    }

    private static void correctSpriteDirection()
    {
        if ((movementInput < 0 && isfacingRight) || (movementInput > 0 && !isfacingRight))
        {
            faceRightFlip();
            transform.localScale = new Vector3((-1 * transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
}
