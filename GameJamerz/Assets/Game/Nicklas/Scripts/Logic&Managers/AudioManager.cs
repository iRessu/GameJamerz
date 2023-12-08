using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        } 

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    public void Setvolume(string name, float volume)
    {
        Debug.Log("Setting Volume of " + name + " to " + volume);
        Sound sound = Array.Find(sounds, s => s.name == name);
        if(sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        sound.source.volume = volume;
    }

    public void AdjustVolume(string name, float volumeMultiplier)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        
        if (sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Rasmus_Scene")
        {
            StopMainMenuMusic();
            Play("Main Theme");
        }
        else
        {
            Play("Main Menu Theme");
        }
    }

    public void SetGlobalVolume(float volume)
    {
        foreach(Sound s in sounds)
        {
            s.source.volume = volume;
        }
    }

    private void StopMainMenuMusic()
    {
        Sound mainMenuMusic = Array.Find(sounds, sound => sound.name == "Main Menu Theme");
        if(mainMenuMusic != null && mainMenuMusic.source.isPlaying)
        {
            mainMenuMusic.source.Stop();
        }
    }



    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sounds: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
}
