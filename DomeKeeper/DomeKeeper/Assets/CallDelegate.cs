using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallDelegate : MonoBehaviour
{
    [SerializeField] private DelegateFuncionSO delegateToCall;

    public void Call()
    {
        delegateToCall.onFuncionCalled.Invoke();
    }
}
