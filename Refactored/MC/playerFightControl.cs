using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFightControl : MonoBehaviour
{
    //Variables regarding Player game object
    [SerializeField] private Rigidbody2D body;
    private Animator animator = null;
    public playerStats player;

    //Basic attack
    private bool basicAtkInput;
    public float basicAtkCooldown;
    private float basicAtkTimer = 0f;

    //Skill
    private bool skillInput;
    public float skillCooldown;
    private float skillTimer = 0f;
    [SerializeField] private float skillDashSpeed;
    public bool skillPerformed = false;
    public float skillCost;

    //Basic attack cast
    private void basicAttackCast()
    {
        animator.SetTrigger("basicAtk");
    }

    private IEnumerator skill()
    {
        //Sets the bool to true so movement script won't interrupt the skill movement
        skillPerformed = true;
        animator.SetTrigger("Skill");

        //Sets timer to the cooldown, then reduces it through update.
        skillTimer = skillCooldown;

        //Wait until the upperstrike finishes
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("Skill_Slash_Done");

        //Saves the current gravity, then turns gravity to 0 so that the dash won't be interrupted by falling
        float currentGravity = body.gravityScale;
        body.gravityScale = 0;

        //Dashes
        body.velocity = new Vector2((transform.localScale.x) * skillDashSpeed, 0f);

        //Gives a bit of delay
        yield return new WaitForSeconds(0.2f);

        body.gravityScale = currentGravity;
        skillPerformed = false;
    }

    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Basic attack input
        basicAtkInput = Input.GetMouseButton(0);

        //Basic Attack
        if (basicAtkInput == true && basicAtkTimer == 0f)
        {
            basicAttackCast();
            basicAtkTimer = basicAtkCooldown;
        }
        else if (basicAtkTimer > 0f)
        {
            basicAtkTimer -= Time.deltaTime;
            if (basicAtkTimer < 0f)
            {
                basicAtkTimer = 0f;
            }
        }

        //Skill input
        skillInput = Input.GetKeyDown(KeyCode.E);

        if(skillInput == true && skillTimer == 0f && player.playerEnergy >= skillCost)
        {
            player.consumeEnergy(skillCost);
            StartCoroutine(skill());
        }
        else if(skillTimer > 0f)
        {
            skillTimer -= Time.deltaTime;
            if (skillTimer < 0f)
            {
                skillTimer = 0f;
            }
        }
    }
}
