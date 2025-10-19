using System.Collections.Generic;
using UnityEngine;
using YG;

public class SpawnerSpaceShip : MonoBehaviour
{
    public List<GameObject> prefShips = new List<GameObject>();
    public List<Planet> planats = new List<Planet>();
    public float spawnInterval = 1f; // интервал между созданием объектов в секундах
    public Stats stats;
    public int count;
    public GameObject earth;

    public bool isEarth;
    public int idShip;
    public bool testSpawn;
    public Transform panelShips;

    //void Update()
    //{
    //    if (!isEarth) return;
    //    if (!testSpawn) return;
    //    for (int i = 0; i < 7; i++)
    //    {
    //        if (planats[i].isActive && YG2.saves.countBuffs1[i] > YG2.saves.shipFly[i] + YG2.saves.countShip[i])
    //        {
    //            print(YG2.saves.countBuffs1[i]);
    //            timer += Time.deltaTime;

    //            if (timer >= spawnInterval)
    //            {
    //                timer = 0f;
    //                SpawnShip(10, i);
    //                YG2.saves.shipFly[idShip]++;
    //            }
    //        }
    //    }
    //}

    public void SpawnShip(int idPlanet, int idShip)
    {
        GameObject ship = Instantiate(prefShips[idShip], transform.position, Quaternion.identity, panelShips);

        if (idPlanet == 7)
        {
            ship.GetComponent<SpaceShipController>().targetPlanet = earth.transform;
        }
        else
        {
            ship.GetComponent<SpaceShipController>().targetPlanet = planats[idPlanet].transform;
        }
        ship.GetComponent<SpaceShipController>().planetParant = gameObject;
        ship.GetComponent<SpaceShipController>().speed = Parametrs.SpeedShip(idShip);
        ship.GetComponent<SpaceShipController>().stats = stats;
        ship.GetComponent<SpaceShipController>().menegerUI = stats.menegerUI;
        ship.GetComponent<SpaceShipController>().earth = earth;

        Vector3 directionToTarget = ship.GetComponent<SpaceShipController>().targetPlanet.position - ship.transform.position;
        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
        ship.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }


}
