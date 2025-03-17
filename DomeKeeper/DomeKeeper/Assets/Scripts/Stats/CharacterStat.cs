using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public StatSO stat;

    private IStatable statI;

    private void Awake()
    {
        statI = GetComponent<IStatable>();

        stat.InitializeStat();
    }

    public void ChangeStat(float amount)
    {
        stat.ChangeValue(amount);
    }

    public void ChangeCurrentValue(float amount)
    {
        statI.ChangeCurrentValue(amount);
    }

    public void SetMaxStat(float amount)
    {
        stat.SetMaxValue(amount);
    }

    public float GetValue()
    {
        return stat.GetValue();
    }

    public float GetCurrentValue()
    {
        return statI.GetCurrentValue();
    }

    public float GetMaxValue()
    {
        return stat.GetMaxValue();
    }

    public StatSO GetStat()
    {
        return stat;
    }
}
