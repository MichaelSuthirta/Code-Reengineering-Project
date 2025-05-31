using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //Take rigid body 2d component from player object
    //Serialize field: The variable is still private, but accessible through editor
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private playerSpriteController spriteController;

    //Movement
    public float speed;
    private float movementInput;

    [SerializeField] private groundChecker groundChecker;
    [SerializeField] private playerJumpControl jumpControl;

    public playerFightControl fightControl;

    // Awake function for when object is initialized
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        spriteController.setSprite(body);
    }

    private void runAnimate()
    {    
        if (!fightControl.skillPerformed)
        {
            //Running
            movementInput = Input.GetAxisRaw("Horizontal");

            spriteController.animateRun(movementInput);
        }
    }

    private void runMove() {
        if (!fightControl.skillPerformed)
        {
            //Running
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
        //Keeping player in map
        Vector3 clampedPosition = transform.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -20.82f, 20.82f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -11.662f, 11.662f);
        transform.position = clampedPosition;
        
    }

    // Update is called once per frame
    private void Update()
    {
        runAnimate();

        //Jumping
        isGrounded = groundChecker.isOnGround();
        spriteController.animateWhenFalling(isGrounded);

        jumpMove(isGrounded);
    }
    
    // Change velocity using vector
    private void FixedUpdate()
    {
        runMove();
        clampPosition();
    }
}