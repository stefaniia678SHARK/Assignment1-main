using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MusicManager : MonoBehaviour
{   
//HOW TO USE Music manager:
//it is a singleton, meaning you can call it from any script
//do MusicManager.instance.PlaySound(*EXACT NAME OF SOUND CLIP*); to play the sound

    public static MusicManager instance;
    public AudioClip[] audioClips;
    public AudioSource[] audioSources;
    void Awake()

    {
        // Singleton check in Awake()
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return; // Important: stop executing if this is a duplicate
        }
    }
    void Start()
    {
    }


    public void PlaySound(string name)
    {
        AudioClip clipToPlay = null;

        // Find the matching audio clip
        foreach (AudioClip clip in audioClips)
        {
            if (clip.name == name)
            {
                clipToPlay = clip;
                break;
            }
        }

        if (clipToPlay == null) return; //if clip is not found

        // Find first available audio source or create a new one
        AudioSource availableSource = Array.Find(audioSources, source => !source.isPlaying);

        if (availableSource == null)
        {
            // If all sources are in use, dynamically add a new audio source
            availableSource = gameObject.AddComponent<AudioSource>();
            audioSources = audioSources.Append(availableSource).ToArray();
        }

        availableSource.clip = clipToPlay;
        availableSource.Play();
    }

}