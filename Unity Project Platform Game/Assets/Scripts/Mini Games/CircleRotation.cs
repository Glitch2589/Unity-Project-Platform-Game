using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class CircleRotation : MonoBehaviour
{
    public float rotateSpeed;
    private int index;
    private void Start()
    {
        index = Random.Range(0, 2);
        switch (index)
        {
            case 0:
                rotateSpeed = 100f;
                break;
            case 1:
                rotateSpeed = -100f;
                break;
        }
    }
    void Update()
    {
        
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }
}
