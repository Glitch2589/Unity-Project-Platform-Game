using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawn : MonoBehaviour
{
    public GameObject ground;
    bool hasGround = true;

    void Update()
    {
        if(!hasGround)
        {
            Instantiate(ground, new Vector3(transform.position.x, -3, 0), Quaternion.identity);
            hasGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasGround = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasGround = false;
        }
    }

}
