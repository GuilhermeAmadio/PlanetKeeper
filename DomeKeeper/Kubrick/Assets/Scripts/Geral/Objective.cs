using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public string minigame;
    public int index;

    private Animator checkBox;

    private void Awake()
    {
        checkBox = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        if (PlayerPrefs.GetString(minigame) == "true")
        {
            checkBox.SetTrigger("Check");
            FindObjectOfType<MinigamesManager>().DesactivateMinigame(index);
            FindObjectOfType<ObjetivesAll>().Check();
        }
        else
        {
            FindObjectOfType<MinigamesManager>().ActivateMinigame(index);
        }
    }

    private void OnDisable()
    {
        if (FindObjectOfType<MinigamesManager>() != null)
        {
            FindObjectOfType<MinigamesManager>().DesactivateMinigame(index);
        }
    }
}
