using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class playerRunControl : MonoBehaviour
{
    private Rigidbody2D body;
    private playerSpriteController spriteController;
    private float speed;
    private float movementInput;
    
    private void initialize(Rigidbody2D spriteBody, float runSpeed) {
        body = spriteBody;
        spriteController.setSprite(body);
        this.speed = runSpeed;
    }

    public void playerRunProcess()
    {
        movementInput = Input.GetAxisRaw("Horizontal");
        spriteController.animateRun(movementInput);
    }

    public void applyVelocityVector() {
        body.velocity = new Vector2(movementInput * speed, body.velocity.y);
    }
}