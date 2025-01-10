using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer : MonoBehaviour
{
    public ParticleSystem papel;

    private bool col;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (col)
            {
                papel.Play();
                col = false;
                SoundManager.instance.Play("CutPaper", 1);
            }
            else if (!col && !FindObjectOfType<EditionManager>().winned)
            {
                FindObjectOfType<EditionManager>().Loss();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fita"))
        {
            col = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Fita"))
        {
            col = false;
        }
    }
}
