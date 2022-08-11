using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public float bossSpawnScore = 50;

    private bool isSpawn = false;
    private float tempScore;

    public GameObject bossObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempScore = PlayerPrefs.GetFloat("TempScore");
        if (tempScore >= bossSpawnScore && !isSpawn)
        {
            Instantiate(bossObject, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            isSpawn = true;
        }
    }
}
