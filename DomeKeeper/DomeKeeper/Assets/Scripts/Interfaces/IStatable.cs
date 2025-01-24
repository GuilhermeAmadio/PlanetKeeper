using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatable
{
    public float GetCurrentStat();
    public void ChangeStat(float amount);
    public void IncreaseStat(float amount);
    public void DecreaseStat(float amount);
    public void SetMaxStat(float amount);
}
