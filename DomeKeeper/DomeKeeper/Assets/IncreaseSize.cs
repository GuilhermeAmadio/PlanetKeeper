using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSize : MonoBehaviour
{
    [SerializeField] private CharacterStat sizeStat;

    [SerializeField] private Transform transformToIncrease;

    private void Start()
    {
        transformToIncrease.localScale = new Vector3(transformToIncrease.localScale.x + sizeStat.GetValue(), transformToIncrease.localScale.y + sizeStat.GetValue(), 1f);
    }
}
