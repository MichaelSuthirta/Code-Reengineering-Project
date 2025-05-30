using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    //Player
    [SerializeField] private Transform player;

    //Camera offset (difference between cam and player position)
    private Vector3 camOffset;

    //Camera velocity
    private Vector3 velocity = Vector3.zero;

    //Time to reach player
    private float camMoveTime = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        camOffset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.position + camOffset;
        transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref velocity, camMoveTime);
    }
}
