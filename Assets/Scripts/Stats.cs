using System;
using System.Collections;
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

        //[Header("Параметры")]
        //public List<int> shipCloudMax = new List<int>() { 20, 20, 20, 20, 20, 20, 20, 20 };
        //public List<int> shipCount = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1 };
        //public List<int> shipBankMax = new List<int>() { 20, 20, 20, 20, 20, 20, 20 };
        //public List<int> shipSpeed = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1 };

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


        public int[] countBuffs1 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }; // speed mine 
        public int[] countBuffs2 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }; // cloud mine
        public int[] countBuffs3 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }; // speed 
        public int[] countBuffs4 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }; // cloud
        public int[] countBuffs5 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }; // count

        public int[] countBuffsClick = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }; // click
        public bool[] buffTreeSpeedShip = new bool[] { false, false, false, false, false, false, false};
        public int[] buffTreeCloudShip = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
        public bool[] buffTreeCloudMine = new bool[] { false, false, false, false, false, false, false, false };
        public bool[] buffTreeSpeedMine = new bool[] { false, false, false, false, false, false, false, false };
        public bool[] buffTreeECO = new bool[] { false, false, false, false, false, false, false, false };
        public bool[] buffTreePrice = new bool[] { false, false, false, false, false, false, false, false };
        public bool[] buffTreeAFKfarm = new bool[] { false, false, false, false, false, false, false, false};

        public int[] priseBuff1 = new int[] {12, 13, 13, 35, 632, 472, 438, 1 };
        public int[] priseBuff2 = new int[] {21, 123, 42, 12, 5, 746, 216, 1 };
        public int[] priseBuff3 = new int[] {1, 21, 132, 5, 621, 143, 853, 1 };
        public int[] priseBuff4 = new int[] {2, 32, 24, 42, 524, 123, 34, 1 };
        public int[] priseBuff5 = new int[] {2, 3, 14, 351, 34, 53, 18, 1 };

        public int[] countShip = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
        public int[] shipFly = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] bankNow = new double[] { 0, 0, 0, 0, 0, 0, 0, 0 };

        public bool[] is15 = new bool[] {false, false, false, false, false};

        [Header("Колличество ")]
        public List<double> countOre = new List<double>() { 0, 0, 0, 0, 0, 0, 0, 0 };
        public long[] shopBuy = new long[] {0,0};
        public long[] shopBuyGem = new long[] {0,0,0,0,0};
        public long shopTimer = 0;
        public int[] shopOre = new int[] { 0, 0, 0, 0, 0 };
        public int shopFree;
        public float autoClick = 0;
        public float x2ores = 0;
        public float speedBoost = 0;
        public int gems = 0;

        public float indexUp = 1;
        public float indexPrice = 1.3f;

        public double liderBoard;
    }
}





public static class Parametrs
{
    public static int[] upgradeCosts = { 100, 5000, 5000, 15000, 30000, 15000, 50000, 100000, 150000, 100000, 500000, 400000, 1000000 };
    public static double SpeedMine(int id)
    {
        int exponent = Mathf.Max(YG2.saves.countBuffs1[id] - 1, 0);
        double speed = 10 * System.Math.Pow(0.95, exponent);
        speed = YG2.saves.buffTreeSpeedMine[id] ? speed * 0.7 : speed;
        return speed;
    }

    public static double CloudMine(int id)
    {
        int exponent = Mathf.Max(YG2.saves.countBuffs2[id], 0);
        double cloud = 50 * System.Math.Pow(1.05, exponent);
        cloud = YG2.saves.buffTreeCloudMine[id] ? cloud * 1.5 : cloud;
        return cloud;
    }

    public static float SpeedShip(int id)
    {
        int exponent = Mathf.Max(YG2.saves.countBuffs3[id], 0);
        float baseSpeed = 0.5f * (float)System.Math.Pow(1.05, exponent);
        baseSpeed += YG2.saves.buffTreeSpeedShip[id] ? baseSpeed * 1.5f : 0f;
        return baseSpeed;
    }

