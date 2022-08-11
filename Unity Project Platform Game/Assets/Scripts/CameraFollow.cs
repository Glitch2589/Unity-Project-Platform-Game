using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public static float cameraSpeed = 5;
    public float maxCameraSpeed = 10;
    public float speedMultiple = 0.001f;

    private void Start()
    {
        cameraSpeed = 5;
    }
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            cameraSpeed = 0;
            Time.timeScale = 0f;
        }


        if (cameraSpeed < maxCameraSpeed && Time.timeScale != 0)
        {
            cameraSpeed += speedMultiple;
        }
        transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
    }   

    public float getCameraSpeed()
    {
        return cameraSpeed;
    }
}
