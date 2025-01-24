using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnMouse : MonoBehaviour
{
    [SerializeField] private UnityEvent onDown, onUp, onEnter, onExit;

    private void OnMouseDown()
    {
        Debug.Log("teste");
        onDown?.Invoke();
    }

    private void OnMouseUp()
    {
        onUp?.Invoke();
    }

    private void OnMouseEnter()
    {
        onEnter?.Invoke();
    }

    private void OnMouseExit()
    {
        onExit?.Invoke();
    }
}
