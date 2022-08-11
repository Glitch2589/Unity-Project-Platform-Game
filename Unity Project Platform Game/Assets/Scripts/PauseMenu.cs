using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject character;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
        Time.timeScale = 1f;
    }
    public void DeclinedTeleport()
    {
        pauseMenu.SetActive(false);
    }

    public void StartTeleport()
    {
        pauseMenu.SetActive(false);
        character.transform.position = new Vector3(18, 44, character.transform.position.z);
        ChangeScene(0);
    }
    public void MinigameToMainMenu()
    {
        PlayerPrefs.SetFloat("CharacterPositionX", -9);
        PlayerPrefs.SetFloat("CharacterPositionY", 36);
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
}
