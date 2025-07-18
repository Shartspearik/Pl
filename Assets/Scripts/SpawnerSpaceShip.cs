using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpaceShip : MonoBehaviour
{
    public List<GameObject> prefShips = new List<GameObject>();
    public List<GameObject> planats = new List<GameObject>();
    public float spawnInterval = 1f; // интервал между созданием объектов в секундах

    private float timer = 0f;
    public int count;

    public bool testSpawn;

    void Update()
    {
        if (!testSpawn) return;
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            if (count == 2)
            {
                count++;
                return;
            }
            SpawnShip(count, count);
            count++;
            if(count >= 8)
            {
                count = 0;
            }
        }
    }
    
    public void SpawnShip(int idPlanet, int idShip)
    {
        GameObject ship = Instantiate(prefShips[idShip], transform.position, Quaternion.identity);
        ship.GetComponent<SpaceShipController>().targetPlanet = planats[idPlanet].transform;
        ship.GetComponent<SpaceShipController>().planetParant = gameObject;
    }
}
