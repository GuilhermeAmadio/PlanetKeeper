using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    [SerializeField] private string preText, middleText, posText;

    [SerializeField] private TextMeshProUGUI textToUpdate;

    private void Start()
    {
        UpText();
    }

    public void UpdatePreText(string text)
    {
        preText = text;

        UpText();
    }

    public void UpdateMiddleText(string text)
    {
        middleText = text;

        UpText();
    }

    public void UpdatePosText(string text)
    {
        posText = text;

        UpText();
    }

    public void UpText()
    {
        textToUpdate.text = preText + " " + middleText + " " + posText;
    }

    private void OnEnable()
    {
        UpText();
    }
}
