using UnityEngine;
using UnityEngine.UI;

public class EnergyBarAdjuster : MonoBehaviour
{
    [SerializeField] private Slider energyBar;
    
    /// Sets the current energy value.
    /// <param name="currentEnergy">The current energy value (0 to max).</param>
    public void SetEnergy(EnergyValue currentEnergy)
    {
        if (energyBar != null)
        {
            energyBar.value = currentEnergy.Value;
        }
    }

    /// Sets the maximum energy and fills the bar.
    /// <param name="maxEnergy">The maximum energy value.</param>
    public void SetMaxEnergy(EnergyValue maxEnergy)
    {
        if (energyBar != null)
        {
            energyBar.maxValue = maxEnergy.Value;
            energyBar.value = maxEnergy.Value;
        }
    }
}


/// Encapsulates a float energy value to reduce primitive obsession.
public struct EnergyValue
{
    public float Value { get; }

    public EnergyValue(float value)
    {
        Value = Mathf.Max(0f, value); // Ensures non-negative energy
    }
}
