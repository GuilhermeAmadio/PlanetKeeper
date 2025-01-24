using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Experience", menuName = "Stats/New Experience")]
public class ExperienceSO : ScriptableObject
{
    [SerializeField] private float[] experienceMarks;

    public float GetExperience(int index)
    {
        return experienceMarks[index];
    }
}
