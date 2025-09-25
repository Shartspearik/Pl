using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;
using YG.Insides;


namespace YG
{
    public partial class SavesYG
    {
        public int nowShip = 0;
        public int countBuyPlanet = 1;
        public int countReadyPlanet;

        [Header("Параметры")]
        public List<int> shipCloudMax = new List<int>() { 20, 20, 20, 20, 20, 20, 20, 20 };
        public List<int> shipCount = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1 };
        public List<int> shipBankMax = new List<int>() { 20, 20, 20, 20, 20, 20, 20 };
        public List<int> shipSpeed = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1 };

        public List<UpgradeNode> nodes1 = new List<UpgradeNode>
{
    new UpgradeNode { id = 1, requirements = new List<int>(), unlocked = true, upgraded = false },
    new UpgradeNode { id = 2, requirements = new List<int>{1}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 3, requirements = new List<int>{1}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 4, requirements = new List<int>{2}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 5, requirements = new List<int>{2,3}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 6, requirements = new List<int>{3}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 7, requirements = new List<int>{4,5,6}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 8, requirements = new List<int>{7}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 9, requirements = new List<int>{7}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 10, requirements = new List<int>{7}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 11, requirements = new List<int>{8,9}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 12, requirements = new List<int>{9,10}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 13, requirements = new List<int>{11,12}, unlocked = false, upgraded = false }
};

        public List<UpgradeNode> nodes2 = new List<UpgradeNode>
{
    new UpgradeNode { id = 1, requirements = new List<int>(), unlocked = true, upgraded = false },
    new UpgradeNode { id = 2, requirements = new List<int>{1}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 3, requirements = new List<int>{1}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 4, requirements = new List<int>{2}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 5, requirements = new List<int>{2,3}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 6, requirements = new List<int>{3}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 7, requirements = new List<int>{4,5,6}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 8, requirements = new List<int>{7}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 9, requirements = new List<int>{7}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 10, requirements = new List<int>{7}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 11, requirements = new List<int>{8,9}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 12, requirements = new List<int>{9,10}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 13, requirements = new List<int>{11,12}, unlocked = false, upgraded = false }
};

        public List<UpgradeNode> nodes3 = new List<UpgradeNode>
{
    new UpgradeNode { id = 1, requirements = new List<int>(), unlocked = true, upgraded = false },
    new UpgradeNode { id = 2, requirements = new List<int>{1}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 3, requirements = new List<int>{1}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 4, requirements = new List<int>{2}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 5, requirements = new List<int>{2,3}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 6, requirements = new List<int>{3}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 7, requirements = new List<int>{4,5,6}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 8, requirements = new List<int>{7}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 9, requirements = new List<int>{7}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 10, requirements = new List<int>{7}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 11, requirements = new List<int>{8,9}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 12, requirements = new List<int>{9,10}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 13, requirements = new List<int>{11,12}, unlocked = false, upgraded = false }
};

        public List<UpgradeNode> nodes4 = new List<UpgradeNode>
{
    new UpgradeNode { id = 1, requirements = new List<int>(), unlocked = true, upgraded = false },
    new UpgradeNode { id = 2, requirements = new List<int>{1}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 3, requirements = new List<int>{1}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 4, requirements = new List<int>{2}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 5, requirements = new List<int>{2,3}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 6, requirements = new List<int>{3}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 7, requirements = new List<int>{4,5,6}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 8, requirements = new List<int>{7}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 9, requirements = new List<int>{7}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 10, requirements = new List<int>{7}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 11, requirements = new List<int>{8,9}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 12, requirements = new List<int>{9,10}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 13, requirements = new List<int>{11,12}, unlocked = false, upgraded = false }
};

        public List<UpgradeNode> nodes5 = new List<UpgradeNode>
{
    new UpgradeNode { id = 1, requirements = new List<int>(), unlocked = true, upgraded = false },
    new UpgradeNode { id = 2, requirements = new List<int>{1}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 3, requirements = new List<int>{1}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 4, requirements = new List<int>{2}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 5, requirements = new List<int>{2,3}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 6, requirements = new List<int>{3}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 7, requirements = new List<int>{4,5,6}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 8, requirements = new List<int>{7}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 9, requirements = new List<int>{7}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 10, requirements = new List<int>{7}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 11, requirements = new List<int>{8,9}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 12, requirements = new List<int>{9,10}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 13, requirements = new List<int>{11,12}, unlocked = false, upgraded = false }
};

        public List<UpgradeNode> nodes6 = new List<UpgradeNode>
{
    new UpgradeNode { id = 1, requirements = new List<int>(), unlocked = true, upgraded = false },
    new UpgradeNode { id = 2, requirements = new List<int>{1}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 3, requirements = new List<int>{1}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 4, requirements = new List<int>{2}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 5, requirements = new List<int>{2,3}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 6, requirements = new List<int>{3}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 7, requirements = new List<int>{4,5,6}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 8, requirements = new List<int>{7}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 9, requirements = new List<int>{7}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 10, requirements = new List<int>{7}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 11, requirements = new List<int>{8,9}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 12, requirements = new List<int>{9,10}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 13, requirements = new List<int>{11,12}, unlocked = false, upgraded = false }
};

        public List<UpgradeNode> nodes7 = new List<UpgradeNode>
{
    new UpgradeNode { id = 1, requirements = new List<int>(), unlocked = true, upgraded = false },
    new UpgradeNode { id = 2, requirements = new List<int>{1}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 3, requirements = new List<int>{1}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 4, requirements = new List<int>{2}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 5, requirements = new List<int>{2,3}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 6, requirements = new List<int>{3}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 7, requirements = new List<int>{4,5,6}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 8, requirements = new List<int>{7}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 9, requirements = new List<int>{7}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 10, requirements = new List<int>{7}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 11, requirements = new List<int>{8,9}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 12, requirements = new List<int>{9,10}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 13, requirements = new List<int>{11,12}, unlocked = false, upgraded = false }
};

        public List<UpgradeNode> nodes8 = new List<UpgradeNode>
{
    new UpgradeNode { id = 1, requirements = new List<int>(), unlocked = true, upgraded = false },
    new UpgradeNode { id = 2, requirements = new List<int>{1}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 3, requirements = new List<int>{1}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 4, requirements = new List<int>{2}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 5, requirements = new List<int>{2,3}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 6, requirements = new List<int>{3}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 7, requirements = new List<int>{4,5,6}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 8, requirements = new List<int>{7}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 9, requirements = new List<int>{7}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 10, requirements = new List<int>{7}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 11, requirements = new List<int>{8,9}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 12, requirements = new List<int>{9,10}, unlocked = false, upgraded = false },
    new UpgradeNode { id = 13, requirements = new List<int>{11,12}, unlocked = false, upgraded = false }
};


        [Header("Колличество покупок")]
        //public List<int> costShipBankMax = new List<int>() { 13, 2, 4, 5, 6, 12, 4, 12 };


        public int[] countBuffs1 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }; // count
        public int[] countBuffs2 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }; // speed
        public int[] countBuffs3 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }; // cloud mine
        public int[] countBuffs4 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }; // speed mine
        public int[] countBuffs5 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }; // cloud

        public int[] priseBuff1 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
        public int[] priseBuff2 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
        public int[] priseBuff3 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
        public int[] priseBuff4 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
        public int[] priseBuff5 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };

        public bool[] is15 = new bool[] {false, false, false, false, false};

        [Header("Колличество ")]
        public List<double> countOre = new List<double>() { 100000, 10000000, 10000000, 10000000, 10000000, 10000000, 10000000, 10000000 };


        public float indexUp = 1;
        public float indexPrice = 1.2f;
    }
}
[System.Serializable]
public class UpgradeNode
{
    public int id;
    public List<int> requirements; // id нужных узлов
    public bool unlocked; // открыт для прокачки
    public bool upgraded; // уже прокачан
}

