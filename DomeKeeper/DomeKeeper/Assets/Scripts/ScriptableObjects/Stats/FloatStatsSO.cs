using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Stat/Float")]
public class FloatStatsSO : ScriptableObject
{
    //public StatsEnum statsName;

    public float initialValue, baseValue, currentValue, upgradedValue, maxValue;

    public bool hasInitialValue;
    public bool hasMaxValue;

    public DelegateFuncionSO onCurrentValueChanged, onMaxValueChanged;

    //public StatsEnum GetStatsName() { return statsName; }

    public float GetInitialValue()
    {
        if (hasInitialValue)
        {
            return initialValue;
        }
        else
        {
            return baseValue;
        }
    }

    public float GetBaseValue()
    {
        return baseValue;
    }

    public float GetCurrentValue()
    {
        return currentValue;
    }

    public float GetUpgradedValue()
    {
        return upgradedValue;
    }

    public float GetMaxValue()
    {
        return maxValue;
    }

    public void ChangeCurrentValue(float amount)
    {
        currentValue = amount;

        onCurrentValueChanged?.onFuncionCalled.Invoke();
    }

    public void IncreaseCurrentValue(float amount)
    {
        ChangeCurrentValue(currentValue + amount);

        if (hasMaxValue)
        {
            if (currentValue > maxValue)
            {
                CurrentValueEqualToMax();
            }
        }
    }

    public void DecreaseCurrentValue(float amount)
    {
        ChangeCurrentValue(currentValue - amount);
    }

    public void CurrentValueEqualToInitial()
    {
        ChangeCurrentValue(GetInitialValue());
    }

    public void CurrentValueEqualToBase()
    {
        ChangeCurrentValue(baseValue);
    }

    public void CurrentValueEqualToMax()
    {
        ChangeCurrentValue(maxValue);
    }

    public void IncreaseUpgradedValue(float amount)
    {
        upgradedValue += amount;
    }

    public void SetMaxValue(float newMaxStat)
    {
        maxValue = newMaxStat;

        onMaxValueChanged?.onFuncionCalled.Invoke();
    }

    public void UpdateMaxValue()
    {
        maxValue = baseValue + upgradedValue;

        onMaxValueChanged?.onFuncionCalled.Invoke();
    }
}
