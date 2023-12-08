using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;

 
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
