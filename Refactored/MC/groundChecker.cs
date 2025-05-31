using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class groundChecker : MonoBehaviour
{
    [SerializeField] private Transform groundChecker;
    [SerializeField] private float checkerRadius;
    private bool isGrounded;
    [SerializeField] private LayerMask ground;

    public static bool isOnGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundChecker.position, checkerRadius, ground);
        Debug.Log("Grounded: " + isGrounded);
        return isGrounded;
    }
}
