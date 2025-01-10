using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateTextToCurrentFloat : MonoBehaviour
{
    [SerializeField] private string preText, posText;
    [SerializeField] private FloatSO stat;

    [SerializeField] private TextMeshProUGUI textToUpdate;

    public void UpdateText()
    {
        textToUpdate.text = preText + stat.GetValue().ToString() + posText;
    }
}
