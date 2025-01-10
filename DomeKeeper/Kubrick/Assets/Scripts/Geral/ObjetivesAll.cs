using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivesAll : MonoBehaviour
{
    public Objective[] objectives;
    public int checks;

    public void Check()
    {
        //checks++;

        //if (checks == objectives.Length)
        //{
        //    FindObjectOfType<ObjectiveSystem>().NextMinigame();
        //}   

        for (int i = 0; i < objectives.Length; i++)
        {
            if (PlayerPrefs.GetString(objectives[i].minigame) == "true")
            {
                checks++;
                if (checks == objectives.Length)
                {
                    FindObjectOfType<ObjectiveSystem>().NextMinigame();
                }
            }
             
        }

        checks = 0;
    }
}
