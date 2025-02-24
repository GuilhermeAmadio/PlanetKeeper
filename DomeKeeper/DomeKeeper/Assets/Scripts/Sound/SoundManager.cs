using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SoundList
{
    public AudioClip[] Sounds { get => sounds; }
    [SerializeField] private AudioClip[] sounds;
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private SoundSO[] sounds;

    [SerializeField] private LoopManager loopObject;

    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(SoundType soundType, float volume = 1f)
    {
        SoundSO s = Array.Find(instance.sounds, sound => sound.soundType == soundType);

        if (s == null) return;

        AudioClip[] clips = s.clips.Sounds;
        AudioClip randomClip = clips[UnityEngine.Random.Range(0, clips.Length)];

        if (s.loop)
        {
            instance.loopObject.NewLoopAudio(soundType, randomClip, volume);
            return;
        }

        instance.audioSource.PlayOneShot(randomClip, volume);
    }

    public static void StopLoop(SoundType soundType)
    {
        instance.loopObject.StopLoop(soundType);
    }
}

public enum SoundType
{
    LaserShoot,
    LaserStart,
    PointPickUp,
    MeteorHit,
    MeteorDestroyed,
    LaserHit
}
