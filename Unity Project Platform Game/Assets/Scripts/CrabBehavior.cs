using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabBehavior : MonoBehaviour
{
    Rigidbody2D _rigidbody2d;
    public Animator animator;
    public float jumpForce = 5;
    private float triggerTime;
    [SerializeField] public float jumpCooldown = 2f;
    void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        triggerTime = Time.time + jumpCooldown;
    }

    void Update()
    {
        if (Time.time > triggerTime)
        {
            Attack();
            _rigidbody2d.velocity = Vector3.up * jumpForce;
            triggerTime += jumpCooldown;
        }
        
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
