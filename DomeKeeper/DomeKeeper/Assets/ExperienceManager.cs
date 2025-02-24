using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    [SerializeField] private FloatSO money;
    [SerializeField] private ExperienceSO experience;

    private int level;

    private void Start()
    {
        CheckLevel();
    }

    public void CheckLevel()
    {
        if (money.GetValue() >= experience.GetExperience(level))
        {
            //Debug.Log("teste");
        }
    }
}
