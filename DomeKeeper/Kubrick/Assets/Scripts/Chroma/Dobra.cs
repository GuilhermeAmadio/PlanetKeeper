using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dobra : MonoBehaviour
{
    public ChromaMiniGame chroma;
    public ParticleSystem particle;
    private Animator anim;
    public bool subir;
    private int clicks = 1;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void OnClick()
    {
        clicks++;
        if (clicks < 5)
        {
            anim.SetInteger("Dobra", clicks);
        }
        else
        {
            chroma.Unfold();
            SoundManager.instance.Play("DobraSumindo", 1);
            //GameObject part = Instantiate(particle, pos.position, Quaternion.Euler(180f, 0, 0));
            //part.transform.SetParent(canvas);
            //part.transform.localPosition = pos.transform.localPosition;
            //part.transform.SetParent(outro);
            //Destroy(gameObject);
            particle.Play();
            GetComponent<Image>().enabled = false;
        }

        //if (subir)
        //{
        //    Instantiate(particle, pos.position, Quaternion.Euler(-90f, 0, 0));
        //    subir = false;
        //    Descer();
        //}
    }

    //public void Destroy()
    //{
    //    Destroy(gameObject, 0.01f);
    //}
}
