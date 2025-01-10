using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeeleHitbox : MonoBehaviour
{
    [SerializeField] private FloatStatsSO damage;

    [SerializeField] private float range;
    [SerializeField] private LayerMask enemiesLayer;

    [SerializeField] private UnityEvent<GameObject> onHit;

    private List<GameObject> enemiesHitted = new List<GameObject>();

    private void Update()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, range, enemiesLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (!enemiesHitted.Contains(enemy.gameObject))
            {
                enemy.GetComponentInChildren<CharacterHealth>()?.TakeDamage(damage.GetCurrentValue(), gameObject);

                enemiesHitted.Add(enemy.gameObject);

                if (onHit != null)
                {
                    onHit.Invoke(enemy.gameObject);
                }
            }
        }
    }

    private void OnEnable()
    {
        enemiesHitted.Clear();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
