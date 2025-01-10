using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldaManager : MonoBehaviour
{
    public int soldas;
    public GameObject[] variations;
    public MinigameManager minigameManager;

    private bool next;

    private void Start()
    {
        int randomVariation = Random.Range(0, variations.Length);
        variations[randomVariation].SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !next)
        {
            SoundManager.instance.Play("Solda", 1);
        }

        if (Input.GetMouseButtonUp(0))
        {
            SoundManager.instance.Stop("Solda1");
        }
    }

    public void Solda()
    {
        soldas--;

        CheckWin();
    }

    public void CheckWin()
    {
        if (soldas == 0)
        {
            StartCoroutine(minigameManager.NextMinigame());
            SoundManager.instance.Stop("Solda1");
            SoundManager.instance.Play("Acerto", 1);
            next = true;
        }
    }
}