public class Stats : MonoBehaviour
{
    [Header("Текст цен")]
    public List<Transform> textShip1 = new List<Transform>();
    public List<Transform> textShip2 = new List<Transform>();
    public List<Transform> textShip3 = new List<Transform>();
    public List<Transform> textShip4 = new List<Transform>();
    public List<Transform> textShip5 = new List<Transform>();
    public List<Transform> textShip6 = new List<Transform>();
    public List<Transform> textShip7 = new List<Transform>();
    public List<Sprite> icone = new List<Sprite>();

    private float[] chance2 = { 60, 40 };
    private float[] chance3 = { 50, 30, 20 };
    private float[] chance4 = { 42.3f, 32.3f, 18.5f, 6.9f };
    private float[] chance5 = { 38.0f, 27.0f, 18.0f, 11.5f, 5.5f };
    private float[] chance6 = { 39.0f, 24.0f, 16.5f, 10.5f, 6.5f, 3.5f };
    private float[] chance7 = { 40.5f, 21.5f, 15.0f, 10.0f, 6.5f, 4.0f, 2.5f };
    private float[] chance8 = { 40.5f, 19.5f, 14.0f, 10.0f, 6.5f, 4.5f, 3.0f, 2.0f };

    int[][] patterns = new int[][]
        {
        new int[] { 1, 1, 1, 1, 1, 1, 1, 15 },
        new int[] { 15, 1, 1, 1, 1, 1, 1, 30 },
        new int[] { 30, 15, 1, 1, 1, 1, 1, 45 },
        new int[] { 45, 30, 15, 1, 1, 1, 1, 60 },
        new int[] { 60, 45, 30, 15, 1, 1, 1, 60 },
        new int[] { 60, 60, 45, 30, 15, 1, 1, 60 },
        new int[] { 60, 60, 60, 45, 30, 15, 1, 60 },
        };
    public PanelBuff panelBuff;
    public int idShip;
    public List<Planet> planats = new List<Planet>();

