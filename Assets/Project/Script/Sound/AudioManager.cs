using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        //DontDestroyOnLoad(gameObject);
     foreach (Sound s in sounds)
        {
            s.sources = gameObject.AddComponent<AudioSource>();
            s.sources.clip = s.clip;

            s.sources.volume = s.volume;
            s.sources.pitch = s.pitch;
            s.sources.loop = s.loop;
        }
    }

    void Start()
    {
        Play("Theme");
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound" + name + "not found!");
            return;
        }
            
        s.sources.Play();

    }
}
