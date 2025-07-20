using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    public int maxShip;
    public int nowShip;


    [Header("Параметры")]
    public List<int> shipCloudMax = new List<int>();
    public List<int> shipBankMax = new List<int>();
    public List<int> shipSpeed = new List<int>();
    public List<int> shipAttack = new List<int>();
    public List<int> shipHP = new List<int>();
    public List<int> shipHPRegen = new List<int>();


    [Header("Колличество покупок")]
    public List<int> costShipCloudMax = new List<int>();
    public List<int> costShipBankMax = new List<int>();
    public List<int> costShipSpeed = new List<int>();
    public List<int> costShipAttack = new List<int>();
    public List<int> costShipHP = new List<int>();
    public List<int> costShipHPRegen = new List<int>();

    [Header("Текст цен")]
    public List<TextMeshProUGUI> textShip1 = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> textShip2 = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> textShip3 = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> textShip4 = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> textShip5 = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> textShip6 = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> textShip7 = new List<TextMeshProUGUI>();

    public List<Planet> planats = new List<Planet>();
    public List<int> ore = new List<int>();
    public MenegerUI menegerUI;

    public float indexUp;
    public float indexPrice;


    #region Обновление статов
    public void SetCloud(int idShip)
    {
        ore[idShip] += shipCloudMax[idShip];
        menegerUI.OreTextPanel(idShip);
    }

    public void SetMaxCloudShip(int count, int idShip)
    {
        shipCloudMax[idShip] += count;
        planats[idShip].cloudShipNeed += count;
    }

    public void SetMaxbankPlanet(int count, int idShip)
    {
        shipBankMax[idShip] += count;
        planats[idShip].bankMax += count;
    }

    public void SetSpeedShip(int count, int idShip)
    {
        shipSpeed[idShip] += count;
    }

    public void SetAttack(int count, int idShip)
    {
        shipAttack[idShip] += count;
    }

    public void SetHP(int count, int idShip)
    {
        shipHP[idShip] += count;
    }

    public void SetHPRegen(int count, int idShip)
    {
        shipHPRegen[idShip] += count;
    }
#endregion


    #region Конопки бафов
    public void ButtomSetMaxCloudShip(int idShip)
    {
        print(idShip);
        int cost = (int)(10 * Mathf.Pow(indexUp, costShipCloudMax[idShip]));
        costShipCloudMax[idShip]++;
        shipCloudMax[idShip] = cost;
        planats[idShip].cloudShipNeed = cost;
        ResetPrice();
    }

    public void ButtomSetMaxbankPlanet(int idShip)
    {
        int cost = (int)(10 * Mathf.Pow(indexUp, costShipBankMax[idShip]));
        costShipBankMax[idShip]++;
        shipBankMax[idShip] = cost;
        planats[idShip].bankMax = cost;
        ResetPrice();
    }

    public void ButtonSetSpeedShip(int idShip)
    {
        int cost = (int)(10 * Mathf.Pow(indexUp, costShipSpeed[idShip]));
        costShipSpeed[idShip]++;
        shipSpeed[idShip] = cost;
        ResetPrice();
    }

    public void ButtonSetAttack(int idShip)
    {
        int cost = (int)(10 * Mathf.Pow(indexUp, costShipAttack[idShip]));
        costShipAttack[idShip]++;
        shipAttack[idShip] = cost;
        ResetPrice();
    }

    public void ButtonSetHP(int idShip)
    {
        int cost = (int)(10 * Mathf.Pow(indexUp, costShipHP[idShip]));
        costShipHP[idShip]++;
        shipHP[idShip] = cost;
        ResetPrice();
    }

    public void ButtonSetHPRegen(int idShip)
    {
        int cost = (int)(10 * Mathf.Pow(indexUp, costShipHPRegen[idShip]));
        costShipHPRegen[idShip]++;
        shipHPRegen[idShip] = cost;
        ResetPrice();
    }
    #endregion

    #region Цены
    public void ResetPrice()
    {
        for (int i = 0; i < 6; i++)
        {
            int price = (int)(10 * Mathf.Pow(indexPrice, costShipSpeed[i]));
            textShip1[i].text = price + "";
        }
        //foreach (int id in shipBankMax)
        //{
        //    int price = (int)(10 * Mathf.Pow(indexPrice, costShipBankMax[id]));
        //    textShip2[id].text = price + "";
        //}
        //foreach (int id in shipSpeed)
        //{
        //    int price = (int)(10 * Mathf.Pow(indexPrice, costShipSpeed[id]));
        //    textShip3[id].text = price + "";
        //}
        //foreach (int id in shipAttack)
        //{
        //    int price = (int)(10 * Mathf.Pow(indexPrice, costShipAttack[id]));
        //    textShip4[id].text = price + "";
        //}
        //foreach (int id in shipHP)
        //{
        //    int price = (int)(10 * Mathf.Pow(indexPrice, costShipHP[id]));
        //    textShip5[id].text = price + "";
        //}
        //foreach (int id in shipHPRegen)
        //{
        //    int price = (int)(10 * Mathf.Pow(indexPrice, costShipHPRegen[id]));
        //    textShip6[id].text = price + "";
        //}
        //foreach (int id in shipHPRegen)
        //{
        //    int price = (int)(10 * Mathf.Pow(indexPrice, costShipHPRegen[id]));
        //    textShip6[id].text = price + "";
        //}
    }
    #endregion
}


