using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBatBullet : MonoBehaviour
{
    public float bulletSpeed = 2.5f;

    void Update()
    {
        transform.position -= bulletSpeed * Time.deltaTime * transform.right;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
        if (collision.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
}
