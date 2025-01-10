using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase2Foguete : MonoBehaviour
{
    public Seta seta;
    public Cubo cubo;

    private void OnEnable()
    {
        seta.enabled = true;
        cubo.enabled = true;
    }
}
