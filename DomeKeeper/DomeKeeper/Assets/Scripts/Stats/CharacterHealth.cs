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
                amount -= armor.GetCurrentStat();

            if (amount < 0)
            {
                return;
            }

            Debug.Log("Take Damage: " + amount);

            float damageToTake = amount - (amount * damageMitigation);

            healthStat?.DecreaseStat(damageToTake);

            if (damageMitigation != 1)
            {
                onHit?.Invoke(sender);
                damageNumbers?.DamageNumber(damageToTake);
            }

            if (defense)
            {
                onDefense?.Invoke(sender);
            }

            if (healthStat.GetCurrentStat() <= 0 && !dead)
            {
                dead = true;
                onDeath?.Invoke();
            }
            else if (healthStat.GetCurrentStat() > 0)
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
        healthStat?.IncreaseStat(amount);

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

    public void DebugSomething(string message)
    {
        Debug.Log(message);
    }
} 
