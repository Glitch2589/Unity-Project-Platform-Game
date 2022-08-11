using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackround : MonoBehaviour
{
    public float backgroundSpeed;
    public Renderer backgroundRenderer;
    public GameObject cameraObject;
    private float backgroundOffset = 1f;
    void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime,0);
        transform.position = new Vector3(cameraObject.transform.position.x, cameraObject.transform.position.y + backgroundOffset, transform.position.z);
    }
}
