using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class laserHitbox : MonoBehaviour
{
    [SerializeField] private CharacterStat damage;

    [SerializeField] private CharacterStat damageCD;

    [SerializeField] private float range;
    [SerializeField] private LayerMask enemiesLayer;

    [SerializeField] private Chance criticalChance;
    [SerializeField] private CharacterStat criticalDamage;

    [SerializeField] private UnityEvent<GameObject> onHit;

    private List<GameObject> enemiesHitted = new List<GameObject>();

    private IEnumerator DealDamage()
    {
        while (true)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, range, enemiesLayer);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponentInChildren<CharacterHealth>()?.TakeDamage(damage.GetCurrentStat() + ApplyCritical(), gameObject);

                if (onHit != null)
                {
                    onHit.Invoke(enemy.gameObject);
                }
            }

            yield return new WaitForSeconds(damageCD.GetCurrentStat());
        }
    }

    private float ApplyCritical()
    {
        if (criticalChance.CheckChance())
        {
            float critDamage = damage.GetCurrentStat() * criticalDamage.GetCurrentStat();
            return critDamage;
        }

        return 0;
    }

    public void SetRange(float newRange)
    {
        range = newRange;
    }

    private void OnEnable()
    {
        StartCoroutine(DealDamage());
    }

    private void OnDisable()
    {
        StopCoroutine(DealDamage());   
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