    public MenegerUI menegerUI;

    public Transform content;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            YG2.SaveProgress();
        }
    }

    private void Start()
    {
        panelBuff.currentPlanet = 1;
        for (int q = 1; q < 6; q++)
        {
                ResetPrice(1 * 10 + q);
        }
        panelBuff.currentPlanet = 0;
        for (int q = 3; q < 5; q++)
        {
            ResetPrice(8 * 10 + q);
        }

    }

    #region Обновление статов
    public void SetCloud(int idShip)
    {
        YG2.saves.countOre[idShip] += YG2.saves.shipCloudMax[idShip];
        menegerUI.OreTextPanel(idShip);
    }

    public void SetMaxCloudShip(int count, int idShip)
    {
        YG2.saves.shipCloudMax[idShip] += count;
        planats[idShip].cloudShipNeed += count;
    }

    public void SetMaxbankPlanet(int count, int idShip)
    {
        YG2.saves.shipBankMax[idShip] += count;
        planats[idShip].bankMax += count;
    }

    public void SetSpeedShip(int count, int idShip)
    {
        YG2.saves.shipSpeed[idShip] += count;
    }
    #endregion

    public void PrintBuyPlanet(int id)
    {
        if(panelBuff.currentPlanet == 0)
        {
            panelBuff.priceEarth[id - 2].SetActive(false);
            panelBuff.buttonEarth.transform.GetChild(id - 2).GetComponent<Button>().interactable = false;
            panelBuff.panelLevelUpEarth[id - 2].gameObject.SetActive(true);
            panelBuff.panelLevelUpEarth[id - 2].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Откройте " + (YG2.saves.countBuyPlanet + 1) + " планету";
        }
        else
        {
            panelBuff.price[id].SetActive(false);
            panelBuff.buttonNoEarth.transform.GetChild(id).GetComponent<Button>().interactable = false;
            panelBuff.panelLevelUp[id].gameObject.SetActive(true);
            panelBuff.panelLevelUp[id].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Откройте " + (YG2.saves.countBuyPlanet + 1) + " планету";
        }
    }

    public void PrintBuyPlanet60(int id)
    {
        if (panelBuff.currentPlanet == 0)
        {
            panelBuff.priceEarth[id - 2].SetActive(false);
            panelBuff.buttonEarth.transform.GetChild(id - 2).GetComponent<Button>().interactable = false;
            panelBuff.panelLevelUpEarth[id - 2].gameObject.SetActive(true);
            panelBuff.panelLevelUpEarth[id - 2].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Максимум";
        }
        else
        {
            panelBuff.price[id].SetActive(false);
            panelBuff.buttonNoEarth.transform.GetChild(id).GetComponent<Button>().interactable = false;
            panelBuff.panelLevelUp[id].gameObject.SetActive(true);
            panelBuff.panelLevelUp[id].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Максимум";
        }
    }
    #region Конопки бафов


    public void CheckBuff15(int idBuff)
    {
        idShip = panelBuff.currentPlanet == 0 ? 7 : panelBuff.currentPlanet;
        //Debug.Log(
        //            "Колличество кораблей = " + string.Join(", ", YG2.saves.countBuffs1[idShip]) + "          " +
        //            "Скорость кораблей = " + string.Join(", ", YG2.saves.countBuffs2[idShip]) + "          " +
        //            "Колличество добычи = " + string.Join(", ", YG2.saves.countBuffs3[idShip]) + "          " +
        //            "Скорость добычи = " + string.Join(", ", YG2.saves.countBuffs4[idShip]) + "          " +
        //            "Емкость кораблей = " + string.Join(", ", YG2.saves.countBuffs5[idShip]));

        bool speedMineOk = false;
        bool countMineOk = false;
        bool countOk = false;
        bool speedOk = false;
        bool cloudMaxOk = false;
        int index = idShip;

        int targetValue = YG2.saves.countBuyPlanet * 15;

        if (idShip == 7)
        {
            countMineOk = YG2.saves.countBuffs3[idShip] == targetValue;
            speedMineOk = YG2.saves.countBuffs4[idShip] == targetValue;
        }
        else
        {
            countOk = YG2.saves.countBuffs1[idShip] == targetValue;
            speedOk = YG2.saves.countBuffs2[idShip] == targetValue;
            countMineOk = YG2.saves.countBuffs3[idShip] == targetValue;
            speedMineOk = YG2.saves.countBuffs4[idShip] == targetValue;
            cloudMaxOk = YG2.saves.countBuffs5[idShip] == targetValue;
        }


        if (countOk && idBuff == 1)
        {
            if (YG2.saves.countBuffs1[idShip] >= 60)
            {
                PrintBuyPlanet60(idBuff - 1);
            } 
            else 
            {
                PrintBuyPlanet(idBuff - 1);
            }

        }
        if (speedOk && idBuff == 2)
        {
            if (YG2.saves.countBuffs2[idShip] >= 60)
            {
                PrintBuyPlanet60(idBuff - 1);
            }
            else
            {
                PrintBuyPlanet(idBuff - 1);
            }
        }
        if (countMineOk && idBuff == 3)
        {
            if (YG2.saves.countBuffs3[idShip] >= 60)
            {
                PrintBuyPlanet60(idBuff - 1);
            }
            else
            {
                PrintBuyPlanet(idBuff - 1);
            }
        }
        if (speedMineOk && idBuff == 4)
        {
            if (YG2.saves.countBuffs4[idShip] >= 60)
            {
                PrintBuyPlanet60(idBuff - 1);
            }
            else
            {
                PrintBuyPlanet(idBuff - 1);
            }
        }
        if (cloudMaxOk && idBuff == 5)
        {
            if (YG2.saves.countBuffs5[idShip] >= 60)
            {
                PrintBuyPlanet60(idBuff - 1);
            }
            else
            {
                PrintBuyPlanet(idBuff - 1);
            }
        }

        bool isON = false;
        switch (YG2.saves.countBuyPlanet)
        {
            case 1:
                isON =
                    YG2.saves.countBuffs1.SequenceEqual(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }) &&
                    YG2.saves.countBuffs2.SequenceEqual(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }) &&
                    YG2.saves.countBuffs3.SequenceEqual(new int[] { 1, 1, 1, 1, 1, 1, 1, 15 }) &&
                    YG2.saves.countBuffs4.SequenceEqual(new int[] { 1, 1, 1, 1, 1, 1, 1, 15 }) &&
                    YG2.saves.countBuffs5.SequenceEqual(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 });
                break;
            case 2:
                isON =
                    YG2.saves.countBuffs1.SequenceEqual(new int[] { 15, 1, 1, 1, 1, 1, 1, 1 }) &&
                    YG2.saves.countBuffs2.SequenceEqual(new int[] { 15, 1, 1, 1, 1, 1, 1, 1 }) &&
                    YG2.saves.countBuffs3.SequenceEqual(new int[] { 15, 1, 1, 1, 1, 1, 1, 30 }) &&
                    YG2.saves.countBuffs4.SequenceEqual(new int[] { 15, 1, 1, 1, 1, 1, 1, 30 }) &&
                    YG2.saves.countBuffs5.SequenceEqual(new int[] { 15, 1, 1, 1, 1, 1, 1, 1 });
                break;
            case 3:
                isON =
                    YG2.saves.countBuffs1.SequenceEqual(new int[] { 30, 15, 1, 1, 1, 1, 1, 1 }) &&
                    YG2.saves.countBuffs2.SequenceEqual(new int[] { 30, 15, 1, 1, 1, 1, 1, 1 }) &&
                    YG2.saves.countBuffs3.SequenceEqual(new int[] { 30, 15, 1, 1, 1, 1, 1, 45 }) &&
                    YG2.saves.countBuffs4.SequenceEqual(new int[] { 30, 15, 1, 1, 1, 1, 1, 45 }) &&
                    YG2.saves.countBuffs5.SequenceEqual(new int[] { 30, 15, 1, 1, 1, 1, 1, 1 });
                break;
            case 4:
                isON =
                    YG2.saves.countBuffs1.SequenceEqual(new int[] { 45, 30, 15, 1, 1, 1, 1, 1 }) &&
                    YG2.saves.countBuffs2.SequenceEqual(new int[] { 45, 30, 15, 1, 1, 1, 1, 1 }) &&
                    YG2.saves.countBuffs3.SequenceEqual(new int[] { 45, 30, 15, 1, 1, 1, 1, 60 }) &&
                    YG2.saves.countBuffs4.SequenceEqual(new int[] { 45, 30, 15, 1, 1, 1, 1, 60 }) &&
                    YG2.saves.countBuffs5.SequenceEqual(new int[] { 45, 30, 15, 1, 1, 1, 1, 1 });
                break;
            case 5:
                isON =
                    YG2.saves.countBuffs1.SequenceEqual(new int[] { 60, 45, 30, 15, 1, 1, 1, 1 }) &&
                    YG2.saves.countBuffs2.SequenceEqual(new int[] { 60, 45, 30, 15, 1, 1, 1, 1 }) &&
                    YG2.saves.countBuffs3.SequenceEqual(new int[] { 60, 45, 30, 15, 1, 1, 1, 15 }) &&
                    YG2.saves.countBuffs4.SequenceEqual(new int[] { 60, 45, 30, 15, 1, 1, 1, 15 }) &&
                    YG2.saves.countBuffs5.SequenceEqual(new int[] { 60, 45, 30, 15, 1, 1, 1, 1 });
                break;
            case 6:
                isON =
                    YG2.saves.countBuffs1.SequenceEqual(new int[] { 60, 60, 45, 30, 15, 1, 1, 1 }) &&
                    YG2.saves.countBuffs2.SequenceEqual(new int[] { 60, 60, 45, 30, 15, 1, 1, 1 }) &&
                    YG2.saves.countBuffs3.SequenceEqual(new int[] { 60, 60, 45, 30, 15, 1, 1, 15 }) &&
                    YG2.saves.countBuffs4.SequenceEqual(new int[] { 60, 60, 45, 30, 15, 1, 1, 15 }) &&
                    YG2.saves.countBuffs5.SequenceEqual(new int[] { 60, 60, 45, 30, 15, 1, 1, 1 });
                break;
            case 7:
                isON =
                    YG2.saves.countBuffs1.SequenceEqual(new int[] { 60, 60, 60, 45, 30, 15, 1, 1 }) &&
                    YG2.saves.countBuffs2.SequenceEqual(new int[] { 60, 60, 60, 45, 30, 15, 1, 1 }) &&
                    YG2.saves.countBuffs3.SequenceEqual(new int[] { 60, 60, 60, 45, 30, 15, 1, 15 }) &&
                    YG2.saves.countBuffs4.SequenceEqual(new int[] { 60, 60, 60, 45, 30, 15, 1, 15 }) &&
                    YG2.saves.countBuffs5.SequenceEqual(new int[] { 60, 60, 60, 45, 30, 15, 1, 1 });
                break;

        }


        if (isON)
        {
            YG2.saves.countReadyPlanet++;
            menegerUI.isOn = true;
            print("Апнул");
            //content.GetChild(YG2.saves.countBuyPlanet).GetChild(1).gameObject.SetActive(true);
            //content.GetChild(YG2.saves.countBuyPlanet).GetChild(4).gameObject.SetActive(true);
        }
    }



    public void Buffing(int id)
    {
        idShip = panelBuff.currentPlanet == 0 ? 8 : panelBuff.currentPlanet;
        int idBuff = id; 
        int originalOres = 0;
        int countBuff = 0;

        switch (idBuff)
        {        
            case 1:
                originalOres = YG2.saves.priseBuff1[idShip - 1];
                countBuff = YG2.saves.countBuffs1[idShip - 1];
                break;
            case 2:
                originalOres = YG2.saves.priseBuff2[idShip - 1];
                countBuff = YG2.saves.countBuffs2[idShip - 1];
                break;
            case 3:
                originalOres = YG2.saves.priseBuff3[idShip - 1];
                countBuff = YG2.saves.countBuffs3[idShip - 1];
                break;
            case 4:
                originalOres = YG2.saves.priseBuff4[idShip - 1];
                countBuff = YG2.saves.countBuffs4[idShip - 1];
                break;
            case 5:
                originalOres = YG2.saves.priseBuff5[idShip - 1];
                countBuff = YG2.saves.countBuffs5[idShip - 1];
                break;
        }


        int ores = originalOres;    // Рабочая копия
        bool itsBuy = true;

        // Первый проход: проверка возможности покупки
        while (ores != 0)
        {
            int q = ores % 10;      // Получаем цифру (тип руды)
            ores /= 10;

            if (YG2.saves.countOre[q - 1] < PriseOre(countBuff, q))
            {
                itsBuy = false;
                break;  // Прерываем цикл, если хотя бы одного ресурса не хватает
            }
        }

        // Второй проход: списание ресурсов
        if (itsBuy)
        {
            ores = originalOres;  // Восстанавливаем исходное значение

                switch (idBuff)
            {
                case 1:
                    countBuff = YG2.saves.countBuffs1[idShip - 1]++;
                    break;
                case 2:
                    countBuff = YG2.saves.countBuffs2[idShip - 1]++;
                    break;
                case 3:
                    countBuff = YG2.saves.countBuffs3[idShip - 1]++;
                    break;
                case 4:
                    countBuff = YG2.saves.countBuffs4[idShip - 1]++;
                    break;
                case 5:
                    countBuff = YG2.saves.countBuffs5[idShip - 1]++;
                    break;
            }

            while (ores != 0)
            {
                int q = ores % 10;      // Получаем цифру (тип руды)
                ores /= 10;
                YG2.saves.countOre[q - 1] -= PriseOre(countBuff, q);
                menegerUI.OreTextPanel(q - 1);
            }
            
            //CheckUnlockBuff();
            ResetPrice(idShip * 10 + id);
            CheckBuff15(idBuff);
            // Сохраняем изменения
            YG2.SaveProgress();
        }
        else
        {
            Debug.Log("Недостаточно ресурсов для покупки!");
        }
    }
    #endregion



    #region Из 12.3f в 123000 и обратно
    public string FormatGold(double value)
    {
        string[] suffixes = { "", "a", "b", "c", "d", "e", "f", "g", "h", "i",
                          "j", "k", "l", "m", "n", "o", "p", "q", "r", "s",
                          "t", "u", "v", "w", "x", "y", "z" };

        int suffixIndex = 0;
        while (value >= 1000 && suffixIndex < suffixes.Length - 1)
        {
            value /= 1000;
            suffixIndex++;
        }
        return value.ToString("0.#") + suffixes[suffixIndex];
    }

    public static double ReFormatGold(string input)
    {
        string suffixes = "abcdefghijklmnopqrstuvwxyz";
        int i = 0;
        while (i < input.Length &&
              (char.IsDigit(input[i]) || input[i] == '.' || input[i] == ','))
        {
            i++;
        }
        double number = double.Parse(input.Substring(0, i).Replace(',', '.'));
        if (i >= input.Length)
        {
            // Нет суффикса, просто вернуть число
            return number;
        }
        int suffixIndex = suffixes.IndexOf(char.ToLower(input[i]));
        double multiplier = Math.Pow(1000, suffixIndex + 1);
        return number * multiplier;
    }

    #endregion


    #region Перезапись цен

    public void ResetPrice(int id)
    {
        int idShip = id / 10;
        int idBuff = id % 10;

        // Активируем нужную панель ресурсов
        int countOre = RandomCountOre();
        Transform panel = null;

        if (panelBuff.currentPlanet != 0)
        {
            panel = panelBuff.price[idBuff - 1].transform;
        }
        else
        {
            panel = panelBuff.priceEarth[idBuff - 3].transform;
        }


        for (int i = 0; i < 3; i++)
        {
            panel.GetChild(i).gameObject.SetActive(i == countOre - 1);
        }


        int buff = 0;
        if (idShip == 8)
        {
            buff = 0;
        }
        switch (idBuff)
        {
            case 1:
                buff += YG2.saves.countBuffs1[idShip - 1];
                break;
            case 2:
                buff += YG2.saves.countBuffs2[idShip - 1];
                break;
            case 3:
                buff += YG2.saves.countBuffs3[idShip - 1];
                break;
            case 4:
                buff += YG2.saves.countBuffs4[idShip - 1];
                break;
            case 5:
                buff += YG2.saves.countBuffs5[idShip - 1];
                break;
        }


        int idOre1 = 100;
        int saveOre = 0;

        for (int i = 0; i < countOre; i++)
        {
            int idOre = RandomOre();
            
            do { idOre = RandomOre(); }
            while (idOre == idOre1);

            idOre1 = idOre;
            saveOre += idOre + (i * 10);
            int price1 = PriseOre(buff, idOre1);


            GameObject panel1 = panelBuff.currentPlanet != 0 ? panelBuff.price[idBuff - 1]  : panelBuff.priceEarth[idBuff - 3];

            panel1.transform.GetChild(i).gameObject.SetActive(true);
            panel1.transform.GetChild(i).GetComponent<Image>().sprite = icone[idOre1 - 1];
            panel1.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = price1.ToString();


        }

        switch (idBuff)
        {
            case 1:
                YG2.saves.priseBuff1[idShip - 1] = saveOre;
                if (panelBuff.currentPlanet != 0)
                {
                    panelBuff.sliders[id % 10 - 1].value = YG2.saves.countBuffs1[idShip - 1];
                    panelBuff.textPowerBuff[id % 10 - 1].text = (YG2.saves.countBuffs1[idShip - 1] * 13).ToString();
                }
                else
                {
                    panelBuff.slidersEarth[id % 10 - 3].value = YG2.saves.countBuffs1[idShip - 1];
                    panelBuff.textPowerBuffEarth[id % 10 - 3].text = (YG2.saves.countBuffs1[idShip - 1] * 13).ToString();
                }
                
                break;


            case 2:
                YG2.saves.priseBuff2[idShip - 1] = saveOre;
                if (panelBuff.currentPlanet != 0)
                {
                    panelBuff.sliders[id % 10 - 1].value = YG2.saves.countBuffs2[idShip - 1];
                    panelBuff.textPowerBuff[id % 10 - 1].text = (YG2.saves.countBuffs2[idShip - 1] * 13).ToString();
                }
                else
                {
                    panelBuff.slidersEarth[id % 10 - 3].value = YG2.saves.countBuffs2[idShip - 1];
                    panelBuff.textPowerBuffEarth[id % 10 - 3].text = (YG2.saves.countBuffs2[idShip - 1] * 13).ToString();
                }
                break;


            case 3:
                YG2.saves.priseBuff3[idShip - 1] = saveOre;
                if (panelBuff.currentPlanet != 0)
                {
                    panelBuff.sliders[id % 10 - 1].value = YG2.saves.countBuffs3[idShip - 1];
                    panelBuff.textPowerBuff[id % 10 - 1].text = (YG2.saves.countBuffs3[idShip - 1] * 13).ToString();
                }
                else
                {
                    panelBuff.slidersEarth[id % 10 - 3].value = YG2.saves.countBuffs3[idShip - 1];
                    panelBuff.textPowerBuffEarth[id % 10 - 3].text = (YG2.saves.countBuffs3[idShip - 1] * 13).ToString();
                }
                break;


            case 4:
                YG2.saves.priseBuff4[idShip - 1] = saveOre;
                if (panelBuff.currentPlanet != 0)
                {
                    panelBuff.sliders[id % 10 - 1].value = YG2.saves.countBuffs4[idShip - 1];
                    panelBuff.textPowerBuff[id % 10 - 1].text = (YG2.saves.countBuffs4[idShip - 1] * 13).ToString();
                }
                else
                {
                    panelBuff.slidersEarth[id % 10 - 3].value = YG2.saves.countBuffs4[idShip - 1];
                    panelBuff.textPowerBuffEarth[id % 10 - 3].text = (YG2.saves.countBuffs4[idShip - 1] * 13).ToString();
                }
                break;


            case 5:
                YG2.saves.priseBuff5[idShip - 1] = saveOre;
                if (panelBuff.currentPlanet != 0)
                {
                    panelBuff.sliders[id % 10 - 1].value = YG2.saves.countBuffs5[idShip - 1];
                    panelBuff.textPowerBuff[id % 10 - 1].text = (YG2.saves.countBuffs5[idShip - 1] * 13).ToString();
                }
                else
                {
                    panelBuff.slidersEarth[id % 10 - 3].value = YG2.saves.countBuffs5[idShip - 1];
                    panelBuff.textPowerBuffEarth[id % 10 - 3].text = (YG2.saves.countBuffs5[idShip - 1] * 13).ToString();
                }
                break;
        }
        CheckBuff15(idBuff);



    }


    #region Выбор рандомной руды
    public int RandomOre()
    {
        int planetCount = YG2.saves.countBuyPlanet;

        return planetCount switch
        {
            1 => 1, // Только первый ресурс (100%)
            2 => SelectByWeight(chance2),
            3 => SelectByWeight(chance3),
            4 => SelectByWeight(chance4),
            5 => SelectByWeight(chance5),
            6 => SelectByWeight(chance6),
            7 => SelectByWeight(chance7),
            _ => SelectByWeight(chance8) // 8+ планет
        };
    }

    public int SelectByWeight(float[] weights)
    {
        float roll = UnityEngine.Random.Range(0f, 100f);
        float current = 0f;

        for (int i = 0; i < weights.Length; i++)
        {
            current += weights[i];
            if (roll < current)
                return i + 1;
        }

        throw new Exception("Я ушел за предел, брат"); // На всякий случай
    }

    #endregion


    public int FindIconeInOre(Sprite sprite)
    {
        for (int i = 0; i < icone.Count; i++)
        {
            if (icone[i] == sprite)
            {
                return i;
            }
        }
        return 10000;
    }

    public string CheckOre(int idOre)
    {
        switch (idOre)
        {
            case 0:
                return "Земля";

            case 1:
                return "Меркурий";

            case 2:
                return "Венера";

            case 3:
                return "Марс";

            case 4:
                return "Юпитер";

            case 5:
                return "Сатурн";

            case 6:
                return "Уран";

            case 7:
                return "Нептун";

            default: return "не нашел";

        }
    }

    public int RandomCountOre()
    {
        int chance = UnityEngine.Random.Range(0, 100);
        int boughtPlanets = YG2.saves.countBuyPlanet;

        switch (boughtPlanets)
        {
            case 1: return 1;
            case 2: return chance < 60 ? 2 : 1;
            case >= 3:
                if (chance < 50) return 3;
                if (chance < 80) return 2;
                return 1;
            default: return 0;
        }
    }



    public int PriseOre(int buff, int idOre)
    {
        if (idOre == 1) return (int)(10 * Mathf.Pow(YG2.saves.indexPrice, buff));
        if (idOre == 2) return (int)(10 * Mathf.Pow(YG2.saves.indexPrice, buff - 15) * 1.2f);
        if (idOre == 3) return (int)(10 * Mathf.Pow(YG2.saves.indexPrice, buff - 30) * 1.4f);
        if (idOre == 4) return (int)(10 * Mathf.Pow(YG2.saves.indexPrice, buff - 45) * 1.6f);
        if (idOre == 5) return (int)(10 * Mathf.Pow(YG2.saves.indexPrice, buff - 60) * 1.8f);
        if (idOre == 6) return (int)(10 * Mathf.Pow(YG2.saves.indexPrice, buff - 75) * 2f);
        if (idOre == 7) return (int)(10 * Mathf.Pow(YG2.saves.indexPrice, buff - 90) * 2.2f);
        return 0;
    }
    #endregion
}
