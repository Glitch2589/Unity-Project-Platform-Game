using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public Text nameText;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;

    private void Awake()
    {
    }
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        UpdateCharacter(selectedOption);
    }

    public void NextOption()
    {
        selectedOption++;
        if(selectedOption >= characterDB.CharacterCount)
        {
            selectedOption = 0; 
        }
        UpdateCharacter(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption = characterDB.CharacterCount - 1;
        }
        UpdateCharacter(selectedOption);
        Save();
    }

    private void UpdateCharacter(int selectedOption)
    {
        CharacterInformation characterInfo = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = characterInfo.characterSprite;
        nameText.text = characterInfo.characterName;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

    public void OkButton()
    {
        SceneManager.LoadScene(0);
    }
}
