using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightAnimationControl : MonoBehaviour
{
    private Animator animator = null;
    private Rigidbody2D body;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void setSprite(Rigidbody2D spriteBody)
    {
        body = spriteBody;
    }

    public void animateBasicAtk()
    {
        animator.SetTrigger("basicAtk");
    }

    public void animateSkillFirstAttack()
    {
        animator.SetTrigger("Skill");
    }

    public void animateSkillSecondAttack()
    {
        animator.SetTrigger("Skill_Slash_Done");
    }
}
