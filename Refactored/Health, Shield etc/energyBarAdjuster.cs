using UnityEngine;
using UnityEngine.UI;

public struct EnergyValue
{
    public float Value { get; }

    public EnergyValue(float value)
    {
        Value = Mathf.Max(0f, value); 
    }
}

public class EnergyBarUI : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void SetEnergy(EnergyValue energy)
    {
        if (slider != null)
        {
            slider.value = energy.Value;
        }
    }

    public void SetMaxEnergy(EnergyValue energy)
    {
        if (slider != null)
        {
            slider.maxValue = energy.Value;
            slider.value = energy.Value;
        }
    }
}

public class EnergyBarAdjuster : MonoBehaviour
{
    [SerializeField] private EnergyBarUI energyBarUI;

    public void SetEnergy(EnergyValue energy)
    {
        energyBarUI.SetEnergy(energy);
    }

    public void SetMaxEnergy(EnergyValue energy)
    {
        energyBarUI.SetMaxEnergy(energy);
    }
}

