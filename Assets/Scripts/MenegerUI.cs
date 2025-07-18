using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenegerUI : MonoBehaviour
{
    public List<GameObject> planets = new List<GameObject>();
    public CameraController cameraController;
    public GameObject currentPlanet;
    public GameObject panelPlanet;

    public TextMeshProUGUI textSpeedMine;
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textSpeedCloud;
    public TextMeshProUGUI textBank;
    public TextMeshProUGUI textCloudShipNow;
    public TextMeshProUGUI textCloudShipNeed;
    public TextMeshProUGUI textCountShip;

    Planet planet;

    public void ClickPlanet(int id)
    {
        panelPlanet.SetActive(true);
        currentPlanet = planets[id - 1];
        planet = currentPlanet.GetComponent<Planet>();
        cameraController.ClickPlanet(currentPlanet.transform);
    }

    public void OffPanelPlanet()
    {
        planet = null;
        panelPlanet.SetActive(false);
    }

    private void Update()
    {
        if(planet != null)
        {
            textSpeedMine.text = planet.speedMine + "";
            textName.text = planet.name + "";
            textSpeedCloud.text = planet.speedCloud + "";
            textBank.text = planet.bankNow + "/" + planet.bankMax;
            textCloudShipNow.text = planet.cloudShipNow + "";
            textCloudShipNeed.text = planet.cloudShipNeed + "";
            textCountShip.text = planet.countShip + "";
        }

    }
}
