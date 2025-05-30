using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    //HP variables
    public float playerHP;
    public float playerMaxHP;
    public bool playerHealthNull;

    //Health bar script
    public healthBarAdjuster healthBar;

    //Shield variables
    public int playerShield;
    public int playerMaxShield;

    //Shield bar script
    public shieldBarAdjuster shieldBar;

    //Energy script
    public float playerEnergy;
    public float playerMaxEnergy;
    public float playerEnergyRegen;
    private bool energyRegenerating = false;

    //Energy bar script
    public energyBarAdjuster energyBar;

    //Taking damage
    public void takeDamage(float damage)
    {
        if(playerShield > 0)
        {
            playerShield--;
        }
        else
        {
            playerHP -= damage;
        }

        if(playerHP <= 0)
        {
            Destroy(gameObject);
            healthBar.setHP(0);
            playerHealthNull = true;
        }
    }

    public void consumeEnergy(float energy)
    {
        if(playerEnergy > 0)
        {
            playerEnergy -= energy;
            energyBar.setEnergy(playerEnergy);
        }
    }

    public IEnumerator regenEnergy()
    {
        while(playerEnergy < playerMaxEnergy && energyRegenerating == true)
        {
            yield return new WaitForSeconds(1);
            playerEnergy += playerEnergyRegen;
            energyBar.setEnergy(playerEnergy);
        }
        energyRegenerating = false;
    }

    // Start is called before the first frame update
    void Start()
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
        playerEnergy = playerMaxEnergy;
        energyBar.setMaxEnergy(playerMaxEnergy);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHP != playerMaxHP)
        {
            healthBar.setHP(playerHP);
        }

        if(playerShield != playerMaxShield)
        {
            shieldBar.fillBar(playerShield);
        }

        if(playerEnergy > playerMaxEnergy)
        {
            playerEnergy = playerMaxEnergy;
        }
        if(playerHP > playerMaxHP)
        {
            playerHP = playerMaxHP;
        }

        if(playerEnergy != playerMaxEnergy && energyRegenerating == false)
        {
            energyRegenerating = true;
            StartCoroutine(regenEnergy());
        }
    }
}
