using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumbers : MonoBehaviour
{
    [SerializeField] private InstantiateObj floatingText;

    private bool canShow;

    public void DamageNumber(float amount)
    {
        if (canShow)
        {
            GameObject damageNumber = floatingText.InstantiateObject();
            FloatingText floatingNumber = damageNumber.GetComponent<FloatingText>();
            floatingNumber.SetText(amount.ToString());
        }
    }

    public void CanShow(bool canShow)
    {
        this.canShow = canShow;
    }
}
