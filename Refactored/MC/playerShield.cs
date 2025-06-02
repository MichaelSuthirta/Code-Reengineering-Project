using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public playerShield : MonoBehaviour{
    private int playerShield;
    private int playerMaxShield;
    private shieldBarAdjuster shieldBar;
    
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