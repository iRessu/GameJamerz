using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private Animator anim;


    private void Start()
    {
        StartCoroutine(PlayBeforeStarting());
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }


    IEnumerator PlayBeforeStarting()
    {

        yield return new WaitForSeconds(60);

        LoadMenuSCene();

    }



    void LoadMenuSCene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
