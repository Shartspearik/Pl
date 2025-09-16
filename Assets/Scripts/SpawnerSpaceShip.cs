using System.Collections.Generic;
using UnityEngine;
using YG;

public class SpawnerSpaceShip : MonoBehaviour
{
    public List<GameObject> prefShips = new List<GameObject>();
    public List<GameObject> planats = new List<GameObject>();
    public float spawnInterval = 1f; // интервал между созданием объектов в секундах
    public Stats stats;
    private float timer = 0f;
    public int count;
    public GameObject earth;

    public bool testSpawn;

    void Update()
    {
        if (!testSpawn) return;
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnShip(count, count);
            count++;
            if (count >= 7)
            {
                count = 0;
            }
        }
    }

    public void SpawnShip(int idPlanet, int idShip)
    {
        GameObject ship = Instantiate(prefShips[idShip], transform.position, Quaternion.identity);

        if (idPlanet == 10)
        {
            ship.GetComponent<SpaceShipController>().targetPlanet = earth.transform;
        }
        else
        {
            ship.GetComponent<SpaceShipController>().targetPlanet = planats[idPlanet].transform;
        }
        ship.GetComponent<SpaceShipController>().planetParant = gameObject;
        ship.GetComponent<SpaceShipController>().speed = YG2.saves.shipSpeed[idShip];
        ship.GetComponent<SpaceShipController>().stats = stats;
        ship.GetComponent<SpaceShipController>().earth = earth;
    }


}
