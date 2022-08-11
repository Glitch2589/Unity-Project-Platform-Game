using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;




public class CharacterStatus : MonoBehaviour
{
    public static float oldLevel, currentLevel, bulletLoad, exp;
    public static int  maxExp;
    public Image expSlider;
    public Image bulletSlider;
    private float chargingBullet;
    public TextMeshProUGUI textLevel;
    private int upgradePoint;


    void Start()
    {
        bulletLoad = PlayerPrefs.GetFloat("Bullet Load Speed", bulletLoad);
        chargingBullet = bulletLoad;
        exp = PlayerPrefs.GetFloat("Character Exp.", exp);
        currentLevel = GetLevel(exp);
        oldLevel = currentLevel;
    }



    void Update()
    {
        
        textLevel.text = "Lv." + currentLevel.ToString();

        exp = PlayerPrefs.GetFloat("Character Exp.", exp);
        currentLevel = GetLevel(exp);
        if (currentLevel > oldLevel)
        {
            Debug.Log(currentLevel + "and" + oldLevel);
            upgradePoint = PlayerPrefs.GetInt("Upgrade Point");
            upgradePoint++;
            PlayerPrefs.SetInt("Upgrade Point", upgradePoint);
        }
        
        //PlayerPrefs.SetFloat("Character Exp.", exp);
        oldLevel = GetLevel(exp);
        expSlider.fillAmount = (exp - levelFormula(currentLevel)) / (levelFormula(currentLevel + 1) - levelFormula(currentLevel));
        bulletStatus();
        
        
    }

    public void bulletStatus()
    {
        if (Character.isShooted == true)
        {
            chargingBullet = 0;
            Character.isShooted = false;
        }
        chargingBullet += 1 * Time.deltaTime;
        bulletSlider.fillAmount = chargingBullet / bulletLoad;
    }

    public float levelFormula(float currentLevel)
    {
        exp = Mathf.Pow(currentLevel / 2, 2);
        return exp;
    }
    public float GetLevel(float exp)
    {
        currentLevel = (int)Mathf.Floor(Mathf.Sqrt(exp) * 2);
        return currentLevel;
    }
}