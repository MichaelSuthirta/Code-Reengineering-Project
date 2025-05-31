using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class playerJumpControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private playerSpriteController spriteController;

    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpHoldTimer;
    private float jumpTimerCounter;
    private bool canExtendJump;
    
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        spriteController.setSprite(body)
    }

    private void extendJump() {
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

    private void jumpAndExtend()
    {
        if (Input.GetKey(KeyCode.Space) && canExtendJump == true)
        {
            extendJump();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            canExtendJump = false;
        }
    }

    public void jump()
    {
        canExtendJump = true;
        spriteController.animateJump()
        jumpTimerCounter = jumpHoldTimer;
        
        body.velocity = new Vector2(body.velocity.x, jumpForce);

        jumpAndExtend();
    }
}
