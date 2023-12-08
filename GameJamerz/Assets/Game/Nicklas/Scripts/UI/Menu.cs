using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;

    AudioManager am;

    private void Start()
    {
        am = FindObjectOfType<AudioManager>();
        am.Play("Main Menu Theme");
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Nu stängs det, lol");
    }
}
