using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stat", menuName = "Stats/New Stat")]
public class StatSO : ScriptableObject
{
    public float baseValue, currentValue, maxValue;

    public bool hasMaxValue, maxValueEqualToValue, initialZero;

    public DelegateFuncionSO onCurrentValueChanged;

    public void InitializeStat()
    {
        if (hasMaxValue && maxValueEqualToValue)
        {
            maxValue = baseValue;
        }

        if (initialZero)
        {
            currentValue = 0f;
        }
        else
        {
            currentValue = baseValue;
        }
    }

    public float GetValue()
    {
        return baseValue;
    }

    public float GetCurrentValue()
    {
        return currentValue;
    }

    public float GetMaxValue()
    {
        return maxValue;
    }

    public void ChangeValue(float amount)
    {
        baseValue += amount;

        onCurrentValueChanged?.onFuncionCalled.Invoke();
    }

    public void ChangeCurrentValue(float amount)
    {
        currentValue += amount;

        if (hasMaxValue)
        {
            if (currentValue > maxValue)
            {
                currentValue = maxValue;
            }
        }

        if (currentValue < 0f)
        {
            currentValue = 0f;
        }

        onCurrentValueChanged?.onFuncionCalled.Invoke();
    }

    public void SetMaxValue(float amount)
    {
        hasMaxValue = true;

        maxValue = amount;
    }
}
