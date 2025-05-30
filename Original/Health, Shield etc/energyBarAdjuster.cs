using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyBarAdjuster : MonoBehaviour
{
    public Slider energyBar;

    public void setEnergy(float energy)
    {
        energyBar.value = energy;
    }

    public void setMaxEnergy(float energy)
    {
        energyBar.maxValue = energy;
        energyBar.value = energy;
    }
}
