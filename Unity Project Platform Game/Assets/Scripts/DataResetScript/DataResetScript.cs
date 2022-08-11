using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataResetScript : MonoBehaviour
{
    public void ResetCoin()
    {
        PlayerPrefs.SetInt("Coin Number", 0);
        int coin = PlayerPrefs.GetInt("Coin Number");
        Debug.Log("Reset Coin Successfully. Coin Number = " + coin);
    }
    public void ResetLevel()
    {
        PlayerPrefs.SetFloat("Character Exp.", 0);
        PlayerPrefs.SetInt("Upgrade Point", 0);
        PlayerPrefs.SetFloat("Bullet Load Speed", 2);
        PlayerPrefs.SetFloat("bulletDmg", 1);
        float exp = PlayerPrefs.GetFloat("Character Exp.");
        float point = PlayerPrefs.GetInt("Upgrade Point");
        Debug.Log("Reset Level Successfully. Coin Exp = " + exp + "Upgrade Point = " + point);
    }
    public void ResetPositionMenu()
    {
        PlayerPrefs.SetFloat("CharacterPositionX", 0);
        PlayerPrefs.SetFloat("CharacterPositionY", 0);
        PlayerPrefs.SetFloat("CharacterPositionZ", 0);
        Debug.Log("Reset Position Successfully. Position = ("+ PlayerPrefs.GetFloat("CharacterPositionX") + "," + PlayerPrefs.GetFloat("CharacterPositionY") + "," + PlayerPrefs.GetFloat("CharacterPositionZ") + ")");
    }
    public void ResetHighestScore()
    {
        PlayerPrefs.SetFloat("Highest Score", 0);
        Debug.Log("Reset Highest Score Successfully");
    }

    public void ResetCharacterStatus()
    {
        PlayerPrefs.SetInt("JumpBoost", 0);
        PlayerPrefs.SetInt("JumpBoost2", 0);
        Debug.Log("Reset Character Status Successfully");
    }
    
}
