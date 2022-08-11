using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highestScoreText;
    public float score = 0;
    private float highestScore;

    private void Start()
    {

        if (!PlayerPrefs.HasKey("Highest Score"))
        {
            highestScore = 0;
        }
        highestScore = PlayerPrefs.GetFloat("Highest Score", highestScore);
        //score = PlayerPrefs.GetFloat("TempScore");
    }
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            if(Time.timeScale != 0)
            {
                score += 0.005f;
            }
            
        }
        if (score > highestScore)
        {
            HighestScore();
            PlayerPrefs.SetFloat("Highest Score", highestScore);
        }
        scoreText.text = "Score: " + ((int)score).ToString() + "m";
        TempScore();
        highestScoreText.text = "Highest Score: " + ((int)highestScore).ToString() + "m";
    }


    public void HighestScore()
    {
        highestScore = score;
    }

    void TempScore()
    {
        PlayerPrefs.SetFloat("TempScore", score);
    }
}
