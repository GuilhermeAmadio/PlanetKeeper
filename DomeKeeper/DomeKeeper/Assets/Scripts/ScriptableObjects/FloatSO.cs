using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Float", menuName = "Stats/New Float")]
public class FloatSO : ScriptableObject
{
    [SerializeField] private float value;

    public DelegateFuncionSO onValueChanged;

    public void ChangeValue(float newValue)
    {
        value = newValue;

        ValueChanged();
    }

    public void IncreaseValue(float amount)
    {
        value += amount;

        ValueChanged();
    }

    public void DecreaseValue(float amount)
    {
        value -= amount;

        ValueChanged(); 
    }

    public float GetValue()
    {
        return value;
    }

    public void ValueChanged()
    {
        if (onValueChanged != null)
        {
            onValueChanged.onFuncionCalled.Invoke();
        }
    }

    private void OnEnable()
    {
        if (onValueChanged != null)
            onValueChanged.onFuncionCalled += DebugValue;
    }

    private void OnDisable()
    {
        if (onValueChanged != null)
            onValueChanged.onFuncionCalled -= DebugValue;
    }

    private void DebugValue()
    {
        //teste
    }
}
