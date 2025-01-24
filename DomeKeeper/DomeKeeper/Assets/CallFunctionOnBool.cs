using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CallFunctionOnBool : MonoBehaviour
{
    [SerializeField] private BoolStatsSO boolStat;
    [SerializeField] private UnityEvent onBoolTrue, onBoolFalse;

    private void Start()
    {
        if (boolStat.isActivated())
        {
            onBoolTrue?.Invoke();
        }
        else
        {
            onBoolFalse?.Invoke();
        }
    }
}
