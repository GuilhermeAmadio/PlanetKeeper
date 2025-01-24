using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallDelegateOnStart : MonoBehaviour
{
    [SerializeField] private DelegateFuncionSO delegateToCall;

    private void Start()
    {
        delegateToCall?.onFuncionCalled.Invoke();
    }
}
