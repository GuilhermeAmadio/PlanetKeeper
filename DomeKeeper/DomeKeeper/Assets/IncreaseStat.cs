using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseStat : MonoBehaviour
{
    [SerializeField] private FloatStatsSO stat;

    public void Increase(float amount)
    {
        stat.IncreaseUpgradedValue(amount);
    }
}
