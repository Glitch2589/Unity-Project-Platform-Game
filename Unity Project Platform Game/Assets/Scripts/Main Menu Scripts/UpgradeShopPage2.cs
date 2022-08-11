using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeShopPage2 : MonoBehaviour
{
    public TextMeshProUGUI jumpBoostPrice;
    public TextMeshProUGUI jumpBoost1Price;

    private int jumpBoost, jumpBoost2, playerCoin;
    void Update()
    {
        playerCoin = PlayerPrefs.GetInt("Coin Number");
        jumpBoost = PlayerPrefs.GetInt("JumpBoost");
        jumpBoost2 = PlayerPrefs.GetInt("JumpBoost2");
        if (jumpBoost != 0)
        {
            jumpBoostPrice.text = "Bought";
        }
        if(jumpBoost2 != 0)
        {
            jumpBoost1Price.text = "Bought";
        }
    }

    public void BuyExp()
    {
        if(playerCoin > 20)
        {
            float exp = PlayerPrefs.GetFloat("Character Exp.");
            exp += 5;
            PlayerPrefs.SetFloat("Character Exp.",exp);
            playerCoin -= 20;
            PlayerPrefs.SetInt("Coin Number", playerCoin);
        }
        else
        {
            Debug.LogError("not enough coin. coin number = " + playerCoin);
        }
    }

    public void BuyJumpBoost()
    {
        jumpBoost = PlayerPrefs.GetInt("JumpBoost");
        if (playerCoin > 2000 && jumpBoost == 0)
        {
            jumpBoost = 1;
            PlayerPrefs.SetInt("JumpBoost", jumpBoost);
            playerCoin -= 2000;
            PlayerPrefs.SetInt("Coin Number", playerCoin);
        }
        else
        {
            Debug.LogError("not enough coin or bought. coin number = " + playerCoin +" jb = "+ jumpBoost);
        }
    }

    public void BuyJumpBoost2()
    {
        jumpBoost2 = PlayerPrefs.GetInt("JumpBoost2");
        if (playerCoin > 10000 && jumpBoost2 == 0)
        {
            jumpBoost2 = 1;
            PlayerPrefs.SetInt("JumpBoost2", jumpBoost2);
            playerCoin -= 10000;
            PlayerPrefs.SetInt("Coin Number", playerCoin);
        }
        else
        {
            Debug.LogError("not enough coin or bought. coin number = " + playerCoin + " jb = " + jumpBoost2);
        }
    }
}
