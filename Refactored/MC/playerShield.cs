using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public playerShield : MonoBehaviour{
    public int playerShield;
    public int playerMaxShield;
    public shieldBarAdjuster shieldBar;
    
    public void takeDamageShield() {
        shieldDamage damageShield = new shieldDamage();
        damageShield.damageTaken();
    }

    void UpdateShield() {
        if(playerShield != playerMaxShield)
        {
            shieldBar.fillBar(playerShield);
        }
    }
}