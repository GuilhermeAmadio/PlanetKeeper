using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActionNeed", menuName = "Action/New ActionNeed")]
public class ActionNeedSO : ScriptableObject
{
    [SerializeField] private FloatSO resource;
    [SerializeField] private float resourceNeed;

    public bool HasResource()
    {
        if (resource.GetValue() >= resourceNeed)
        {
            return true;
        }

        return false;
    } 

    public void Spend()
    {
        resource.DecreaseValue(resourceNeed);
    }
}
