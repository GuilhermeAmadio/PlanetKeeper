using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private TextMeshPro floatingText;

    public void SetText(string text)
    {
        floatingText.text = text;   
    }
}
