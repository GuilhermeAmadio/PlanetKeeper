using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour, IClickable
{
    [SerializeField] private UpgradeSO upgradeInfo;

    [SerializeField] private MoneyStatType[] moneyTypes;

    [SerializeField] private SpriteRenderer upgradeSprite;
    [SerializeField] private TMPro.TextMeshPro upgradeNametext, upgradeCostText;

    //[SerializeField] private IncreaseStat statToUpgrade;

    [SerializeField] private UpgradeConnection[] upgradeConnections;

    private int upgradeCost, index;
    private bool canBuy = true;

    private void Start()
    {
        upgradeNametext.text = upgradeInfo.GetUpgradeName();
        upgradeSprite.sprite = upgradeInfo.GetUpgradeSprite();

        for (int i = 0; i < upgradeInfo.GetUpgradeInfoLength(); i++)
        {
            index = i;
            if (!upgradeInfo.GetUpgraded(i))
            {
                break;
            }
        }

        UpdateUpgradeCost();
    }

    public void Buy()
    {
        if (canBuy)
        {
            StatSO money = Array.Find(moneyTypes, moneyType => moneyType.moneyType == upgradeInfo.GetMoneyType(index)).stat;

            if (money.GetValue() >= upgradeCost && canBuy)
            {
                money.ChangeValue(-upgradeCost);

                upgradeInfo.Upgrade(index);
                index++;

                CheckConnections();

                UpdateUpgradeCost();
            }
        }
    }

    private void UpdateUpgradeCost()
    {
        if (index >= upgradeInfo.GetUpgradeInfoLength())
        {
            canBuy = false;

            return;
        }

        upgradeCost = upgradeInfo.GetUpgradeCost(index);
        upgradeCostText.text = upgradeCost.ToString();
    }

    private void CheckConnections()
    {
        if (upgradeConnections != null)
        {
            foreach (UpgradeConnection upgradeConnection in upgradeConnections)
            {
                upgradeConnection.CheckConnection(index);
            }
        }
    }

    public void Click()
    {
        Buy();
    }
}

[System.Serializable]
public class MoneyStatType
{
    public MoneyType moneyType;
    public StatSO stat;
}
