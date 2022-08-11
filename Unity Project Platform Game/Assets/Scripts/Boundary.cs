using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    public GameObject boundaryObjects;

    void LateUpdate()
    {
        if(this.gameObject.transform.position.x >= boundaryObjects.transform.position.x)
        {
            Vector3 newCharacterPosition = this.gameObject.transform.position;
            newCharacterPosition.x = boundaryObjects.transform.position.x;
            this.gameObject.transform.position = newCharacterPosition;
        }
    }
}
