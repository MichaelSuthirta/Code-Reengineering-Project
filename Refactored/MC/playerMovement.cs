using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private playerSpriteController spriteController;
    [SerializeField] private float speed;
    private float movementInput;

    [SerializeField] private groundChecker groundChecker;
    [SerializeField] private playerJumpControl jumpControl;

    [SerializeField] private playerFightControl fightControl;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        spriteController.setSprite(body);
    }

    private void runAnimate()
    {    
        if (!fightControl.skillPerformed)
        {
            movementInput = Input.GetAxisRaw("Horizontal");
            spriteController.animateRun(movementInput);
        }
    }

    private void runMove() {
        if (!fightControl.skillPerformed)
        {
            body.velocity = new Vector2(movementInput * speed, body.velocity.y);
        }  
    }

    private void jumpMove(isGrounded)
    {
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            jumpControl.jump();
        }
    }

    private void clampPosition() {
        Vector3 clampedPosition = transform.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -20.82f, 20.82f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -11.662f, 11.662f);
        transform.position = clampedPosition;
        
    }

    private void Update()
    {
        runAnimate();

        isGrounded = groundChecker.isOnGround();
        spriteController.animateWhenFalling(isGrounded);

        jumpMove(isGrounded);
    }

    private void FixedUpdate()
    {
        runMove();
        clampPosition();
    }
}