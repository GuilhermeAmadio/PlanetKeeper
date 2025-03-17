using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenerableStat : MonoBehaviour
{
    [SerializeField] private CharacterStat charStat;

    [SerializeField] private StatSO regenAmount;

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
        if (charStat.GetCurrentValue() < charStat.GetMaxValue())
        {
            charStat.ChangeCurrentValue(regenAmount.GetValue());
        }
    }

    private void DegenStat()
    {
        if (charStat.GetCurrentValue() > 0f)
        {
            charStat.ChangeCurrentValue(-regenAmount.GetValue());
        }
    }
}
