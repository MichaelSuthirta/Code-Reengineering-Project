using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    private float playerHP;
    private float playerMaxHP;
    private bool playerHealthNull;
    private healthBarAdjuster healthBar;

    void takeDamageHP(float damage)
    {
        playerHP -= damage;

        if (playerHP <= 0)
        {
            playerHP = 0;
            healthBar.setHP(playerHP);
            Destroy(gameObject);
        }
        else
        {
            healthBar.setHP(playerHP);
        }
    }

    void StartHP()
    {
        if (playerHealthNull)
        {
            playerHP = playerMaxHP;
            healthBar.setMaxHP(playerHP);
            playerHealthNull = false;
        }
        else
        {
            healthBar.setHP(playerHP);
        }
    }

    void UpdateHP()
    {
        if (playerHP != playerMaxHP)
        {
            healthBar.setHP(playerHP);
        }
        
        if(playerHP > playerMaxHP)
        {
            playerHP = playerMaxHP;
        }
    }
    
}