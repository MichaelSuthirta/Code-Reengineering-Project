using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BoundaryControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private playerSpriteController spriteController;
    [SerializeField] private groundChecker groundChecker;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        spriteController.setSprite(body);
    }

    private void clampPosition() {
        Vector3 clampedPosition = transform.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -20.82f, 20.82f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -11.662f, 11.662f);
        transform.position = clampedPosition;
        
    }

    private void Update()
    {
        isGrounded = groundChecker.isOnGround();
        spriteController.animateWhenFalling(isGrounded);
    }

    private void FixedUpdate()
    {
        clampPosition();
    }
}