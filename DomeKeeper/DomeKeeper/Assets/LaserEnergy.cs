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
            if (energyValue.GetCurrentValue() > 0f)
            {
                energyValue.ChangeCurrentValue(-Time.deltaTime * 2);
            }
        }
        else 
        {
            if (energyValue.GetCurrentValue() <= energyValue.GetMaxValue())
            {
                energyValue.ChangeCurrentValue(energyRegen.GetCurrentValue() * Time.deltaTime);
            }
        }
    }

    public void Attacking(bool check)
    {
        attacking = check;
    }
}
