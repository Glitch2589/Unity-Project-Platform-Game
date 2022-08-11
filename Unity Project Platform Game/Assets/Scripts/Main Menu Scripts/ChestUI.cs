using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChestUI : MonoBehaviour
{

    public GameObject chestInfo;
    public Text bulletSpeedText;
    public Text bulletDmgText;
    public Animator animator;

    private void Update()
    {
        float bulletLoadSpeed = PlayerPrefs.GetFloat("Bullet Load Speed");
        float bulletDmg = PlayerPrefs.GetFloat("bulletDmg");
        bulletSpeedText.text = "Attack Speed: " + bulletLoadSpeed.ToString();
        bulletDmgText.text = "Attack Damage: " + bulletDmg.ToString();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        chestInfo.SetActive(true);
        animator.SetBool("ChestOpen", true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        chestInfo.SetActive(false);
        animator.SetBool("ChestOpen", false);
    }
    
}
