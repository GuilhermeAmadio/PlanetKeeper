using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyFragments : MonoBehaviour
{
    public static ApplyFragments instance;

    [SerializeField] private BoolStatsSO fragmentsActivated;
    [SerializeField] private CharacterStat fragmentsCDStat, fragmentsAmount;

    private bool canFragments = true;

    private void Awake()
    {
        instance = this;
    }

    public bool CheckFragments()
    {
        if (fragmentsActivated.activated)
        {
            if (canFragments)
            {
                StartCoroutine(FragmentsCD());

                return true;
            }
        }

        return false;
    }

    public float GetFragmentsAmount()
    {
        return fragmentsAmount.GetCurrentStat();
    }

    private IEnumerator FragmentsCD()
    {
        canFragments = false;

        yield return new WaitForSeconds(fragmentsCDStat.GetCurrentStat());

        canFragments = true;
    }
}
