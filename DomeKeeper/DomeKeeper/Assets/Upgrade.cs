using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Upgrade : MonoBehaviour, IClickable
{
    [SerializeField] private UpgradeSO upgradeInfo;

    [SerializeField] private StatSO rock, circuit, matter;

    [SerializeField] private TMPro.TextMeshPro upgradeNametext, upgradeCostText;

    [SerializeField] private IncreaseStat statToUpgrade;

    [SerializeField] private UpgradeConnection[] upgradeConnections;

    private int upgradeCost, index;
    private bool canBuy = true;

    private void Start()
    {
        upgradeNametext.text = upgradeInfo.GetUpgradeName();
        UpdateUpgradeCost();
    }

    public void Buy()
    {
        StatSO money = null;

        if (upgradeInfo.GetMoneyType(index) == MoneyType.ROCK)
        {
            money = rock;
        }
        else if (upgradeInfo.GetMoneyType(index) == MoneyType.CIRCUIT)
        {
            money = circuit;
        }
        else
        {
            money = matter;
        }

        if (money.GetValue() >= upgradeCost && canBuy)
        {
            statToUpgrade.Increase(upgradeInfo.GetUpgradeValue(index));

            money.ChangeValue(-upgradeCost);

            index++;
            CheckConnections();

            UpdateUpgradeCost();
        }
    }

    private void UpdateUpgradeCost()
    {
        if (index >= upgradeInfo.GetUpgradeInfoLength())
        {
            //aqui eu desabilito o upgrade

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
