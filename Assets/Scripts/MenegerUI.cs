using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class MenegerUI : MonoBehaviour
{
    public List<GameObject> planets = new List<GameObject>();
    
    public List<TextMeshProUGUI> orePanels = new List<TextMeshProUGUI>();

    //Кнопки покупки планет
    public List<GameObject> panelBuyPlanet = new List<GameObject>();
    public GameObject[] spins;
    public Sprite[] iconPlanet;

    //Кнопки выбора планет
    public List<GameObject> buttonPlanets = new List<GameObject>();

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

    public bool isPanel;
    public PanelBuff panelBuff;

    private void Start()
    {
        for (int i = 0; i < orePanels.Count; i++)
        {
            OreTextPanel(i);
        }
        RePrint();
    }

    public void RePrint()
    {
        for (int i = 0; i < YG2.saves.countBuyPlanet - 1; i++)
        {
            if (i != 6)
            {
                panelBuyPlanet[i].GetComponent<Button>().interactable = false;
                spins[i].SetActive(false);
                panelBuyPlanet[i].GetComponent<Image>().sprite = iconPlanet[i];
                spins[i + 1].SetActive(true);
                panelBuyPlanet[i + 1].GetComponent<Button>().interactable = true;
            }
            else
            {
                panelBuyPlanet[i].GetComponent<Button>().interactable = false;
                spins[i].SetActive(false);
                panelBuyPlanet[i].GetComponent<Image>().sprite = iconPlanet[i];
            }
            planets[i].transform.GetChild(0).gameObject.SetActive(true);
            planets[i].GetComponent<Planet>().isActive = true;
            buttonPlanets[i].SetActive(true);
        }   
    }

    public void OreTextPanel(int id)
    {
        orePanels[id].text = stats.FormatGold(YG2.saves.countOre[id]);
    }

    public void ClickPlanet(int id)
    {
        if (isPanel)
        {
            panelBuff.SetPanel(id);
        }
        else
        {
            //panelPlanet.SetActive(true);
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
    }

    public void OffPanelPlanet()
    {
        planet = null;
        //panelPlanet.SetActive(false);
    }

    private void Update()
    {
        //if (planet != null)
        //{
        //    textSpeedMine.text = planet.speedMine + "";
        //    textName.text = planet.namePlanet + "";
        //    textSpeedCloud.text = planet.speedCloud + "";
        //    textBank.text = planet.bankNow + "/" + planet.bankMax;
        //    textCloudShipNow.text = planet.cloudShipNow + "";
        //    textCloudShipNeed.text = planet.cloudShipNeed + "";
        //    textCountShip.text = planet.countShip + "";
        //}

    }

    public void Colonizetion(int id)
    {
        switch (id)
        {
            case 1:
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
            case 2:
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
            case 3:
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
            case 4:
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
            case 5:
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
            case 6:
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
            case 7:
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
        YG2.saves.countBuyPlanet++;

        //Обработка кнопок покупок планет
        if (id != 7)
        {
            spins[id].SetActive(true);
            panelBuyPlanet[id].GetComponent<Button>().interactable = true;
        }
        panelBuyPlanet[id - 1].GetComponent<Button>().interactable = false;
        spins[id - 1].SetActive(false);
        panelBuyPlanet[id - 1].GetComponent<Image>().sprite = iconPlanet[id - 1];

        //Обработка планет на орбите
        planets[id - 1].transform.GetChild(0).gameObject.SetActive(true);
        planets[id - 1].GetComponent<Planet>().isActive = true;

        //Обработка кнопок планет
        buttonPlanets[id - 1].SetActive(true);

        //ResetButtonBuff();

        YG2.SaveProgress();
    }

    public void ResetButtonBuff()
    {
        //for (int i = 0; i < YG2.saves.countBuyPlanet; i++)
        //{

        //}
    }


    
}
