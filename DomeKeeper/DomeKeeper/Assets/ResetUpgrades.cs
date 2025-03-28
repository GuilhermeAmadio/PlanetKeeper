using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetUpgrades : MonoBehaviour
{
    [SerializeField] private UpgradeSO[] upgrades;

    private void Awake()
    {
        for (int i = 0; i < upgrades.Length; i++)
        {
            upgrades[i].ResetUpgrade();
        }
    }
}
