using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class playerJumpControl : MonoBehaviour
{
    private Rigidbody2D body;
    private playerSpriteController spriteController;
    private float jumpForce;
    private float jumpHoldTimer;
    private float jumpTimerCounter;
    private bool canExtendJump;

    private void initialize(Rigidbody2D spriteBody, float force, float jumpTimer) {
        body = spriteBody;
        spriteController.setSprite(body);
        this.jumpForce = force;
        this.jumpHoldTimer = jumpTimer;
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

    public void jumpInputProcess()
    {
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            canExtendJump = true;
            spriteController.animateJump()
            jumpTimerCounter = jumpHoldTimer;

            body.velocity = new Vector2(body.velocity.x, jumpForce);

            jumpAndExtend();
        }
    }
}
