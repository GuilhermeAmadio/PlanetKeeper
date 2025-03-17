using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private CharacterStat healthStat;

    [SerializeField] private CharacterInvencibility charInvencibility;
    [SerializeField] private DamageNumbers damageNumbers;

    [SerializeField] private UnityEvent<GameObject> onHit;
    //[SerializeField] private UnityEvent<GameObject> onHeavyHit;
    [SerializeField] private UnityEvent<GameObject> onDefense;
    [SerializeField] private UnityEvent onHeal;
    [SerializeField] private UnityEvent onRevive;
    [SerializeField] private UnityEvent onDeath;

    public CharacterStat armor;
    public float damageMitigation;
    public bool defense;

    //[SerializeField] private float heavyHitCaller;
    [SerializeField] private bool invencible;

    private bool dead;

    public void TakeDamage(float amount, GameObject sender)
    {
        if (!invencible)
        {
            if (armor != null)
                amount -= armor.GetValue();

            if (amount < 0)
            {
                return;
            }

            float damageToTake = amount - (amount * damageMitigation);
            Debug.Log("Take Damage: " + damageToTake);

            healthStat?.ChangeCurrentValue(-damageToTake);

            if (damageMitigation != 1)
            {
                onHit?.Invoke(sender);
                damageNumbers?.DamageNumber(damageToTake);
            }

            if (defense)
            {
                onDefense?.Invoke(sender);
            }

            if (healthStat.GetCurrentValue() <= 0 && !dead)
            {
                dead = true;
                onDeath?.Invoke();
            }
            else if (healthStat.GetCurrentValue() > 0)
            {
                charInvencibility?.StartIFrames();
            }
        }
    }

    public void Dead()
    {
        onDeath?.Invoke();
    }

    public void Heal(float amount)
    {
        healthStat?.ChangeCurrentValue(amount);

        onHeal?.Invoke();
    } 

    public void SetDamageMitigation(float amount, bool defense)
    {
        damageMitigation = amount;
        this.defense = defense;
    }

    public void SetInvencibility(bool invencibility)
    {
        invencible = invencibility;
    }

    public void Revive()
    {
        dead = false;
        onRevive?.Invoke();

        //Heal(healthStat.GetMaxStat() / 2);
    }
} 
