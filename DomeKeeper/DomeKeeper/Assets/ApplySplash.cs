using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplySplash : MonoBehaviour
{
    [SerializeField] private BoolStatsSO splashActivated;
    [SerializeField] private CharacterStat splashCDStat;

    [SerializeField] private Transform splashPos;
    [SerializeField] private InstantiateObj instatianteSplash;

    private bool canSplash = true;

    public bool CheckSplash()
    {
        if (splashActivated.activated)
        {
            if (canSplash)
            {
                StartCoroutine(SplashCD());

                return true;
            }
        }

        return false;
    }

    public void Splash()
    {
        if (CheckSplash())
        {
            instatianteSplash.InstantiateObjectInPos(splashPos);
        }
    }

    private IEnumerator SplashCD()
    {
        canSplash = false;

        yield return new WaitForSeconds(splashCDStat.GetCurrentValue());

        canSplash = true;
    }
}
