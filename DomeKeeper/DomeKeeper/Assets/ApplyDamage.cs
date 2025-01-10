using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDamage : MonoBehaviour
{
    [SerializeField] private FloatSO damage;

    public void ApplyDamageToCharacter(CharacterHealth charHealth)
    {
        charHealth.TakeDamage(damage.GetValue(), gameObject);
    }
}
