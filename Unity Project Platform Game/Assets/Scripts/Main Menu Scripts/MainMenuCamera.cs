using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{

    public float smoothing;
    private Vector2 maxPosition;
    private Vector2 minPosition;

    private void Start()
    {
        Time.timeScale = 1f;
    }


    void LateUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Vector3 characterPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            if (transform.position != characterPosition)
            {
                cameraBound(characterPosition);
                characterPosition.z = transform.position.z;
                characterPosition.x = Mathf.Clamp(characterPosition.x, minPosition.x, maxPosition.x);
                characterPosition.y = Mathf.Clamp(characterPosition.y, minPosition.y, maxPosition.y);
                transform.position = Vector3.Lerp(transform.position, characterPosition, smoothing);
                
            }
        }
    }

    void cameraBound(Vector3 characterPosition)
    {
        if(characterPosition.y < 21)
        {
            maxPosition = new Vector2(6.56f, 100f);
            minPosition = new Vector2(-1f, -4.53f);
        }
        if (characterPosition.y > 21)
        {
            maxPosition = new Vector2(16.67f, 46.96f);
            minPosition = new Vector2(-2f, -4.53f);
        }
    }

}
