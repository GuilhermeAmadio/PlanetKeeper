using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenerableStat : MonoBehaviour
{
    [SerializeField] private CharacterStat charStat;

    [SerializeField] private FloatStatsSO regenAmount;

    [SerializeField] private bool degen;

    private void Start()
    {
        if (degen)
        {
            InvokeRepeating("DegenStat", 1, 1);
            return;
        }

        InvokeRepeating("RegenStat", 1, 1);
    }

    private void RegenStat()
    {
        if (charStat.GetCurrentStat() < charStat.GetMaxStat())
        {
            charStat.IncreaseStat(regenAmount.GetCurrentValue());
        }
    }

    private void DegenStat()
    {
        if (charStat.GetCurrentStat() > 0f)
        {
            charStat.DecreaseStat(regenAmount.GetCurrentValue());
        }
    }
}
