using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Stat/Bool")]
public class BoolStatsSO : ScriptableObject
{
    //public StatsEnum statsName;

    public bool activated;

    //public StatsEnum GetStatsName() { return statsName; }

    public bool isActivated()
    {
        return activated;
    }

    public void Activate()
    {
        activated = true;
    }

    public void Deactivate()
    {
        activated = false;
    }
}
