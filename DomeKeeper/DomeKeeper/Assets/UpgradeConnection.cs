using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeConnection : MonoBehaviour
{
    [SerializeField] private int indexNeeded;
    [SerializeField] private GameObject upgradeConnect;
    [SerializeField] private LineRenderer line;

    public void CheckConnection(int index)
    {
        if (index == indexNeeded)
        {
            upgradeConnect.SetActive(true);
            line.SetPosition(0, transform.position);
            line.SetPosition(1, upgradeConnect.transform.position);
        }
    }
}
