using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarAdjuster : MonoBehaviour
{
    //Storing health bar slider
    public Slider healthBarSlider;

    //Setting max HP
    public void setMaxHP(float hp)
    {
        healthBarSlider.maxValue = hp;
        healthBarSlider.value = hp;
    }

    // Changing HP
    public void setHP(float hp)
    {
        healthBarSlider.value = hp;
    }
}
