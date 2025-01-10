using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Papel : MonoBehaviour
{
    public string papel;

    private void Awake()
    {
        if (PlayerPrefs.GetString(papel) == "true")
        {
            gameObject.SetActive(false);
        }
    }

    public void TakePapel()
    {
        PlayerPrefs.SetString(papel, "true");
        gameObject.SetActive(false);
    }
}
