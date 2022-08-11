using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UpgradeShopPage1 : MonoBehaviour
{
    public TextMeshProUGUI textAttackSpeedLevel;
    public TextMeshProUGUI textPowerLevel;


    private float attackSpeed, bulletDmg;
    private float attackSpeedLevel, attackPowerLevel;
    private int upgradePts;


    void Update()
    {
        upgradePts = PlayerPrefs.GetInt("Upgrade Point");
        attackSpeed = PlayerPrefs.GetFloat("Bullet Load Speed");
        bulletDmg = PlayerPrefs.GetFloat("bulletDmg");

        SkillLevelCalculation();
        textAttackSpeedLevel.text = "Level. " + attackSpeedLevel.ToString();
        textPowerLevel.text = "Level. " + attackPowerLevel.ToString();
    }

    private void SkillLevelCalculation()
    {
        attackSpeedLevel = Mathf.Round((2 - attackSpeed)*50);
        attackPowerLevel = Mathf.Round((bulletDmg - 1) / 0.2f);
    }

    public void AttackSpeedUpgradeButton()
    {
        if(upgradePts > 0)
        {
            attackSpeed -= 0.02f;
            upgradePts--;
            PlayerPrefs.SetInt("Upgrade Point", upgradePts);
            PlayerPrefs.SetFloat("Bullet Load Speed", attackSpeed);
        }
    }

    public void AttackPowerUpgradeButton()
    {
        if (upgradePts > 0)
        {
            bulletDmg += 0.2f;
            upgradePts--;
            PlayerPrefs.SetInt("Upgrade Point", upgradePts);
            PlayerPrefs.SetFloat("bulletDmg", bulletDmg);
        }
    }
}
