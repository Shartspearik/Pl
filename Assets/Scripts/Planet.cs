using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public GameObject prefNumber;
    public int castValue;
    public Transform sun;
    public float orbitalSpeed;
    public float speedPlanet;
    public float scaleSpeed = 0.5f;

    public bool isCurrent;
    public float orbitRadius; // радиус орбиты, известен заранее
    public float radius;
    public bool isSun;

    void Start()
    {
        if (isSun) return;
        PlacePlanetOnOrbit();
    }

    void PlacePlanetOnOrbit()
    {
        // Выбираем случайный угол
        float angle = Random.Range(0f, 2 * Mathf.PI);

        // Вычисляем позицию по полярным координатам
        float x = Mathf.Cos(angle) * orbitRadius;
        float y = Mathf.Sin(angle) * orbitRadius;

        // Устанавливаем позицию планеты
        transform.position = new Vector3(x, y, transform.position.z);
    }

    void Update()
    {
        if (isSun) return;
        transform.RotateAround(sun.position, Vector3.forward, orbitalSpeed * Time.deltaTime * scaleSpeed * speedPlanet);
    }

    private void OnMouseDown()
    {
        if (isSun) return;
        if (isCurrent) ShowFloatingNumber();
    }

    public void IsCurrent()
    {
        isCurrent = !isCurrent;
    }

    void ShowFloatingNumber()
    {
        Vector3 spawnPosition = transform.position + Vector3.up * 1.0f;
        GameObject floatingNumberObj = Instantiate(prefNumber, spawnPosition, Quaternion.identity);
        floatingNumberObj.GetComponent<FloatingNumber>().Initialize(castValue);
    }
}
