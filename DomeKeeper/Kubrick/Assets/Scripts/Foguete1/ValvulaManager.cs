using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValvulaManager : MonoBehaviour
{
    public SpawnFoguete spawnFoguete;
    public Image pression;
    public int choosenNumber;
    public bool win;
    public Animator luz;
    public MinigameManager minigameManager;

    private void Start()
    {
        choosenNumber = spawnFoguete.choosenNumber;
    }

    public void CheckWin()
    {
        if (pression.fillAmount * 10 >= choosenNumber - 0.2f && pression.fillAmount * 10 <= choosenNumber + 0.2f)
        {
            luz.SetBool("On", true);
            StartCoroutine(minigameManager.NextMinigame());
            SoundManager.instance.Play("Acerto", 1);
            win = true;
        }
    }
}
