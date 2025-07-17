using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenegerUI : MonoBehaviour
{
    public List<GameObject> planets = new List<GameObject>();
    public CameraController cameraController;
    private GameObject currentPlanet;

    public void ClickPlanet(int id)
    {
        currentPlanet = planets[id - 1];
        cameraController.ClickPlanet(currentPlanet.transform);
    }
}
