using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumeroTelefone : MonoBehaviour
{
    public string number;

    private void Awake()
    {
        if (PlayerPrefs.GetString(number) != "true")
        {
            gameObject.SetActive(false);
        }
    }
}
