using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public FloatStatsSO floatStat;

    private IStatable stat;

    private void Awake()
    {
        stat = GetComponent<IStatable>();
        floatStat.UpdateMaxValue();
    }

    public void ChangeStat(float amount)
    {
        stat.ChangeStat(amount);
    }

    public void IncreaseStat(float amount)
    {
        stat.IncreaseStat(amount);
    }

    public void DecreaseStat(float amount)
    {
        stat.DecreaseStat(amount);
    }

    public float GetBaseStat()
    {
        return floatStat.GetBaseValue();
    }

    public float GetMaxStat()
    {
        return floatStat.GetMaxValue();
    }

    public float GetCurrentStat()
    {
        return stat.GetCurrentStat();
    }

    public FloatStatsSO GetFloatStat()
    {
        return floatStat;
    }
}
