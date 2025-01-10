using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditionManager : MonoBehaviour
{
    public CarreiraFitas[] carreiras;
    public Transform carreiraPos;
    public GameObject win, lose;

    public int maxLoss;
    private int index = -1, loss, maxCarreiras;
    public bool winned;

    private void Awake()
    {
        if (PlayerPrefs.GetString("Edition1") == "true")
        {
            maxCarreiras = carreiras.Length;
        }
        else
        {
            maxCarreiras = 3;
        }
    }

    private void OnEnable()
    {
        NextCarreira();
    }

    public void NextCarreira()
    {
        index++;
        if (index == maxCarreiras)
        {
            winned = true;
            win.SetActive(true);
            if (PlayerPrefs.GetString("Edition1") != "true")
            {
                PlayerPrefs.SetString("Edition1", "true");
            }
            else
            {
                PlayerPrefs.SetString("Edition2", "true");
            }
        }
        else
        {
            GameObject carreira = Instantiate(carreiras[index].gameObject);
            carreira.transform.SetParent(carreiraPos);
            carreira.transform.position = carreiraPos.position;
        }
    }

    public void Loss()
    {
        loss++;
        if (loss > maxLoss)
        {
            lose.SetActive(true);
        }
    }
}
