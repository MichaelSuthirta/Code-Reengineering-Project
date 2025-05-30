using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shieldBarAdjuster : MonoBehaviour
{
    //Script of player stats
    public playerStats playerStats;

    //Sprites
    public Sprite shieldNone;
    public Sprite shieldFill;

    //Array to store the objects
    public Image[] shieldBar;

    public void fillBar(int currentShield)
    {
        //Filling the bar according to current shield amount
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

    // Update is called once per frame
    void Update()
    {
        //Making sure it doesn't display shield more than max
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
