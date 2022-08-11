using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 4.5f;
    private float bulletDmg;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("bulletDmg"))
        {
            bulletDmg = 1;
        }
        else
        {
            Load();
        }
    }
    private void Update()
    {
        transform.position += speed * Time.deltaTime * transform.right;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Load();
        var enemy = collision.collider.GetComponent<Monster>();
        if (enemy)
        {
            enemy.TakeHit(bulletDmg);
        }

        Destroy(gameObject);
        if (collision.collider.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
    private void Load()
    {
        bulletDmg = PlayerPrefs.GetFloat("bulletDmg");
    }

}
