using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStat))]
public class EntityStat : MonoBehaviour, IStatable
{
    public CharacterStat charStat;

    private FloatStatsSO floatStats;

    private void Awake()
    {
        floatStats = charStat.GetFloatStat();

        ResetStat();
    }

    private void ResetStat()
    {
        floatStats.CurrentValueEqualToInitial();
    }

    public float GetCurrentStat()
    {
        return floatStats.GetCurrentValue();
    }

    public void ChangeStat(float amount)
    {
        floatStats.ChangeCurrentValue(amount);
    }

    public void IncreaseStat(float amount)
    {
        floatStats.IncreaseCurrentValue(amount);

        //if (GetCurrentStat() > charStat.GetMaxStat())
        //{
        //    floatStats.CurrentValueEqualToMax();
        //}
    }

    public void DecreaseStat(float amount)
    {
        floatStats.DecreaseCurrentValue(amount);

        if (GetCurrentStat() < 0f)
        {
            floatStats.ChangeCurrentValue(0f);
        }
    }

    public void SetMaxStat(float newMaxStat)
    {
        floatStats.SetMaxValue(newMaxStat);
    }
}
