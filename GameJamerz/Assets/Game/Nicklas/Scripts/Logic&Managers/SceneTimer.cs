using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTimer : MonoBehaviour
{

    public TextMeshProUGUI timerText;

    [SerializeField] float remainingTime;



    // Update is called once per frame
    void Update()
    {
       
        if(remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if(remainingTime < 0)
        {
            remainingTime = 0;
            GameOver();
        }
        float minutes = Mathf.FloorToInt(remainingTime / 60);
        float seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    void GameOver()
    {

        if(remainingTime == 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
