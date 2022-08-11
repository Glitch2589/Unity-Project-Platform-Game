using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    private int playerCoin;
    public TextMeshProUGUI textCoin;

    void Update()
    {
        playerCoin = PlayerPrefs.GetInt("Coin Number");
        textCoin.text = playerCoin.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coinx1"))
        {
            Destroy(collision.gameObject);
            playerCoin++;
            PlayerPrefs.SetInt("Coin Number", playerCoin);
        }

    }


}
