using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public Light lightFlicker;
    private float startIntensity;
    public float timeMin, timeMax;
    private bool canFlicker = true;

    private void Awake()
    {
        startIntensity = lightFlicker.intensity;
    }

    private void Start()
    {
        StartCoroutine(FlickerLight());
    }

    IEnumerator FlickerLight()
    {
        while (canFlicker)
        {
            float randomTime = Random.Range(timeMin, timeMax);

            yield return new WaitForSeconds(randomTime);

            lightFlicker.intensity = 1f;

            yield return new WaitForSeconds(0.1f);

            lightFlicker.intensity = startIntensity;
        }
    }
}
