using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sound", menuName = "System/New Sound")]
public class SoundSO : ScriptableObject
{
    public SoundType soundType;

    public SoundList clips;

    [Range(0f, 1f)]
    public float volume = 1f;

    public bool loop;
}
