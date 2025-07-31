using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenegerUI : MonoBehaviour
{
    public List<GameObject> planets = new List<GameObject>();
    public List<GameObject> panelPlenets = new List<GameObject>();
    public List<GameObject> panels = new List<GameObject>();
    public List<TextMeshProUGUI> orePanels = new List<TextMeshProUGUI>();
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


    public Transform content;
    public Transform contentPlanets;
    Planet planet;
    public GameObject currentPanel;
    public Stats stats;

    public void OreTextPanel(int id)
    {
        orePanels[id].text = stats.FormatGold(stats.ore[id]);
    }

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
            textName.text = planet.namePlanet + "";
            textSpeedCloud.text = planet.speedCloud + "";
            textBank.text = planet.bankNow + "/" + planet.bankMax;
            textCloudShipNow.text = planet.cloudShipNow + "";
            textCloudShipNeed.text = planet.cloudShipNeed + "";
            textCountShip.text = planet.countShip + "";
        }

    }

    public void Colonizetion(int id)
    {
        switch (id)
        {
            case 0: 
                if(stats.ore[0] >= 10)
                {
                    stats.ore[0] -= 10;
                    break;
                }
                else
                {
                    print("не хватает");
                    return;
                }
            case 1:
                if (stats.ore[0] >= 10 && stats.ore[1] >= 10)
                {
                    stats.ore[0] -= 10;
                    stats.ore[1] -= 10;
                    break;
                }
                else
                {
                    print("не хватает");
                    return;
                }
            case 2:
                if (stats.ore[0] >= 10 && stats.ore[1] >= 10 && stats.ore[2] >= 10)
                {
                    stats.ore[0] -= 10;
                    stats.ore[1] -= 10;
                    stats.ore[2] -= 10;
                    break;
                }
                else
                {
                    print("не хватает");
                    return;
                }
            case 3:
                if (stats.ore[0] >= 10 && stats.ore[1] >= 10 && stats.ore[2] >= 10 && stats.ore[3] >= 10)
                {
                    stats.ore[0] -= 10;
                    stats.ore[1] -= 10;
                    stats.ore[2] -= 10;
                    stats.ore[3] -= 10;
                    break;
                }
                else
                {
                    print("не хватает");
                    return;
                }
            case 4:
                if (stats.ore[0] >= 10 && stats.ore[1] >= 10 && stats.ore[2] >= 10 && stats.ore[3] >= 10 && stats.ore[4] >= 10)
                {
                    stats.ore[0] -= 10;
                    stats.ore[1] -= 10;
                    stats.ore[2] -= 10;
                    stats.ore[3] -= 10;
                    stats.ore[4] -= 10;
                    break;
                }
                else
                {
                    print("не хватает");
                    return;
                }
            case 5:
                if (stats.ore[0] >= 10 && stats.ore[1] >= 10 && stats.ore[2] >= 10 && stats.ore[3] >= 10 && stats.ore[4] >= 10 && stats.ore[5] >= 10)
                {
                    stats.ore[0] -= 10;
                    stats.ore[1] -= 10;
                    stats.ore[2] -= 10;
                    stats.ore[3] -= 10;
                    stats.ore[4] -= 10;
                    stats.ore[5] -= 10;
                    break;
                }
                else
                {
                    print("не хватает");
                    return;
                }
            case 6:
                if (stats.ore[0] >= 10 && stats.ore[1] >= 10 && stats.ore[2] >= 10 && stats.ore[3] >= 10 && stats.ore[4] >= 10 && stats.ore[5] >= 10)
                {
                    stats.ore[0] -= 10;
                    stats.ore[1] -= 10;
                    stats.ore[2] -= 10;
                    stats.ore[3] -= 10;
                    stats.ore[4] -= 10;
                    stats.ore[5] -= 10;
                    break;
                }
                else
                {
                    print("не хватает");
                    return;
                }
        }

        OffPanelPlanet();
        content.GetChild(id).GetChild(1).gameObject.SetActive(false);
        content.GetChild(id).GetChild(2).gameObject.SetActive(true);
        content.GetChild(id).GetChild(3).gameObject.SetActive(false);
        content.GetChild(id).GetChild(4).gameObject.SetActive(false);
        content.GetChild(id).GetChild(5).gameObject.SetActive(true);
        contentPlanets.GetChild(id + 2).GetChild(0).gameObject.SetActive(true);

        planets[id].GetComponent<Planet>().isActive = true;
        panelPlenets[id].SetActive(true);
        stats.countBuyPlanet++;
        stats.RePrintBuyPlanet();
        if(id < 6)
        {
            content.GetChild(id + 1).GetChild(1).gameObject.SetActive(true);
            content.GetChild(id + 1).GetChild(4).gameObject.SetActive(true);
        }
    }

    public void OffOn(GameObject button)
    {
        if (button.activeSelf)
        {
            button.SetActive(false);
        }
        else
        {
            button.SetActive(true);
            foreach (GameObject obj in panels)
            {
                obj.SetActive(false);
            }
            panels[0].SetActive(true); 
        }   
        currentPanel = panels[0];

    }

    public void SetPanel(bool up)
    {
        if (up)
        {
            currentPanel.SetActive(false);
            int id = panels.IndexOf(currentPanel) + 1;

            if (panels.Count == id) id = 0;

            panels[id].SetActive(true);
            currentPanel = panels[id];
        }
        else
        {
            currentPanel.SetActive(false);
            int id = panels.IndexOf(currentPanel) - 1;

            if (0 > id) id = panels.Count - 1;

            panels[id].SetActive(true);
            currentPanel = panels[id];
        }
    }
}
