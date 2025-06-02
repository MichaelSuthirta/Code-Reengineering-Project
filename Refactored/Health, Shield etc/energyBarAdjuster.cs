using UnityEngine;
using UnityEngine.UI;

public class EnergyBarAdjuster : MonoBehaviour
{
    [SerializeField] private Slider energyBar;
    public void SetEnergy(EnergyValue currentEnergy)
    {
        if (energyBar != null)
        {
            energyBar.value = currentEnergy.Value;
        }
    }
    public void SetMaxEnergy(EnergyValue maxEnergy)
    {
        if (energyBar != null)
        {
            energyBar.maxValue = maxEnergy.Value;
            energyBar.value = maxEnergy.Value;
        }
    }
}
public struct EnergyValue
{
    public float Value { get; }

    public EnergyValue(float value)
    {
        Value = Mathf.Max(0f, value);
    }
}
