using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStat : MonoBehaviour, IStatable
{
    public CharacterStat charStat;

    private float currentStat;

    private void ResetStat()
    {
        currentStat = charStat.GetBaseStat();
    }

    public void ChangeStat(float amount)
    {
        currentStat = amount;
    }

    public float GetCurrentStat()
    {
        return currentStat;
    }

    public void IncreaseStat(float amount)
    {
        currentStat += amount;
    }

    public void DecreaseStat(float amount)
    {
        currentStat -= amount;
    }

    private void OnEnable()
    {
        ResetStat();
    }
}
