using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foguete3Manager : MonoBehaviour
{
    public float timer;

    public GameObject win, lose;

    private int checks;

    public void Check()
    {
        checks++;
        if (checks == 4)
        {
            win.SetActive(true);
            PlayerPrefs.SetString("Foguete3", "true");
        }
    }
}
