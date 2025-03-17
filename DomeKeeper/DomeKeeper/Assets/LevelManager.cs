using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] private CharacterStat progressionStat;

    [SerializeField] private float maxProgression, levelProgression;

    [SerializeField] private bool progressionBasedOnEnemy;

    private void Awake()
    {
        instance = this;
    }

    public void Progress()
    {
        if (progressionBasedOnEnemy)
        {
            levelProgression++;

            progressionStat.ChangeCurrentValue(levelProgression);

            if (levelProgression >= maxProgression)
            {
                Debug.Log("Level Finalizado");
            }
        }
    }

    public float GetMaxLevelProgression()
    {
        return maxProgression;
    }

    private void OnEnable()
    {
        //progressionStat.ChangeStat(maxProgression);
    }
}
