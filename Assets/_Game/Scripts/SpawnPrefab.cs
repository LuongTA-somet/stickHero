using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{

    public GameObject prefab;
    public float radius = 5f;
    public float numberOfLayers = 5f;
    public int numberOfSides = 6;
    private void Start()
    {
        SpawnHexagon();
    }
    void SpawnHexagon()
    {

        for (int layer = 0; layer < numberOfLayers; layer++)
        {

            float currentRadius = (radius / numberOfLayers) * layer;
            int pointsInLayer = layer * 6;


            if (layer == 0)
            {
                Vector3 centerPosition = new Vector3(0, 0, 0);
                GameObject centerPrefab = Instantiate(prefab, centerPosition, Quaternion.identity);
                centerPrefab.transform.SetParent(gameObject.transform, false);
            }
            else
            {
                float angleStep = 360f / pointsInLayer;

                for (int i = 0; i < pointsInLayer; i++)
                {

                    float angle = i * angleStep;
                    float angleRad = Mathf.Deg2Rad * angle;


                    float x = Mathf.Cos(angleRad) * currentRadius;
                    float z = Mathf.Sin(angleRad) * currentRadius;


                    Vector3 spawnPosition = new Vector3(x, 0f, z);


                    GameObject spawnedPrefab = Instantiate(prefab, spawnPosition, Quaternion.identity);
                    spawnedPrefab.transform.SetParent(gameObject.transform, false);
                }
            }
        }
    }

}
