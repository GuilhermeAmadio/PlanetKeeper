using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent onPerformed, onCanceled;

    public void Key(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            onPerformed?.Invoke();
        }
        
        if (context.canceled)
        {
            onCanceled?.Invoke();
        }
    }
}
