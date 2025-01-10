using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CallFunctionOnDelegate : MonoBehaviour
{
    [SerializeField] private DelegateFuncionSO functionCalled;

    [SerializeField] private UnityEvent eventToCall;

    private void CallFunction()
    {
        eventToCall?.Invoke();
    }

    private void OnEnable()
    {
        functionCalled.onFuncionCalled += CallFunction;
    }

    private void OnDisable()
    {
        functionCalled.onFuncionCalled -= CallFunction;
    }
}
