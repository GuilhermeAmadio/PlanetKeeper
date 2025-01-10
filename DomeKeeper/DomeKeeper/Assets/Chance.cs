using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chance : MonoBehaviour
{
    [SerializeField] private FloatStatsSO chance;

    public bool CheckChance()
    {
        float randomNum = Random.Range(0f, 100f);

        if (randomNum <= chance.GetCurrentValue()) {
            return true;
        }
        
        return false;
    }
}
