using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorObject : MonoBehaviour
{
    [SerializeField] private Mouse.CursorType cursorType;

    private void OnMouseEnter()
    {
        Mouse.Instance.SetActiveCursorType(cursorType);
    }

    private void OnMouseExit()
    {
        Mouse.Instance.SetActiveCursorType(Mouse.CursorType.Mira);
    }
}
