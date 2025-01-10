using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlavancaManager : MonoBehaviour
{
    public Transform papel, alavanca;
    public SpawnFoguete spawnFoguete;
    public bool win;
    public Animator luz;
    public MinigameManager minigameManager;

    private void Start()
    {
        papel = spawnFoguete.choosenSpawn;
    }

    public void CheckWin()
    {
        if (alavanca.position.y >= papel.position.y - 0.3f && alavanca.position.y <= papel.position.y + 0.3f)
        {
            luz.SetBool("On", true);
            StartCoroutine(minigameManager.NextMinigame());
            win = true;
            SoundManager.instance.Play("Acerto", 1);
        }
    }
}
