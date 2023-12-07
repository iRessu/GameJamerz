using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTimer : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    [SerializeField] float actualDuration = 2.5f;
    [SerializeField] float  displayMultiplier= 2;
    public float remaningTime;


    private void Start()
    {
        remaningTime = actualDuration * 60;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(remaningTime > 0)
        {
            remaningTime -= Time.deltaTime;
        }
        else if(remaningTime < 0)
        {
            remaningTime = 0;
            GameOver();
        }
        float minutes = Mathf.FloorToInt((remaningTime / 60) * displayMultiplier);
        float seconds = Mathf.FloorToInt(remaningTime * displayMultiplier % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    void GameOver()
    {

        if(remaningTime == 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
