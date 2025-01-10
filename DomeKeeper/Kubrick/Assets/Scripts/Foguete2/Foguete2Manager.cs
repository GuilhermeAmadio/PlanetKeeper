using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foguete2Manager : MonoBehaviour
{
    public GameObject[] fases;
    private int index = -1;
    public TMPro.TextMeshProUGUI minigamesText;
    public string[] minigames;

    public GameObject win;
    public Animator foguete, BG;

    private void Start()
    {
        FindObjectOfType<SoundManager>().Play("Countdown", 1);
        StartCoroutine(StartMinigame());
    }

    private IEnumerator StartMinigame()
    {
        yield return new WaitForSeconds(1f);
        NextFase();
    }

    public void NextFase()
    {
        index++;
        if (index > 0)
        {
            foguete.SetTrigger("BG" + index);
            BG.SetTrigger("BG" + index);
        } 

        if (index == fases.Length)
        {
            win.SetActive(true);
            PlayerPrefs.SetString("Foguete2", "true");
        }
        else
        {
            StartCoroutine(WaitForFase());
        }
    }

    private IEnumerator WaitForFase()
    {
        yield return new WaitForSeconds(1f);
        minigamesText.text = minigames[index];
        fases[index].SetActive(true);

        yield return new WaitForSeconds(1f);
        minigamesText.text = "";
    }
}
