using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStat))]
public class EntityStat : MonoBehaviour, IStatable
{
    public CharacterStat charStat;

    private StatSO stat;

    private void Awake()
    {
        stat = charStat.GetStat();
    }

    public float GetCurrentValue()
    {
        return stat.GetCurrentValue();
    }

    public void ChangeCurrentValue(float amount)
    {
        stat.ChangeCurrentValue(amount);
    }
}
