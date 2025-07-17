using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpaceShip : MonoBehaviour
{
    public GameObject prefShip;
    public List<GameObject> planats = new List<GameObject>();
    public float spawnInterval = 1f; // интервал между созданием объектов в секундах

    private float timer = 0f;
    public int count;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            if (count == 2)
            {
                count++;
                return;
            }
            SpawnShip(count);
            count++;
            if(count >= 8)
            {
                count = 0;
            }
        }
    }
    
    public void SpawnShip(int id)
    {
        GameObject ship = Instantiate(prefShip, transform.position, Quaternion.identity);
        ship.GetComponent<SpaceShipController>().targetPlanet = planats[id].transform;
        ship.GetComponent<SpaceShipController>().planetParant = gameObject;
    }
}
