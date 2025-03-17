using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseStat : MonoBehaviour
{
    [SerializeField] private CharacterStat stat;

    public void Increase(float amount)
    {
        stat.ChangeStat(amount);
    }
}
