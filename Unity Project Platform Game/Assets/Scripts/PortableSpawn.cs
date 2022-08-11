using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortableSpawn : MonoBehaviour
{
    public BossBatBehavior bossObject;
    public GameObject portable;
    private bool isSpawn = false;


    void Update()
    {
        if (bossObject.isBossDie && !isSpawn)
        {
            Instantiate(portable, transform.position, transform.rotation);
            isSpawn = true;
        }
    }
}
