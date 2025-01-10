using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    [SerializeField] private FloatSO moneyStat;

    [SerializeField] private TextMeshProUGUI moneyText;

    private void Awake()
    {
        instance = this;
    }

    public void IncreaseMoney(float amount)
    {
        moneyStat.IncreaseValue(amount);
    }
}
