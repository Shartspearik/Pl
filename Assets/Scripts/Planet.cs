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
    public Stats stats;

    public int speedMine;
    public int speedCloud;
    public int bankNow;
    public int mine;
    public int cloud;
    public int bankMax;
    public int countShip;
    public int cloudShipNow;
    public int cloudShipNeed;
    public string namePlanet;

    public bool isCurrent;
    public float orbitRadius; // радиус орбиты, известен заранее
    public float radius;
    public bool isSun;
    public int idPlanet;
    public bool isActive;

    private SpawnerSpaceShip spawnerSpaceShip;
    private float timerMine;
    private float timerCloud;

    void Start()
    {
        spawnerSpaceShip = GetComponent<SpawnerSpaceShip>();
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
        if (isActive)
        {
            if (bankNow != bankMax)           //майнинг
            {
                timerMine += Time.deltaTime;

                if (timerMine >= speedMine)
                {
                    timerMine = 0f;
                    if (idPlanet == 0)
                    {
                        stats.SetCloud(0);
                    }
                    else
                    {
                        bankNow += mine;
                        if (bankNow >= bankMax)
                        {
                            bankNow = bankMax;
                        }
                    }
                }
            }
            if (countShip != 0)
            {
                timerCloud += Time.deltaTime;

                if (timerCloud >= speedCloud)
                {
                    timerCloud = 0f;
                    cloudShipNow += cloud;
                    if (cloudShipNow >= cloudShipNeed)
                    {
                        cloudShipNow = 0;
                        countShip--;
                        spawnerSpaceShip.SpawnShip(10, idPlanet);
                    }
                }
            }
        }

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

    public void FinishShip()
    {
        countShip++;
    }

    //public void ComeHomeShip()
    //{
    //    countShip--;
    //    spawnerSpaceShip.SpawnShip(2, idPlanet);
    //}
}
