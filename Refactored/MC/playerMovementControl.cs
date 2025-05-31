using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class playerMovementControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    private playerSpriteController spriteController;

    [SerializeField] private playerJumpControl jumpControl;
    [SerializeField] private playerRunControl runControl;

    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpHoldTimer;

    [SerializeField] private float speed;

    [SerializeField] private playerFightControl fightControl;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        spriteController.setSprite(body);
        jumpControl.initialize(body, jumpForce, jumpHoldTimer);
        runControl.initialize(body, speed)
    }

    private void Update()
    {
        if (!fightControl.skillPerformed)
        {
            runControl.playerRunProcess();
        }
        jumpControl.jump()
    }

    private void FixedUpdate()
    {
        if (!fightControl.skillPerformed)
        {
            runControl.applyVelocityVector();
        }
    }
}