using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent onPerformed, onCanceled;
    [SerializeField] private UnityEvent<float> performedWithFloat;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

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

    public void KeyAxis(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            performedWithFloat?.Invoke(context.ReadValue<float>());
        }

        if (context.canceled)
        {
            onCanceled?.Invoke();
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started)
        {
            return;
        }

        var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider)
        {
            return;
        }


        if (rayHit.collider.gameObject.GetComponent<IClickable>() != null)
        {
            rayHit.collider.gameObject.GetComponent<IClickable>().Click();
        }
    }
}
