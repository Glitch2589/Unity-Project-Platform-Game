using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseShopUI_non : MonoBehaviour
{
    public void RemoveAds()
    {
        //non-consumable item
    }

    public void Pack1()
    {
        int coin = PlayerPrefs.GetInt("Coin Number");
        coin += 60;
        PlayerPrefs.SetInt("Coin Number", coin);
    }
    public void Pack2()
    {
        int coin = PlayerPrefs.GetInt("Coin Number");
        coin += 500;
        PlayerPrefs.SetInt("Coin Number", coin);
    }
    public void Pack3()
    {
        int coin = PlayerPrefs.GetInt("Coin Number");
        coin += 980;
        PlayerPrefs.SetInt("Coin Number", coin);
    }
    public void Pack4()
    {
        int coin = PlayerPrefs.GetInt("Coin Number");
        coin += 1980;
        PlayerPrefs.SetInt("Coin Number", coin);
    }
    public void Pack5()
    {
        int coin = PlayerPrefs.GetInt("Coin Number");
        coin += 6000;
        PlayerPrefs.SetInt("Coin Number", coin);
    }

}
