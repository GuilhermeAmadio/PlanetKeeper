using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    public MinigameManager minigameManager;
    public GameObject[] variations;
    public ButtonVariation buttonVariation;
    public bool win;

    //private void Start()
    //{
    //    int randomVariation = Random.Range(0, variations.Length);
    //    variations[randomVariation].SetActive(true);

    //    buttonVariation = variations[randomVariation].GetComponent<ButtonVariation>();
    //}

    public void CheckWin()
    {
        int n = 0;

        for (int i = 0; i < buttonVariation.lamps.Length; i++)
        {
            if (buttonVariation.lamps[i].GetBool("On") == true)
            {
                n++;
            }
        }

        if (n == buttonVariation.lamps.Length)
        {
            win = true;
            SoundManager.instance.Play("Acerto", 1);
            StartCoroutine(minigameManager.NextMinigame());
        }
    }
}
