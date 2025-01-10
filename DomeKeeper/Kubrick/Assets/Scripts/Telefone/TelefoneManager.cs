using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelefoneManager : MonoBehaviour
{
    public string telefoneADiscar, telefoneDiscado;
    private bool winCheck, loseCheck;
    public GameObject win, lose;

    public void Teclar(string tecla)
    {
        if (!winCheck && !loseCheck)
        {
            FindObjectOfType<SoundManager>().Play("Phone", 5);
            telefoneDiscado += tecla;
        }
    }

    public void Ligar()
    {
        FindObjectOfType<SoundManager>().Play("Phone", 5);
        if (telefoneDiscado == telefoneADiscar)
        {
            winCheck = true;
            telefoneDiscado = null;
            win.SetActive(true);
            PlayerPrefs.SetString("Telefone", "true");
            PlayerPrefs.SetString("Kubrick6", "true");
        }
        else
        {
            lose.SetActive(true);
            loseCheck = true;
            telefoneDiscado = null;
        }
    }

    public void Cancelar()
    {
        FindObjectOfType<SoundManager>().Play("Phone", 5);
        telefoneDiscado = null;
    }
}
