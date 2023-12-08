using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{

    public Slider volumeSlider;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 01f);
        volumeSlider.value = savedVolume;
        SetVolume(savedVolume);
    }

    public void SetVolume(float volume)
    {
        FindObjectOfType<AudioManager>().instance.SetGlobalVolume(volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
