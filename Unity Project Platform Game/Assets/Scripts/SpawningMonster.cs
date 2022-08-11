using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningMonster : MonoBehaviour
{
    public GameObject Obstacle;
    public float minX, maxX, minY, maxY;
    private float timeSpawn;
    public float timeBetweenSpawn;



    // Update is called once per frame
    void Update()
    {
     if(Time.time > timeSpawn && Obstacle != null)
        {
            Spawn();
            timeSpawn = Time.time + timeBetweenSpawn;
        }   
    }
    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(Obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
