using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private SoundType sound;
    [SerializeField, Range(0, 1)] private float volume = 1f;

    public void Play()
    {
        SoundManager.PlaySound(sound, volume);
    }

    public void Stop()
    {
        SoundManager.StopLoop(sound);
    }
}
