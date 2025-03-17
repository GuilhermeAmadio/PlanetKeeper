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

    [SerializeField] private ApplyLightning applyLightning;
    [SerializeField] private ApplySplash applySplash;

    [SerializeField] private UnityEvent<GameObject> onHit;

    private bool canDealDamage, onCD;

    private void Update()
    {
        if (canDealDamage && !onCD)
        {
            DealDamage();
        }
    }

    private void DealDamage()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, range, enemiesLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponentInChildren<CharacterHealth>()?.TakeDamage(damage.GetValue() + ApplyCritical(), gameObject);

            if (applyLightning.CheckLightning())
            {
                enemy.GetComponentInChildren<LightningChain>().Chain(applyLightning.GetLightningSpread());
            }

            applySplash.Splash();

            onHit?.Invoke(enemy.gameObject);
        }

        if (hitEnemies.Length > 0)
        {
            StartCoroutine(OnCD());
        }
    }

    private IEnumerator OnCD()
    {
        onCD = true;

        yield return new WaitForSeconds(damageCD.GetValue());

        onCD = false;
    }

    public void SetCanDealDamage(bool can)
    {
        canDealDamage = can;
    }

    private float ApplyCritical()
    {
        if (criticalChance.CheckChance())
        {
            float critDamage = damage.GetValue() * criticalDamage.GetValue();
            return critDamage;
        }

        return 0;
    }

    public void SetRange(float newRange)
    {
        range = newRange;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
