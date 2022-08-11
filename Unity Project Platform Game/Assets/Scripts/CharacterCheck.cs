using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCheck : MonoBehaviour
{
    //public GameObject groundObject;
    void Update()
    {
        
    }
    public bool isGrounded() 
    {   
        if(this.gameObject.transform.position.y > -1.66)
        {
            return false;
        }
        return true;
    }
}
