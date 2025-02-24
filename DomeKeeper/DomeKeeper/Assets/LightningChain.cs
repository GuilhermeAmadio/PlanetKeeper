using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningChain : MonoBehaviour
{
    [SerializeField] private CharacterHealth charHealth;
    [SerializeField] private FloatStatsSO lightningDamage;

    [SerializeField] private GetObjectsInRange getObjects;

    private bool beenStruck;

    public void Chain(float chainValue)
    {
        beenStruck = true;
        StartCoroutine(LightningReset());

        charHealth.TakeDamage(lightningDamage.GetCurrentValue(), gameObject);

        Debug.Log("Lightning Chain: " + chainValue);

        //criar particula nesse objeto

        if (chainValue >= 1)
        {
            List<GameObject> closestEnemies = getObjects.GetSortedObjects();

            if (closestEnemies.Count > 0 )
            {
                for (int i = 0; i < closestEnemies.Count; i++)
                {
                    LightningChain closestEnemyChain = closestEnemies[i].GetComponentInChildren<LightningChain>();

                    if (!closestEnemyChain.GetBeenStruck())
                    {
                        closestEnemyChain.Chain(chainValue - 1);

                        //criar line renderer para o proximo objeto

                        break;
                    }
                }
            }
        }
    }

    public bool GetBeenStruck()
    {
        return beenStruck;
    }

    private IEnumerator LightningReset()
    {
        yield return new WaitForSeconds(0.5f);

        beenStruck = false;
    }
} 
