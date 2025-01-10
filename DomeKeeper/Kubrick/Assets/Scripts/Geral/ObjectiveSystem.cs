using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveSystem : MonoBehaviour
{
    public ObjetivesAll[] allMinigames;
    private int checks = -1;

    private void Awake()
    {
        NextMinigame();
    }

    public void NextMinigame()
    {
        if (checks != -1)
        {
            allMinigames[checks].gameObject.SetActive(false);
        }
        checks++;
        if (checks == allMinigames.Length)
        {
            return;
        }
        allMinigames[checks].gameObject.SetActive(true);
    }
}
