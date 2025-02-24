using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopManager : MonoBehaviour
{
    private Dictionary<SoundType, AudioSource> loopAudioSources = new Dictionary<SoundType, AudioSource>();

    public void NewLoopAudio(SoundType soundType, AudioClip clip, float volume)
    {
        AudioSource newLoopAudioSource = gameObject.AddComponent<AudioSource>();
        loopAudioSources.Add(soundType, newLoopAudioSource);

        newLoopAudioSource.clip = clip;
        newLoopAudioSource.volume = volume;
        newLoopAudioSource.loop = true;
        newLoopAudioSource.Play();
    }

    public void StopLoop(SoundType soundType)
    {
        if (loopAudioSources.ContainsKey(soundType))
        {
            loopAudioSources[soundType].Stop();
            loopAudioSources.Remove(soundType);
        }
    }
}
