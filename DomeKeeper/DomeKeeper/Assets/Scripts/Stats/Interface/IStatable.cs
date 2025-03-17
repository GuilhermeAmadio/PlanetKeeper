using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatable
{
    public float GetCurrentValue();
    public void ChangeCurrentValue(float amount);
}
