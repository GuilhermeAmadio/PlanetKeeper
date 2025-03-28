using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Upgrade/New Upgrade")]
public class UpgradeSO : ScriptableObject
{
    [SerializeField] private string upgradeName;
    [SerializeField] private Sprite upgradeSprite;
    [SerializeField] private BoolStatsSO statActivated;
    [SerializeField] private StatSO stat;

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

    public Sprite GetUpgradeSprite()
    {
        return upgradeSprite;
    }

    public MoneyType GetMoneyType(int index)
    {
        return upgradesInfo[index].type;
    }

    public bool GetUpgraded(int index)
    {
        return upgradesInfo[index].upgraded;
    }

    public void Upgrade(int index)
    {
        upgradesInfo[index].upgraded = true;

        if (statActivated != null)
        {
            statActivated.Activate();
        }

        stat.UpgradeValue(GetUpgradeValue(index));
    }

    public void ResetUpgrade()
    {
        stat.ResetUpgrade();

        for (int i = 0;  i < upgradesInfo.Length; i++)
        {
            upgradesInfo[i].upgraded = false;
        }
    }
}
