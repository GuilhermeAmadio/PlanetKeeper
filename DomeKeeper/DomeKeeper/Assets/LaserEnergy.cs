using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnergy : MonoBehaviour
{
    [SerializeField] private CharacterStat energyValue, energyRegen;

    private bool attacking;

    private void Update()
    {
        if (attacking)
        {
            if (energyValue.GetCurrentStat() > 0f)
            {
                energyValue.DecreaseStat(Time.deltaTime * 2);
            }
        }
        else 
        {
            if (energyValue.GetCurrentStat() <= energyValue.GetMaxStat())
            {
                energyValue.IncreaseStat(energyRegen.GetCurrentStat() * Time.deltaTime);
            }
        }
    }

    public void Attacking(bool check)
    {
        attacking = check;
    }
}
