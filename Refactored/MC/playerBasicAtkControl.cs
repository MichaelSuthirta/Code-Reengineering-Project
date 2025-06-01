using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBasicAtkControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    private FightAnimationControl animationControl;
    [SerializeField] private playerStats player;

    private bool basicAtkInput;
    [SerializeField] private float basicAtkCooldown;
    private float basicAtkCDTimer = 0f;

    private void cooldown()
    {
        basicAtkCDTimer -= Time.deltaTime;
        if (basicAtkCDTimer < 0f)
        {
            basicAtkTimer = 0f;
        }
    }

    private void attack()
    {
        basicAtkCDTimer = basicAtkCooldown;
        animationControl.animateBasicAtk();
    }

    private void processInput(bool basicAtkInput)
    {
        if (basicAtkInput == true && basicAtkCDTimer == 0f)
        {
            attack();
        }
        else if (basicAtkCDTimer > 0f)
        {
            cooldown();
        }
    }

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animationControl.setSprite(body);
    }

    void Update()
    {
        basicAtkInput = Input.GetMouseButton(0);
        processInput(basicAtkInput);
    }
}
