using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatePosition: MonoBehaviour
{
    public CameraFollow cameraFollow;
    private float timeSpawn;
    public float timeBetweenSpawn = 10f;
    private Vector3 currentPos;


    void Update()
    {
        currentPos += new Vector3(cameraFollow.getCameraSpeed() * Time.deltaTime, 0, 0);
        if (Time.time > timeSpawn)
        {
            transform.position += currentPos;
            currentPos.x = 0;
            timeSpawn += timeBetweenSpawn;
        }

    }

}
