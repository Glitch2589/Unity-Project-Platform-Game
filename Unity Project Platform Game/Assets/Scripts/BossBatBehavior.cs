using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBatBehavior : MonoBehaviour
{
    public bool isBossDie = false;
    private float movementSpeed = 0.5f;
    private float triggerTime;
    [SerializeField]public float attackCooldown = 5f;
    public Animator animator;
    public Monster monster;
    public GameObject attackBullet;
    public Transform bulletOffSet;

    public void Start()
    {
        triggerTime = Time.time + attackCooldown;
    }
    void Update()
    {
        
        if (Time.time > triggerTime)
        {
            Attack();
            Instantiate(attackBullet, bulletOffSet.transform.position, transform.rotation);
            triggerTime += attackCooldown;
        }

        if (monster.hitpoints <= 0)
        {
            isBossDie = true;
            Die();
        }

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            transform.position += new Vector3(CameraFollow.cameraSpeed * Time.deltaTime, GetPositionY(transform.position.y, GameObject.FindGameObjectWithTag("Player").transform.position.y) * Time.deltaTime, 0);
        }
        if(transform.position.y <= -1.5)
        {
            transform.position = new Vector3(transform.position.x, -1.3f, 0);
        }

    }
    float GetPositionY(float currentY, float desiredY)
    {
        if (currentY < desiredY)
        {
            return movementSpeed;
        }
        if (currentY > desiredY)
        {
            return -movementSpeed;
        }
       
        return 0;
    }
    void Attack()
    {
        animator.SetBool("Hit", true);
    }
    void NormalAttack()
    {

    }
    void Die()
    {
        animator.SetBool("Death", true);
    }
}
