using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    public GameObject targetObject;

    void Update()
    {
        if (targetObject != null)
        {
            if (targetObject.transform.position.y > 0.8)
            {
                float targetObjectY = targetObject.transform.position.y;
                Vector3 newCameraPosition = transform.position;
                newCameraPosition.y = targetObjectY;
                transform.position = newCameraPosition;

            }
            else
            {
                Vector3 newCameraPosition = transform.position;
                newCameraPosition.y = 0.8f;
                transform.position = newCameraPosition;
            }
        }
        //if(targetObject != null)
        //{
        //    transform.position = new Vector3(transform.position.x, targetObject.transform.position.y, transform.position.z);
        //}
    }
}
