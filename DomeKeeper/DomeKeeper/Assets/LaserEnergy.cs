using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnergy : MonoBehaviour
{
    [SerializeField] private float energyValue;

    private bool attacking;

    private void Update()
    {
        if (attacking)
        {
            energyValue -= Time.deltaTime;
        }
        else 
        {
            energyValue += Time.deltaTime;
        }
    }

    public void Attacking(bool check)
    {
        attacking = check;
    }
}
