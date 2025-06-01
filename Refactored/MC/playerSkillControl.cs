using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSkillControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    private FightAnimationControl animationControl;
    [SerializeField] private playerStats player;
    private bool skillInput;
    [SerializeField] private float skillCooldown;
    private float skillTimer = 0f;
    [SerializeField] private float skillDashSpeed;
    private bool skillPerformed = false;
    [SerializeField] private float skillCost;

    private float bodyGravitySave() {
        float currentGravity = body.gravityScale;
        body.gravityScale = 0;
        return currentGravity;
    }

    private void returnToInitialState() {
        body.gravityScale = currentGravity;
        skillPerformed = false;
    }

    private IEnumerator skill()
    {
        skillPerformed = true;
        animationControl.animateSkillFirstAttack();
        skillTimer = skillCooldown;
        yield return new WaitForSeconds(0.5f);
        animationControl.animateSkillSecondAttack()
        float currentGravity = bodyGravitySave();
        body.velocity = new Vector2((transform.localScale.x) * skillDashSpeed, 0f);
        yield return new WaitForSeconds(0.2f);
        returnToInitialState();
    }

    private void cooldown() {
        skillTimer -= Time.deltaTime;
        if (skillTimer < 0f)
        {
            skillTimer = 0f;
        }
    }

    private bool skillReady() {
        if (skillTimer == 0f && player.playerEnergy >= skillCost)
        {
            return true;
        }
        return false;
    }

    private void processInput(bool skillInput) {
        if (skillInput == true && skillReady())
        {
            player.consumeEnergy(skillCost);
            StartCoroutine(skill());
        }
        else if (skillTimer > 0f)
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
        skillInput = Input.GetKeyDown(KeyCode.E);
        processInput(skillInput);
    }
}
