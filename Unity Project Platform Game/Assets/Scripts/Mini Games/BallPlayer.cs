using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class BallPlayer : MonoBehaviour
{
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;


    public string currentColor;
    public Color colorBlue, colorYellow, colowPink, colorPurple;
    public Text scoreText;
    public Text highestScoreText;

    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;

    private int score,highestScore;
    private bool isGameStart;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("MiniGameScore"))
        {
            PlayerPrefs.SetInt("MiniGameScore", 0);
        }
        
        score = 0;
        highestScore = PlayerPrefs.GetInt("MiniGameScore");
        scoreText.text = "Score: " + score.ToString();
        highestScoreText.text = "Highest Score: " + highestScore.ToString();
        Time.timeScale = 0;
        isGameStart = false;
        SetRandomColor();
    }



    void Update()
    {
        if(Input.GetButton("Jump")) //|| Input.GetMouseButtonDown(0))
        {
            if(Time.timeScale == 0 && isGameStart == false)
            {
                isGameStart = true;
                Time.timeScale = 1;
            }
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "GameController")
        {
            SetRandomColor();
            Destroy(collision.gameObject);
            gameObjectSpawner();
            score++;
            scoreText.text = "Score: " + score.ToString();
            return;
        }
        if(collision.tag != currentColor)
        {
            Debug.Log("Game over!");
            if(score > highestScore)
            {
                highestScore = score;
                PlayerPrefs.SetInt("MiniGameScore",highestScore);

            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void SetRandomColor()
    {
        string[] colorIndex = {"Blue", "Yellow", "Purple", "Pink"};
        Color[] colorArray = {colorBlue, colorYellow, colorPurple, colowPink};
        int index = UnityEngine.Random.Range(0, 4);
        currentColor = colorIndex[index];
        spriteRenderer.color = colorArray[index];
    }

    private void gameObjectSpawner()
    {
        if(score < 4)
        {
            Instantiate(gameObject1, new Vector3(0, gameObject.transform.position.y + 8f, 0), Quaternion.identity);
        }
        else if(score >= 4)
        {
            int index = UnityEngine.Random.Range(0, 2);
            switch (index)
            {
                case 0:
                    Instantiate(gameObject1, new Vector3(0, gameObject.transform.position.y + 8f, 0), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(gameObject2, new Vector3(0, gameObject.transform.position.y + 8f, 0), Quaternion.identity);
                    break;
            }
        }
    }
    
}
