using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestruirFita : MonoBehaviour
{
    public bool final;

    private bool col;
    public Image colImage;
    public BoxCollider boxCol;
    public CarreiraFitas carreiraFitas;

    private void OnEnable()
    {
        if (final)
        {
            colImage.enabled = false;
            boxCol.enabled = false;
        }
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) && col)
        {
            colImage.enabled = false;
            boxCol.enabled = false;
            col = false;
            carreiraFitas.Check();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Slicer"))
        {
            col = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Slicer"))
        {
            col = false;
        }
    }
}
