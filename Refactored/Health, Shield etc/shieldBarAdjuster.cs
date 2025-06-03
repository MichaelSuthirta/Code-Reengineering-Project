using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shieldBarAdjuster : MonoBehaviour
{
    public playerStats playerStats;
    public Sprite shieldNone;
    public Sprite shieldFill;
    public Image[] shieldBar;

    public void fillBar(int currentShield)
    {
        for (int i = 0; i < shieldBar.Length; i++)
        {
            if (i < currentShield)
            {
                shieldBar[i].sprite = shieldFill;
            }
            else
            {
                shieldBar[i].sprite = shieldNone;
            }
        }
    }
    void Update()
    {
        for(int i = 0; i < shieldBar.Length; i++)
        {
            if(i < playerStats.playerMaxShield)
            {
                shieldBar[i].enabled = true;
            }
            else
            {
                shieldBar[i].enabled = false;
            }
        }
    }
}
