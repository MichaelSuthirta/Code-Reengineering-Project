using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarAdjuster : MonoBehaviour
{
    public Slider healthBarSlider;
    public void setMaxHP(float hp)
    {
        healthBarSlider.maxValue = hp;
        healthBarSlider.value = hp;
    }

    public void setHP(float hp)
    {
        healthBarSlider.value = hp;
    }
}
