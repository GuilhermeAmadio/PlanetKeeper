using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Stat/Manager")]
public class StatsSO : ScriptableObject
{
    public FloatStatsSO[] floatStats;

    public BoolStatsSO[] boolStats;

    //public FloatStatsSO FindFloatStat(StatsEnum statEnum)
    //{
    //    foreach (FloatStatsSO floatStat in floatStats)
    //    {
    //        if (floatStat.GetStatsName() == statEnum)
    //        {
    //            return floatStat;
    //        }
    //    }

    //    return null;
    //}
}
