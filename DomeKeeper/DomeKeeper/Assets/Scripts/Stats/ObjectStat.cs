using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStat : MonoBehaviour, IStatable
{
    public CharacterStat charStat;

    private float currentStat;

    private void ResetStat()
    {
        currentStat = charStat.GetValue();
    }

    public float GetCurrentValue()
    {
        return currentStat;
    }

    public void ChangeCurrentValue(float amount)
    {
        currentStat += amount;

        if (currentStat > charStat.GetMaxValue())
        {
            currentStat = charStat.GetMaxValue();
        }

        if (currentStat < 0)
        {
            currentStat = 0;
        }
    }

    private void OnEnable()
    {
        ResetStat();
    }
}
