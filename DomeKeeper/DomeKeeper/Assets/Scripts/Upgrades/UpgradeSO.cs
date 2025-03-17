using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Upgrade/New Upgrade")]
public class UpgradeSO : ScriptableObject
{
    [SerializeField] private string upgradeName;
    [SerializeField] private UpgradeInfo[] upgradesInfo;

    public int GetUpgradeCost(int index)
    {
        return upgradesInfo[index].cost;
    }

    public float GetUpgradeValue(int index)
    {
        return upgradesInfo[index].upgradeValue;
    }

    public int GetUpgradeInfoLength()
    {
        return upgradesInfo.Length;
    }

    public string GetUpgradeName()
    {
        return upgradeName;
    }

    public MoneyType GetMoneyType(int index)
    {
        return upgradesInfo[index].type;
    }
}
