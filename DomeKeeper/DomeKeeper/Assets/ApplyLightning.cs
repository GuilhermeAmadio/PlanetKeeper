using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyLightning : MonoBehaviour
{
    [SerializeField] private BoolStatsSO lightningActivated;
    [SerializeField] private CharacterStat lightningCDStat, lightningSpread;

    private bool canLightning = true;

    public bool CheckLightning()
    {
        if (lightningActivated.activated)
        {
            if (canLightning)
            {
                StartCoroutine(LightningCD());

                return true;
            }
        }

        return false;
    }

    private IEnumerator LightningCD()
    {
        canLightning = false;

        yield return new WaitForSeconds(lightningCDStat.GetValue());

        canLightning = true;
    }

    public float GetLightningSpread()
    {
        return lightningSpread.GetValue();
    }
}
