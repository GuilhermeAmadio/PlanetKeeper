using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarreiraFitas : MonoBehaviour
{
    private EditionManager editionManager;
    public Fita[] fitasObjs;
    public int fitas;

    private int checks;

    private void OnEnable()
    {
        editionManager = FindObjectOfType<EditionManager>();
        fitas = fitasObjs.Length-1;
    }

    public void Check()
    {
        checks++;
        if (checks == fitas)
        {
            for (int i = 0; i < fitasObjs.Length; i++)
            {
                fitasObjs[i].ChangePos();
            }
            editionManager.NextCarreira();
        }
    }
}
