using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private int upgradeCost;

    [SerializeField] private FloatSO money;

    [SerializeField] private TMPro.TextMeshProUGUI upgradeCostText;

    [SerializeField] private UnityEvent onBuy;

    private void Start()
    {
        UpdateUpgradeCostText();
    }

    public void Buy()
    {
        if (money.GetValue() >= upgradeCost)
        {
            onBuy?.Invoke();

            money.DecreaseValue(upgradeCost);

            upgradeCost = Mathf.RoundToInt(upgradeCost + (upgradeCost * 0.15f));
        
            UpdateUpgradeCostText();
        }
    }

    private void UpdateUpgradeCostText()
    {
        upgradeCostText.text = upgradeCost.ToString();
    }
}
