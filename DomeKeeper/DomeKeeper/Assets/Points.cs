using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private FloatStatsSO money;
    [SerializeField] private TMPro.TextMeshProUGUI moneyText;

    private void Update()
    {
        moneyText.text = "Points: " + money.GetCurrentValue().ToString();
    }
}
