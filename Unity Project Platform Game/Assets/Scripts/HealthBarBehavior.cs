using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehavior : MonoBehaviour
{
    public Image healthSlider;
    public Image bgHealth;

    public void SetHealth(float health, float maxHealth)
    {
        bgHealth.gameObject.SetActive(health < maxHealth);
        healthSlider.gameObject.SetActive(health < maxHealth);
        healthSlider.fillAmount = health / maxHealth;
    }


}
