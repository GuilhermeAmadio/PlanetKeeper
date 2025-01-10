using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashHit : MonoBehaviour
{
    public Material flashMaterial;
    private Material defaultMaterial;
    public SpriteRenderer sr;

    private bool flashingMultipleTimes;

    private void Awake()
    {
        defaultMaterial = sr.material;
    }

    public void Flash()
    {
        StartCoroutine(Flashing());
    }

    private IEnumerator Flashing()
    {
        sr.material = flashMaterial;

        yield return new WaitForSeconds(0.2f);

        sr.material = defaultMaterial;
    }

    public void FlashMultipleTimes(bool flash)
    {
        flashingMultipleTimes = flash;

        if (flash)
        {
            StartCoroutine(FlashTimes());
        }
    }

    private IEnumerator FlashTimes()
    {
        while (flashingMultipleTimes)
        {
            Flash();

            yield return new WaitForSeconds(0.3f);
        }

        sr.material = defaultMaterial;
    }
}