    public static double CloudShip(int id)
    {
        int exponent = Mathf.Max(YG2.saves.countBuffs4[id] - 1, 0);
        double cloud = 50 * System.Math.Pow(1.05, exponent);
        switch (YG2.saves.buffTreeCloudShip[id])
        {
            case 1:
                cloud *= 1.5;
                break;
            case 2:
                cloud *= 2;
                break;
        }
        return cloud;
    }

    public static double Click(int id)
    {
        double ore = 1 + 100 * YG2.saves.countBuffsClick[id];
        ore = YG2.saves.x2ores > 0 ? ore * 2 : ore;
        return ore;
    }

    public static double Ore(int id)
    {
        double ore = (id == 0) ? CloudMine(7) : CloudShip(id - 1);
        ore = YG2.saves.x2ores > 0 ? ore * 2 : ore;
        return ore;
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
    public Slider sliderPlanet;
    public TextMeshProUGUI textPlanet;
    public List<Sprite> icone = new List<Sprite>();

    private float[] chance2 = { 60, 40 };
    private float[] chance3 = { 50, 30, 20 };
    private float[] chance4 = { 42.3f, 32.3f, 18.5f, 6.9f };
    private float[] chance5 = { 38.0f, 27.0f, 18.0f, 11.5f, 5.5f };
    private float[] chance6 = { 39.0f, 24.0f, 16.5f, 10.5f, 6.5f, 3.5f };
    private float[] chance7 = { 40.5f, 21.5f, 15.0f, 10.0f, 6.5f, 4.0f, 2.5f };
    private float[] chance8 = { 40.5f, 19.5f, 14.0f, 10.0f, 6.5f, 4.5f, 3.0f, 2.0f };

    public PanelBuff panelBuff;
    public int idShip;
    public List<Planet> planats = new List<Planet>();

    

    public MenegerUI menegerUI;

    public Transform content;

    private void Awake()
    {
        StartCoroutine(Save());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {

            YG2.SaveProgress();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {

            for (int i = 0; i < YG2.saves.countOre.Count; i++)
            {
                YG2.saves.countOre[i] = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
                YG2.saves.gems = 100;

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            YG2.saves.autoClick = 0;
            YG2.saves.x2ores = 0;
            YG2.saves.speedBoost = 0;

        }
        if (Input.GetKeyDown(KeyCode.W))
        {

            for (int i = 0; i < YG2.saves.countOre.Count; i++)
            {
                YG2.saves.countOre[i] = 100000000000;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

            for (int i = 0; i < YG2.saves.countOre.Count; i++)
            {
                YG2.saves.countOre[i] = 100;
            }
        }
    }

    private void Start()
    {
        YG2.saves.shipFly = new int[] {0, 0, 0, 0, 0, 0, 0, 0};
        YG2.saves.countShip = new int[] {0, 0, 0, 0, 0, 0, 0, 0};
        panelBuff.currentPlanet = 0;
        for (int q = 3; q < 5; q++)
        {
            PrintPrice(q);
            CheckBuff15(q);
        }

    }

    IEnumerator Save()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            YG2.SaveProgress();
            YG2.SetLeaderboard("Top", (int)YG2.saves.liderBoard);
        }
    }

    #region Обновление статов
    //public void SetCloud(int idShip)
    //{
    //   // YG2.saves.countOre[idShip] += YG2.saves.shipCloudMax[idShip];
    //    //menegerUI.OreTextPanel(idShip);
    //}

    //public void SetMaxCloudShip(int count, int idShip)
    //{
    //   // YG2.saves.shipCloudMax[idShip] += count;
    //   // planats[idShip].cloudShipNeed += count;
    //}

    //public void SetMaxbankPlanet(int count, int idShip)
    //{
    //    //YG2.saves.shipBankMax[idShip] += count;
    //    //planats[idShip].bankMax += count;
    //}

    //public void SetSpeedShip(int count, int idShip)
    //{
    //    //YG2.saves.shipSpeed[idShip] += count;
    //}
    #endregion

    public void PrintBuyPlanet(int id)
    {
        panelBuff.price[id].SetActive(false);
        menegerUI.buttons[id].GetComponent<Button>().interactable = false;
        panelBuff.panelLevelUp[id].gameObject.SetActive(true);
        //panelBuff.panelLevelUp[id].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Откройте " + (YG2.saves.countBuyPlanet + 1) + " планету";
    }

    public void PrintBuyPlanet60(int id)
    {
        panelBuff.price[id].SetActive(false);
        menegerUI.buttons[id].GetComponent<Button>().interactable = false;
        panelBuff.panelLevelUp[id].gameObject.SetActive(true);
        //panelBuff.panelLevelUp[id].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Максимум";
    }
    #region Конопки бафов


    public void CheckBuff15(int idBuff)
    {
        idShip = panelBuff.currentPlanet == 0 ? 7 : panelBuff.currentPlanet;

        panelBuff.price[idBuff - 1].SetActive(true);
        menegerUI.buttons[idBuff - 1].GetComponent<Button>().interactable = true;
        panelBuff.panelLevelUp[idBuff - 1].gameObject.SetActive(false);

        bool speedMineOk = false;
        bool countMineOk = false;
        bool countOk = false;
        bool speedOk = false;
        bool cloudMaxOk = false;
        int index = idShip;

        int targetValue = idShip == 7 ? YG2.saves.countBuyPlanet * 15 : (YG2.saves.countBuyPlanet - idShip) * 15;

        if (idShip == 7)
        {
            speedMineOk = YG2.saves.countBuffs1[idShip] == targetValue;
            countMineOk = YG2.saves.countBuffs2[idShip] == targetValue;
        }
        else
        {
            speedMineOk = YG2.saves.countBuffs1[idShip - 1] == targetValue;
            countMineOk = YG2.saves.countBuffs2[idShip - 1] == targetValue;
            speedOk = YG2.saves.countBuffs3[idShip - 1] == targetValue;
            cloudMaxOk = YG2.saves.countBuffs4[idShip - 1] == targetValue;
            countOk = YG2.saves.countBuffs5[idShip - 1] == targetValue;
        }


        if (speedMineOk && idBuff == 1)
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
        if (countMineOk && idBuff == 2)
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
        if (speedOk && idBuff == 3)
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
        if (cloudMaxOk && idBuff == 4)
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
        if (countOk && idBuff == 5)
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
                    YG2.saves.countBuffs3.SequenceEqual(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }) &&
                    YG2.saves.countBuffs4.SequenceEqual(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }) &&
                    YG2.saves.countBuffs1.SequenceEqual(new int[] { 1, 1, 1, 1, 1, 1, 1, 15 }) &&
                    YG2.saves.countBuffs2.SequenceEqual(new int[] { 1, 1, 1, 1, 1, 1, 1, 15 }) &&
                    YG2.saves.countBuffs5.SequenceEqual(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 });
                break;
            case 2:
                isON =
                    YG2.saves.countBuffs3.SequenceEqual(new int[] { 15, 1, 1, 1, 1, 1, 1, 1 }) &&
                    YG2.saves.countBuffs4.SequenceEqual(new int[] { 15, 1, 1, 1, 1, 1, 1, 1 }) &&
                    YG2.saves.countBuffs1.SequenceEqual(new int[] { 15, 1, 1, 1, 1, 1, 1, 30 }) &&
                    YG2.saves.countBuffs2.SequenceEqual(new int[] { 15, 1, 1, 1, 1, 1, 1, 30 }) &&
                    YG2.saves.countBuffs5.SequenceEqual(new int[] { 15, 1, 1, 1, 1, 1, 1, 1 });
                break;
            case 3:
                isON =
                    YG2.saves.countBuffs3.SequenceEqual(new int[] { 30, 15, 1, 1, 1, 1, 1, 1 }) &&
                    YG2.saves.countBuffs4.SequenceEqual(new int[] { 30, 15, 1, 1, 1, 1, 1, 1 }) &&
                    YG2.saves.countBuffs1.SequenceEqual(new int[] { 30, 15, 1, 1, 1, 1, 1, 45 }) &&
                    YG2.saves.countBuffs2.SequenceEqual(new int[] { 30, 15, 1, 1, 1, 1, 1, 45 }) &&
                    YG2.saves.countBuffs5.SequenceEqual(new int[] { 30, 15, 1, 1, 1, 1, 1, 1 });
                break;
            case 4:
                isON =
                    YG2.saves.countBuffs3.SequenceEqual(new int[] { 45, 30, 15, 1, 1, 1, 1, 1 }) &&
                    YG2.saves.countBuffs4.SequenceEqual(new int[] { 45, 30, 15, 1, 1, 1, 1, 1 }) &&
                    YG2.saves.countBuffs1.SequenceEqual(new int[] { 45, 30, 15, 1, 1, 1, 1, 60 }) &&
                    YG2.saves.countBuffs4.SequenceEqual(new int[] { 45, 30, 15, 1, 1, 1, 1, 60 }) &&
                    YG2.saves.countBuffs2.SequenceEqual(new int[] { 45, 30, 15, 1, 1, 1, 1, 1 });
                break;
            case 5:
                isON =
                    YG2.saves.countBuffs3.SequenceEqual(new int[] { 60, 45, 30, 15, 1, 1, 1, 1 }) &&
                    YG2.saves.countBuffs4.SequenceEqual(new int[] { 60, 45, 30, 15, 1, 1, 1, 1 }) &&
                    YG2.saves.countBuffs1.SequenceEqual(new int[] { 60, 45, 30, 15, 1, 1, 1, 15 }) &&
                    YG2.saves.countBuffs2.SequenceEqual(new int[] { 60, 45, 30, 15, 1, 1, 1, 15 }) &&
                    YG2.saves.countBuffs5.SequenceEqual(new int[] { 60, 45, 30, 15, 1, 1, 1, 1 });
                break;
            case 6:
                isON =
                    YG2.saves.countBuffs3.SequenceEqual(new int[] { 60, 60, 45, 30, 15, 1, 1, 1 }) &&
                    YG2.saves.countBuffs4.SequenceEqual(new int[] { 60, 60, 45, 30, 15, 1, 1, 1 }) &&
                    YG2.saves.countBuffs1.SequenceEqual(new int[] { 60, 60, 45, 30, 15, 1, 1, 15 }) &&
                    YG2.saves.countBuffs2.SequenceEqual(new int[] { 60, 60, 45, 30, 15, 1, 1, 15 }) &&
                    YG2.saves.countBuffs5.SequenceEqual(new int[] { 60, 60, 45, 30, 15, 1, 1, 1 });
                break;
            case 7:
                isON =
                    YG2.saves.countBuffs3.SequenceEqual(new int[] { 60, 60, 60, 45, 30, 15, 1, 1 }) &&
                    YG2.saves.countBuffs4.SequenceEqual(new int[] { 60, 60, 60, 45, 30, 15, 1, 1 }) &&
                    YG2.saves.countBuffs1.SequenceEqual(new int[] { 60, 60, 60, 45, 30, 15, 1, 15 }) &&
                    YG2.saves.countBuffs2.SequenceEqual(new int[] { 60, 60, 60, 45, 30, 15, 1, 15 }) &&
                    YG2.saves.countBuffs5.SequenceEqual(new int[] { 60, 60, 60, 45, 30, 15, 1, 1 });
                break;

        }


        if (isON)
        {
            YG2.saves.countReadyPlanet++;
            menegerUI.isOn = true;
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

            if (YG2.saves.countOre[q - 1] < PriseOre(countBuff, q, idShip == 8 ? 0 : idShip))
            {
                menegerUI.sound.PlaySound(3);
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
            menegerUI.sound.PlaySound(0);
            while (ores != 0)
            {
                int q = ores % 10;      // Получаем цифру (тип руды)
                ores /= 10;
                YG2.saves.countOre[q - 1] -= PriseOre(countBuff, q, idShip == 8 ? 0 : idShip);
                menegerUI.OreTextPanel(q - 1);
            }
            SetNewPrice(idBuff);
            PrintPrice(idBuff);
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

        // Округляем значение так, чтобы было максимум 2 значащих цифры
        int digits = (int)Math.Floor(Math.Log10(value)) + 1;
        int decimals = digits > 2 ? 0 : 1;

        return value.ToString("F" + decimals) + suffixes[suffixIndex];
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

    public void SetNewPrice(int idBuff)
    {
        int idShip = panelBuff.currentPlanet == 0 ? 8 : panelBuff.currentPlanet;
        int countOre = RandomCountOre();

        int idOre1 = 0;
        int saveOre = 0;

        if (countOre == 1)
        {
            saveOre = RandomOre();
        }
        if (countOre == 2)
        {
            int idOre01 = 0;
            int idOre10 = 0;

            idOre01 = RandomOre();

            do { idOre10 = RandomOre(); }
            while (idOre01 == idOre10);

            saveOre = idOre01 + (idOre10 * 10);
        }
        if (countOre == 3)
        {
            int idOre010 = 0;
            int idOre001 = 0;
            int idOre100 = 0;

            idOre001 = RandomOre();

            do { idOre100 = RandomOre(); idOre010 = RandomOre();}
            while (idOre001 == idOre010 || idOre001 == idOre100 || idOre100 == idOre010);

            saveOre = idOre001 + (idOre010 * 10) + (idOre100 * 100);
        }

        switch (idBuff)
        {
            case 1: YG2.saves.priseBuff1[idShip - 1] = saveOre; break;
            case 2: YG2.saves.priseBuff2[idShip - 1] = saveOre; break;
            case 3: YG2.saves.priseBuff3[idShip - 1] = saveOre; break;
            case 4: YG2.saves.priseBuff4[idShip - 1] = saveOre; break;
            case 5: YG2.saves.priseBuff5[idShip - 1] = saveOre; break;
        }
    }


    public void PrintPrice(int idBuff)
    {
        int idShip = panelBuff.currentPlanet == 0 ? 8 : panelBuff.currentPlanet;
        
        Transform panel = panelBuff.price[idBuff - 1].transform;

        int countOrs = 0;
        int buff = 0;
        int allPrice = 0;
        int price = 0;

        switch (idBuff)
        {
            case 1: buff = YG2.saves.countBuffs1[idShip - 1]; allPrice = YG2.saves.priseBuff1[idShip - 1]; countOrs = Math.Abs(YG2.saves.priseBuff1[idShip - 1]).ToString().Length; break;
            case 2: buff = YG2.saves.countBuffs2[idShip - 1]; allPrice = YG2.saves.priseBuff2[idShip - 1]; countOrs = Math.Abs(YG2.saves.priseBuff2[idShip - 1]).ToString().Length; break;
            case 3: buff = YG2.saves.countBuffs3[idShip - 1]; allPrice = YG2.saves.priseBuff3[idShip - 1]; countOrs = Math.Abs(YG2.saves.priseBuff3[idShip - 1]).ToString().Length; break;
            case 4: buff = YG2.saves.countBuffs4[idShip - 1]; allPrice = YG2.saves.priseBuff4[idShip - 1]; countOrs = Math.Abs(YG2.saves.priseBuff4[idShip - 1]).ToString().Length; break;
            case 5: buff = YG2.saves.countBuffs5[idShip - 1]; allPrice = YG2.saves.priseBuff5[idShip - 1]; countOrs = Math.Abs(YG2.saves.priseBuff5[idShip - 1]).ToString().Length; break;
        }

        for (int i = 0; i < 3; i++) panel.GetChild(i).gameObject.SetActive(i == countOrs - 1);



        if( countOrs == 1)
        {
            
            price = PriseOre(buff, allPrice, idShip == 8 ? 0 : idShip);
            panel.GetChild(0).gameObject.SetActive(true);
            panel.GetChild(0).GetComponent<Image>().sprite = icone[allPrice - 1];
            panel.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = FormatGold(price);
        }
        if (countOrs == 2)
        {
            int price001 = allPrice % 10;
            int price010 = allPrice / 10;
            price = PriseOre(buff, price001, idShip == 8 ? 0 : idShip);
            panel.GetChild(0).gameObject.SetActive(true);
            panel.GetChild(0).GetComponent<Image>().sprite = icone[price001 - 1];
            panel.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = FormatGold(price);

            price = PriseOre(buff, price010, idShip == 8 ? 0 : idShip);
            panel.GetChild(1).gameObject.SetActive(true);
            panel.GetChild(1).GetComponent<Image>().sprite = icone[price010 - 1];
            panel.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = FormatGold(price);
        }
        if (countOrs == 3)
        {
            int price100 = allPrice / 100;
            int price001 = allPrice % 10;
            int price010 = allPrice / 10 % 10;

            price = PriseOre(buff, price001, idShip == 8 ? 0 : idShip);
            panel.GetChild(0).gameObject.SetActive(true);
            panel.GetChild(0).GetComponent<Image>().sprite = icone[price001 - 1];
            panel.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = FormatGold(price);

            price = PriseOre(buff, price010, idShip == 8 ? 0 : idShip);
            panel.GetChild(1).gameObject.SetActive(true);
            panel.GetChild(1).GetComponent<Image>().sprite = icone[price010 - 1];
            panel.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = FormatGold(price);

            price = PriseOre(buff, price100, idShip == 8 ? 0 : idShip);
            panel.GetChild(2).gameObject.SetActive(true);
            panel.GetChild(2).GetComponent<Image>().sprite = icone[price100 - 1];
            panel.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = FormatGold(price);
        }

        sliderPlanet.gameObject.SetActive(false);
        textPlanet.gameObject.SetActive(false);
        if (idShip != 8 && YG2.saves.countBuyPlanet > idShip && menegerUI.planet)
        {
            sliderPlanet.gameObject.SetActive(true);
            textPlanet.gameObject.SetActive(true);
        }

        int buffCount = 0;

        switch (idBuff)
        {
            case 1: buffCount = YG2.saves.countBuffs1[idShip - 1]; break;
            case 2: buffCount = YG2.saves.countBuffs2[idShip - 1]; break;
            case 3: buffCount = YG2.saves.countBuffs3[idShip - 1]; break;
            case 4: buffCount = YG2.saves.countBuffs4[idShip - 1]; break;
            case 5: buffCount = YG2.saves.countBuffs5[idShip - 1]; break;
        }

        panelBuff.textPowerBuff[idBuff - 1].text = (buffCount * 13).ToString();

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
                return Lange.Text(22);

            case 1:
                return Lange.Text(23);

            case 2:
                return Lange.Text(24);

            case 3:
                return Lange.Text(25);

            case 4:
                return Lange.Text(26);

            case 5:
                return Lange.Text(27);

            case 6:
                return Lange.Text(28);

            case 7:
                return Lange.Text(29);

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



    public int PriseOre(int buff, int idOre, int idShip)
    {
        double baseValue = 10;
        double exponentBase = YG2.saves.indexPrice;
        int exponentOffset = buff + idShip * 15;

        double price = 0;

        switch (idOre)
        {
            case 1:
                price = baseValue * System.Math.Pow(exponentBase, exponentOffset);
                break;
            case 2:
                price = baseValue * System.Math.Pow(exponentBase, exponentOffset - 15) * 1.3;
                break;
            case 3:
                price = baseValue * System.Math.Pow(exponentBase, exponentOffset - 30) * 1.6;
                break;
            case 4:
                price = baseValue * System.Math.Pow(exponentBase, exponentOffset - 45) * 1.9;
                break;
            case 5:
                price = baseValue * System.Math.Pow(exponentBase, exponentOffset - 60) * 2.1;
                break;
            case 6:
                price = baseValue * System.Math.Pow(exponentBase, exponentOffset - 75) * 2.4;
                break;
            case 7:
                price = baseValue * System.Math.Pow(exponentBase, exponentOffset - 90) * 2.7;
                break;
            default:
                return 0;
        }

        if (YG2.saves.buffTreePrice[idShip])
        {
            price *= 0.8;
        }

        return (int)price;
    }
    #endregion

}
