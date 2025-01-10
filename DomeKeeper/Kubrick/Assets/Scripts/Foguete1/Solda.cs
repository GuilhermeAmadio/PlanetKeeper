using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Solda : MonoBehaviour
{
    private bool isWelding = false, isSolding, isSolded;
    public Image solda, thisSolda;
    public ParticleSystem faisca;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isWelding = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isWelding = false;
        }
    }

    public void PointerEnter()
    {
        if (isWelding && !isSolding)
        {
            StartCoroutine(Soldar());
        }
    }

    IEnumerator Soldar()
    {
        isSolding = true;

        while (isSolding && !isSolded) {
            thisSolda.color = new Color(thisSolda.color.r, thisSolda.color.g, thisSolda.color.b, thisSolda.color.a -0.51f);
            solda.color = new Color(solda.color.r, solda.color.g, solda.color.b, solda.color.a + 0.51f);
            faisca.Play();

            if (thisSolda.color.a <= 0)
            {
                FindObjectOfType<SoldaManager>().Solda();
                isSolded = true;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    public void PointerExit()
    {
        isSolding = false;
    }
}
