using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] private int maxProgression, levelProgression;

    [SerializeField] private Slider levelSlider;

    private void Awake()
    {
        instance = this;
    }

    public void Progress()
    {
        levelProgression++;

        levelSlider.value = levelProgression;

        if (levelProgression >= maxProgression)
        {
            Debug.Log("Level Finalizado");
        }
    }
}
