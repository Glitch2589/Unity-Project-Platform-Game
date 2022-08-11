using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUpgradeShop : MonoBehaviour
{
    public GameObject menuShop;

    private void Start()
    {
        menuShop.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        menuShop.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        menuShop.SetActive(false);
    }
        
}
