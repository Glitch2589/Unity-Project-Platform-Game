using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColorToPrefab
{
    public GameObject prefab;
    public Color color;
}
public class Coin : MonoBehaviour
{
    public Texture2D coinMap;
    public ColorToPrefab[] colortoPrefab;
    public GameObject parentObject;
    private float timeSpawn;
    public float timeBetweenSpawn = 10f;
    public CameraFollow cameraFollow;


    void Update()
    {
        if (Time.time > timeSpawn)
        {
            GenerateMap();
            timeSpawn += timeBetweenSpawn;
        }
        
    }

    void GenerateMap()
    {
        for(int x = 0; x < coinMap.width; x++)
        {
            for(int y = 0; y <coinMap.height; y++)
            {
                GenerateCoin(x, y);
            }
        }
    }

    void GenerateCoin(int x, int y)
    {
        Color mapColor = coinMap.GetPixel(x, y);
        foreach(ColorToPrefab obj in colortoPrefab)
        {
            if (obj.color.Equals(mapColor))
            {
                Vector3 parentPos = parentObject.transform.position;
                Vector2 pos = new Vector2(x+ parentPos.x, y+ parentPos.y);
                Instantiate(obj.prefab, pos, Quaternion.identity, parentObject.transform);

            }
        }
    }
}
