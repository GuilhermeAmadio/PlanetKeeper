using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigamesManager : MonoBehaviour
{
    public BoxCollider[] minigamesColl;
    public GameObject[] flechas;
    public Transform[] porta1, porta2;
    public Transform porta3;
    public Transform lightObj, camObj; 

    public GameObject foguete, ator2, objects, propCenario, final;

    private void Awake()
    {
        if (PlayerPrefs.GetString("Foguete1") == "true")
        {
            for (int i = 0; i < porta1.Length; i++)
            {
                porta1[i].rotation = Quaternion.Euler(0, 90, 0);
            }

            for (int i = 0; i < porta2.Length; i++)
            {
                porta2[i].rotation = Quaternion.Euler(0, 180, 0);
            }
            foguete.tag = "Foguete2";

            if (PlayerPrefs.GetString("Porta1") != "true")
            {
                FindObjectOfType<SoundManager>().Play("Porta", 0);
                PlayerPrefs.SetString("Porta1", "true");
            }
        }
        
        if (PlayerPrefs.GetString("Foguete2") == "true")
        {
            porta3.rotation = Quaternion.Euler(0, 270, 0);
            foguete.tag = "Foguete3";

            if (PlayerPrefs.GetString("Porta2") != "true")
            {
                FindObjectOfType<SoundManager>().Play("Porta", 0);
                PlayerPrefs.SetString("Porta2", "true");
            }
        }

        if (PlayerPrefs.GetString("Ator11") == "true" && PlayerPrefs.GetString("AtorDemitido") != "true")
        {
            ator2.SetActive(true);
        }

        if (PlayerPrefs.GetString("Telefone") == "true" && PlayerPrefs.GetString("Objects") != "true")
        {
            objects.SetActive(true);
        }

        if (PlayerPrefs.GetString("Edition1") == "true" && PlayerPrefs.GetString("Ator11") == "true" && PlayerPrefs.GetString("Light2") != "true") 
        {
            lightObj.eulerAngles = new Vector3(0, 0, 0);
            PlayerPrefs.SetFloat("LightIntensity", 0f);
        }

        if (PlayerPrefs.GetString("Edition1") == "true" && PlayerPrefs.GetString("Ator11") == "true" && PlayerPrefs.GetString("Cam2") != "true")
        {
            camObj.eulerAngles = new Vector3(0, 180, 0);
        }

        if (PlayerPrefs.GetString("Objects") == "true" && PlayerPrefs.GetString("Ator12") == "true" && PlayerPrefs.GetString("Light3") != "true")
        {
            lightObj.eulerAngles = new Vector3(0, 0, 0);
            PlayerPrefs.SetFloat("LightIntensity", 0f);
        }

        if (PlayerPrefs.GetString("Objects") == "true" && PlayerPrefs.GetString("Ator12") == "true" && PlayerPrefs.GetString("Cam3") != "true")
        {
            camObj.eulerAngles = new Vector3(0, 180, 0);
        }
        
        if (PlayerPrefs.GetString("Foguete3") == "true")
        {
            propCenario.SetActive(true);
            final.SetActive(true);
        }
    }

    public void ActivateMinigame(int index)
    {
        minigamesColl[index].enabled = true;
        flechas[index].SetActive(true);
    }

    public void DesactivateMinigame(int index)
    {
        minigamesColl[index].enabled = false;
        flechas[index].SetActive(false);
    }
}
