/*
	Global Singleton Sound manager script 
	By: Kevin Kim
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton sound manager 
public class SoundManager : MonoBehaviour
{
    public AudioSource EffectsSource;
    public AudioSource MusicSource;
    public AudioClip menuMusic;
    public AudioClip buttonSound;

    public static SoundManager Instance = null;


    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        //DontDestroyOnLoad(gameObject);

        PlayMusic(menuMusic);
        setMusicVolume(0.3f);
    }


    // Play a single clip through the sound effects source.
    public void Play(AudioClip clip)
    {
        EffectsSource.clip = clip;
        EffectsSource.Play();
    }

    public void pauaseEffectMusic()
    {
        EffectsSource.Pause();
    }
    public void PlayOneShot(AudioClip clip)
    {
        EffectsSource.PlayOneShot(clip);
    }

    public void setEffectVolume(float volume)
    {
        EffectsSource.volume = volume;
    }



    // Play a single clip through the music source.
    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }

    public void PauseMusic()
    {
        MusicSource.Pause();
    }

    public void setMusicVolume(float volume)
    {
        MusicSource.volume = volume;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
