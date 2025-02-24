using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyKnockback : MonoBehaviour
{
    [SerializeField] private CharacterStat knockbackForce;

    public void Knockback(GameObject obj)
    {
        Knockback knockbackObj = obj.GetComponentInChildren<Knockback>();
        if (knockbackObj != null)
        {
            knockbackObj.PlayKnockbackWithForce(gameObject, knockbackForce.GetCurrentStat());
        }
    }
}
