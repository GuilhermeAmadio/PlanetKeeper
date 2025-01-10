using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa : MonoBehaviour
{
    public void OpenMap()
    {
        FindObjectOfType<SoundManager>().Play("AbrirMapa", 1);
    }

    public void CloseMap() 
    {
        FindObjectOfType<SoundManager>().Play("FecharMapa", 1);
    }
}
