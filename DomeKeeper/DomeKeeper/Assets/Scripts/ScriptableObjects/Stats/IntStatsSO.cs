using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Stat/Int")]
public class IntStatsSO : ScriptableObject
{
    public StatsEnum statsName;

    public int baseValue, currentValue, upgradedValue, maxValue;

    public StatsEnum GetStatsName() { return statsName; }

    public int GetBaseValue()
    {
        return baseValue;
    }

    public int GetCurrentValue()
    {
        return currentValue;
    }

    public int GetUpgradedValue()
    {
        return upgradedValue;
    }

    public int GetMaxValue()
    {
        return maxValue;
    }

    public void ChangeCurrentValue(int amount)
    {
        currentValue = amount;
    }

    public void IncreaseCurrentValue(int amount)
    {
        currentValue += amount;
    }

    public void DecreaseCurrentValue(int amount)
    {
        currentValue -= amount;
    }

    public void CurrentValueEqualToBase()
    {
        currentValue = baseValue;
    }

    public void CurrentValueEqualToMax()
    {
        currentValue = maxValue;
    }

    public void IncreaseUpgradedValue(int amount)
    {
        upgradedValue += amount;
    }

    public void UpdateMaxValue()
    {
        maxValue = baseValue + upgradedValue;
    }
}
