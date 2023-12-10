using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScrene : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private GameObject textToActivate;


    private void Start()
    {
        StartCoroutine(WaitBeforeButton());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }


    IEnumerator WaitBeforeButton()
    {
        yield return new WaitForSeconds(3);
        textToActivate.SetActive(true);
    }
}
