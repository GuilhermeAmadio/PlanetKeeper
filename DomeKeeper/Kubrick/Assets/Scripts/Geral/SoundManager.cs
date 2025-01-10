
using UnityEngine.Audio;
using UnityEngine;
using System;
using Unity.Mathematics;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public Sound[] sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;
        }
    }

    public void Play(string name, int variations)
    {
        Sound s = null;

        if (variations > 0)
        {
            int n = UnityEngine.Random.Range(1, variations + 1);

            s = Array.Find(sounds, sound => sound.name == name + n);
        }
        else
        {
            s = Array.Find(sounds, sound => sound.name == name);
        }

        if (s == null)
        {
            return;
        }

        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            return;
        }

        s.source.Stop();
    }
}
