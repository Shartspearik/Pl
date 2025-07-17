using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OrbitDrawer : MonoBehaviour
{
    public List<Transform> planets = new List<Transform>();
    private float radius;        // радиус круга
    private int pointsCount;      // число точек
    public GameObject pointPrefab;     // префаб точки (например, маленькая сфера)
    public float pointSize = 0.2f;     // размер точек
    public Transform cashOrbit;

    void Start()
    {
        foreach (Transform planet in planets)
        {
            radius = planet.GetComponent<Planet>().orbitRadius;
            pointsCount = (int)(17 * radius);
            for (int i = 0; i < pointsCount; i++)
            {
                float angle = (i / (float)pointsCount) * 2 * Mathf.PI;
                float x = Mathf.Cos(angle) * radius;
                float y = Mathf.Sin(angle) * radius;

                Vector3 position = transform.position + new Vector3(x, y, 0);
                GameObject point = Instantiate(pointPrefab, position, Quaternion.identity, cashOrbit);
                point.transform.localScale = Vector3.one * pointSize;
            }
        }
    }
}