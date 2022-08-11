using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    private GameObject character;
    public float hitpoints;
    public float maxHitpoints;
    public HealthBarBehavior healthBar;
    public int monsterExp;
    public Animator animator;
    private float deathTimer;
    public Collider2D cld2D;

    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
        hitpoints = maxHitpoints;
        healthBar.SetHealth(hitpoints, maxHitpoints);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Border"))
        {
            Destroy(gameObject);
            Destroy(transform.parent.gameObject);
        }
        else if(collision.collider.CompareTag("Player"))
        {
            Debug.Log("Player Died by touching Monster");
            Destroy(character);
        }

    }
    private void Update()
    {
        if (hitpoints <= 0)
        {
            cld2D.isTrigger = true; 
            animator.SetBool("Death", true);
            deathTimer += Time.deltaTime;
            if (deathTimer > 0.9f)
                Die();
        }
    }

    public void TakeHit(float damage)
    {
        hitpoints -= damage;
        healthBar.SetHealth(hitpoints, maxHitpoints);
    }
    private void Die()
    {
        float currentexp = PlayerPrefs.GetFloat("Character Exp.");
        currentexp += monsterExp;
        PlayerPrefs.SetFloat("Character Exp.", currentexp);
        Destroy(gameObject);
        Destroy(transform.parent.gameObject);
    }

}
