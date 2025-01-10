using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInvencibility : MonoBehaviour
{
    [SerializeField] private float ifTimer;
    [SerializeField] private int ifFlashCount;

    [SerializeField] private CharacterHealth charHealth;
    [SerializeField] private FlashHit flashHit;

    private float ifTimeBetween;

    private void Start()
    {
        ifTimeBetween = ifTimer / ifFlashCount;
    }

    public void StartIFrames()
    {
        charHealth.SetInvencibility(true);
        flashHit.FlashMultipleTimes(true);

        StartCoroutine(IFrames());
    }

    private IEnumerator IFrames()
    {
        int i = 0;

        while (i <= ifFlashCount)
        {
            i++;

            yield return new WaitForSeconds(ifTimeBetween);
        }

        charHealth.SetInvencibility(false);
        flashHit.FlashMultipleTimes(false);
    }
}
