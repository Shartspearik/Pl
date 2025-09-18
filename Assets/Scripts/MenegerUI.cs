using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

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
    public Transform contentBuff;
    public Transform contentPlanets;
    Planet planet;
    public GameObject currentPanel;
    public Stats stats;
    public GameObject earth;

    private void Start()
    {
        for (int i = 0; i < orePanels.Count; i++)
        {
            OreTextPanel(i);
        }
    }

    public void OreTextPanel(int id)
    {
        orePanels[id].text = stats.FormatGold(YG2.saves.countOre[id]);
    }

    public void ClickPlanet(int id)
    {
        panelPlanet.SetActive(true);
        if (id == 10)
        {
            currentPlanet = earth;
        }
        else
        {
            currentPlanet = planets[id];
        }
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
        if (planet != null)
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
                if (YG2.saves.countOre[0] >= 10)
                {
                    YG2.saves.countOre[0] -= 10;
                    break;
                }
                else
                {
                    print("не хватает");
                    return;
                }
            case 1:
                if (YG2.saves.countOre[0] >= 10 && YG2.saves.countOre[1] >= 10)
                {
                    YG2.saves.countOre[0] -= 10;
                    YG2.saves.countOre[1] -= 10;
                    break;
                }
                else
                {
                    print("не хватает");
                    return;
                }
            case 2:
                if (YG2.saves.countOre[0] >= 10 && YG2.saves.countOre[1] >= 10 && YG2.saves.countOre[2] >= 10)
                {
                    YG2.saves.countOre[0] -= 10;
                    YG2.saves.countOre[1] -= 10;
                    YG2.saves.countOre[2] -= 10;
                    break;
                }
                else
                {
                    print("не хватает");
                    return;
                }
            case 3:
                if (YG2.saves.countOre[0] >= 10 && YG2.saves.countOre[1] >= 10 && YG2.saves.countOre[2] >= 10 && YG2.saves.countOre[3] >= 10)
                {
                    YG2.saves.countOre[0] -= 10;
                    YG2.saves.countOre[1] -= 10;
                    YG2.saves.countOre[2] -= 10;
                    YG2.saves.countOre[3] -= 10;
                    break;
                }
                else
                {
                    print("не хватает");
                    return;
                }
            case 4:
                if (YG2.saves.countOre[0] >= 10 && YG2.saves.countOre[1] >= 10 && YG2.saves.countOre[2] >= 10 && YG2.saves.countOre[3] >= 10 && YG2.saves.countOre[4] >= 10)
                {
                    YG2.saves.countOre[0] -= 10;
                    YG2.saves.countOre[1] -= 10;
                    YG2.saves.countOre[2] -= 10;
                    YG2.saves.countOre[3] -= 10;
                    YG2.saves.countOre[4] -= 10;
                    break;
                }
                else
                {
                    print("не хватает");
                    return;
                }
            case 5:
                if (YG2.saves.countOre[0] >= 10 && YG2.saves.countOre[1] >= 10 && YG2.saves.countOre[2] >= 10 && YG2.saves.countOre[3] >= 10 && YG2.saves.countOre[4] >= 10 && YG2.saves.countOre[5] >= 10)
                {
                    YG2.saves.countOre[0] -= 10;
                    YG2.saves.countOre[1] -= 10;
                    YG2.saves.countOre[2] -= 10;
                    YG2.saves.countOre[3] -= 10;
                    YG2.saves.countOre[4] -= 10;
                    YG2.saves.countOre[5] -= 10;
                    break;
                }
                else
                {
                    print("не хватает");
                    return;
                }
            case 6:
                if (YG2.saves.countOre[6] >= 10 && YG2.saves.countOre[1] >= 10 && YG2.saves.countOre[2] >= 10 && YG2.saves.countOre[3] >= 10 && YG2.saves.countOre[4] >= 10 && YG2.saves.countOre[5] >= 10)
                {
                    YG2.saves.countOre[6] -= 10;
                    YG2.saves.countOre[1] -= 10;
                    YG2.saves.countOre[2] -= 10;
                    YG2.saves.countOre[3] -= 10;
                    YG2.saves.countOre[4] -= 10;
                    YG2.saves.countOre[5] -= 10;
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

        OpenPanel(id + 1);

        planets[id].GetComponent<Planet>().isActive = true;
        panelPlenets[id].SetActive(true);
        YG2.saves.countBuyPlanet++;

        for (int i = 0; i < orePanels.Count; i++)
        {
            OreTextPanel(i);
        }
        
    }

    public void OpenPanel(int id)
    {
        contentBuff.GetChild(id).GetChild(2).gameObject.SetActive(true);
        contentBuff.GetChild(id).GetChild(3).gameObject.SetActive(true);
        contentBuff.GetChild(id).GetChild(4).gameObject.SetActive(true);

        do
        {
            contentBuff.GetChild(id - 1).GetChild(2).GetChild(3).gameObject.SetActive(true);
            contentBuff.GetChild(id - 1).GetChild(2).GetChild(4).gameObject.SetActive(true);
            contentBuff.GetChild(id - 1).GetChild(2).GetChild(6).gameObject.SetActive(false);

            contentBuff.GetChild(id - 1).GetChild(3).GetChild(3).gameObject.SetActive(true);
            contentBuff.GetChild(id - 1).GetChild(3).GetChild(4).gameObject.SetActive(true);
            contentBuff.GetChild(id - 1).GetChild(3).GetChild(6).gameObject.SetActive(false);

            contentBuff.GetChild(id - 1).GetChild(4).GetChild(3).gameObject.SetActive(true);
            contentBuff.GetChild(id - 1).GetChild(4).GetChild(4).gameObject.SetActive(true);
            contentBuff.GetChild(id - 1).GetChild(4).GetChild(6).gameObject.SetActive(false);
            id--;
        } while (id > 0);

        YG2.SaveProgress();
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
        for (int i = 1; i < 8; i++)
        {
            for (int q = 1; q < 4; q++)
            {
                stats.ResetPrice(i * 10 + q);
            }
        }
    }
}
