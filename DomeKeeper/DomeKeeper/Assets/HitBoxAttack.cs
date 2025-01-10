using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxAttack : MonoBehaviour
{
    public FloatSO charAttack;
    public string tagToCheck;

    public bool destroyObj;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(tagToCheck))
        {
            other.GetComponentInChildren<CharacterHealth>()?.TakeDamage(charAttack.GetValue(), gameObject);

            if (destroyObj)
            {
                Destroy(gameObject);
            }
        }
    }
}
