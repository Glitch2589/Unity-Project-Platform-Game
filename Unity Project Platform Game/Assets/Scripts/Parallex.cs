using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallex : MonoBehaviour
{
    [SerializeField] private Vector2 parallexEffectMultiplier;
    [SerializeField] private bool infiniteHorizontal, infiniteVertical;


    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;
    private float textureUnitSizeY;

    private Vector2 startPosition;
    private float startCameraPositionY;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = (texture.width / sprite.pixelsPerUnit) * transform.localScale.x;
        textureUnitSizeY = (texture.width / sprite.pixelsPerUnit) * transform.localScale.y;
        startPosition = transform.position;
        startCameraPositionY = 1.0f;
    }

    void FixedUpdate()
    {
        Vector3 deltamovement = cameraTransform.position - lastCameraPosition;
        transform.position -= new Vector3(deltamovement.x * parallexEffectMultiplier.x, deltamovement.y * parallexEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;
        if (cameraTransform.position.x - transform.position.x >= textureUnitSizeX)
        {
            float offsetPositionX = (Mathf.Abs(cameraTransform.position.x - transform.position.x) % textureUnitSizeX);
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
            
        }

        if (cameraTransform.position.y - transform.position.y >= textureUnitSizeY)
        {
            float offsetpositiony = (Mathf.Abs(cameraTransform.position.y - transform.position.y) % textureUnitSizeY);
            transform.position = new Vector3(transform.position.x + offsetpositiony, cameraTransform.position.y);
        }

        if (Camera.main.transform.position.y < startCameraPositionY)
        {
            transform.position = new Vector3(transform.position.x, startPosition.y);
        }
    }
}
