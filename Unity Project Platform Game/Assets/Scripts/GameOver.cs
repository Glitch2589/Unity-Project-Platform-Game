using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;

    private void Start()
    {
        gameResume();
    }
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameOverPanel.SetActive(true);
            pauseGame();
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
    }

    public void gameResume()
    {
        Time.timeScale = 1;
    }
}
