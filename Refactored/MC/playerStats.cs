using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    playerHealth HP = new playerHealth();
    playerShield Shield = new playerShield();
    playerEnergy Energy = new playerEnergy();

    public void TakeDamage(float damage)
    {
        Shield.takeDamageShield();
        HP.takeDamageHP(damage);
    }

    public void consumeEnergy(float energy)
    {
        Energy.consumePlayerEnergy(energy);
    }

    public IEnumerator regenEnergy()
    {
        Energy.regenPlayerEnergy();
    }

    void Start()
    {
        HP.StartHP();
        Energy.StartEnergy();
    }

    void Update()
    {
        Shield.UpdateShield();
        HP.UpdateHP();
        Energy.UpdateEnergy();
    }
}
