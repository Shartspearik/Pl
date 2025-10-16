using System.Collections.Generic;
using UnityEngine;

public class OrbitDrawer : MonoBehaviour
{
    public List<Transform> planets = new List<Transform>();
    private float radius;        // радиус круга
    private int pointsCount;      // число точек
    public GameObject pointPrefab;     // префаб точки (например, маленька€ сфера)
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

                // Ќаправление к центру
                Vector2 directionToCenter = (transform.position - position).normalized;

                // ”гол в градусах между направлением к центру и осью X
                float angleDegrees = Mathf.Atan2(directionToCenter.y, directionToCenter.x) * Mathf.Rad2Deg;

                // ѕоворот точки так, чтобы "смотреть" на центр, вращение вокруг оси Z
                Quaternion rotation = Quaternion.Euler(0, 0, angleDegrees + 90);

                GameObject point = Instantiate(pointPrefab, position, rotation, cashOrbit);
                point.transform.localScale = Vector3.one * pointSize;
            }
        }
    }
}