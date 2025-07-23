using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stats : MonoBehaviour
{
    public int maxShip;
    public int nowShip;
    public int countBuyPlanet = 1;

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
    public List<Transform> textShip1 = new List<Transform>();
    public List<Transform> textShip2 = new List<Transform>();
    public List<Transform> textShip3 = new List<Transform>();
    public List<Transform> textShip4 = new List<Transform>();
    public List<Transform> textShip5 = new List<Transform>();
    public List<Transform> textShip6 = new List<Transform>();
    public List<Transform> textShip7 = new List<Transform>();

    public List<Sprite> icone = new List<Sprite>();

    private float[] chance2 = { 60 , 40 };
    private float[] chance3 = { 50 , 30, 20 };
    private float[] chance4 = { 42.3f , 32.3f , 18.5f, 6.9f };
    private float[] chance5 = { 38.0f, 27.0f, 18.0f, 11.5f, 5.5f };
    private float[] chance6 = { 34.0f, 24.0f, 16.5f, 10.5f, 6.5f, 3.5f };
    private float[] chance7 = { 30.5f, 21.5f, 15.0f, 10.0f, 6.5f, 4.0f, 2.5f };
    private float[] chance8 = { 27.5f, 19.5f, 14.0f, 10.0f, 6.5f, 4.5f, 3.0f, 2.0f };

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
    //public void ButtomSetMaxCloudShip(int idShip)
    //{
    //    print(idShip);
    //    int cost = (int)(10 * Mathf.Pow(indexUp, costShipCloudMax[idShip]));
    //    costShipCloudMax[idShip]++;
    //    shipCloudMax[idShip] = cost;
    //    planats[idShip].cloudShipNeed = cost;
    //    ResetPrice();
    //}

    //public void ButtomSetMaxbankPlanet(int idShip)
    //{
    //    int cost = (int)(10 * Mathf.Pow(indexUp, costShipBankMax[idShip]));
    //    costShipBankMax[idShip]++;
    //    shipBankMax[idShip] = cost;
    //    planats[idShip].bankMax = cost;
    //    ResetPrice();
    //}

    //public void ButtonSetSpeedShip(int idShip)
    //{
    //    int cost = (int)(10 * Mathf.Pow(indexUp, costShipSpeed[idShip]));
    //    costShipSpeed[idShip]++;
    //    shipSpeed[idShip] = cost;
    //    ResetPrice();
    //}

    //public void ButtonSetAttack(int idShip)
    //{
    //    int cost = (int)(10 * Mathf.Pow(indexUp, costShipAttack[idShip]));
    //    costShipAttack[idShip]++;
    //    shipAttack[idShip] = cost;
    //    ResetPrice();
    //}

    //public void ButtonSetHP(int idShip)
    //{
    //    int cost = (int)(10 * Mathf.Pow(indexUp, costShipHP[idShip]));
    //    costShipHP[idShip]++;
    //    shipHP[idShip] = cost;
    //    ResetPrice();
    //}

    //public void ButtonSetHPRegen(int idShip)
    //{
    //    int cost = (int)(10 * Mathf.Pow(indexUp, costShipHPRegen[idShip]));
    //    costShipHPRegen[idShip]++;
    //    shipHPRegen[idShip] = cost;
    //    ResetPrice();
    //}
    #endregion

    #region Цены
    public void ResetPrice(Transform trans)
    {
        SelectByWeight(chance3);
        int count = RandomCountOre();
        print("Количество руд = " + count);


        if(count == 1)                           // Если 1 ресурс
        {
            int idOre = RandomOre();
            int price = PriseOre(costShipCloudMax[0], idOre);
            trans.GetChild(0).GetChild(0).GetComponent<Image>().sprite = icone[idOre];
            trans.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = price + "";

            for (int i = 0; i < 3; i++)
            {
                trans.GetChild(i).gameObject.SetActive(false);
            }
            trans.GetChild(0).gameObject.SetActive(true);
        }
        if (count == 2)                            // Если 2 ресурс
        {
            int idOre = RandomOre();
            int idOre1 = 0;
            int price = PriseOre(costShipCloudMax[0], idOre);
            trans.GetChild(1).GetChild(0).GetComponent<Image>().sprite = icone[idOre];
            trans.GetChild(1).GetChild(2).GetComponent<TextMeshProUGUI>().text = price + "";

            while (true)
            {
                idOre1 = RandomOre();
                if(idOre1 != idOre)
                break;
            }
            price = PriseOre(costShipCloudMax[0], idOre1);
            trans.GetChild(1).GetChild(1).GetComponent<Image>().sprite = icone[idOre1];
            trans.GetChild(1).GetChild(3).GetComponent<TextMeshProUGUI>().text = price + "";

            for (int i = 0; i < 3; i++)
            {
                trans.GetChild(i).gameObject.SetActive(false);
            }
            trans.GetChild(1).gameObject.SetActive(true);
        }



        if (count == 3)                            // Если 3 ресурс
        {
            int idOre = RandomOre();
            int idOre1 = 0;
            int idOre2 = 0;
            int price = PriseOre(costShipCloudMax[0], idOre);
            trans.GetChild(2).GetChild(0).GetComponent<Image>().sprite = icone[idOre];
            trans.GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = price + "";

            while (true)
            {
                idOre1 = RandomOre();
                if (idOre1 != idOre)
                    break;
            }
            price = PriseOre(costShipCloudMax[0], idOre1);
            trans.GetChild(2).GetChild(1).GetComponent<Image>().sprite = icone[idOre1];
            trans.GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = price + "";

            while (true)
            {
                idOre2 = RandomOre();
                if (idOre2 != idOre && idOre2 != idOre1)
                    break;
            }
            price = PriseOre(costShipCloudMax[0], idOre2);
            trans.GetChild(2).GetChild(2).GetComponent<Image>().sprite = icone[idOre2];
            trans.GetChild(2).GetChild(5).GetComponent<TextMeshProUGUI>().text = price + "";

            for (int i = 0; i < 3; i++)
            {
                trans.GetChild(i).gameObject.SetActive(false);
            }
            trans.GetChild(2).gameObject.SetActive(true);
        }
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
        int chance = Random.Range(0, 100);
        if (countBuyPlanet == 1) return 1;
        else if(countBuyPlanet == 2)
        {
            if (chance < 60) return 2;
            else return 1;
        }
        else if (countBuyPlanet == 3)
        {
            if (chance < 50) return 3;
            else if (chance < 80) return 2;
            else return 1;
        }


        if (chance < 40) return 2;
        else if (chance < 60) return 1;
        else if (chance < 80) return 3;
        else  return 4;
    }

    public int RandomOre()
    {
        int chance = Random.Range(0, 100);
        if (countBuyPlanet == 1) return 0;
        else if(countBuyPlanet == 2) return SelectByWeight(chance2);
        else if (countBuyPlanet == 3) return SelectByWeight(chance3);
        else if (countBuyPlanet == 4) return SelectByWeight(chance4);
        else if (countBuyPlanet == 5) return SelectByWeight(chance5);
        else if (countBuyPlanet == 6) return SelectByWeight(chance6);
        else if (countBuyPlanet == 7) return SelectByWeight(chance7);
        else  return SelectByWeight(chance8);


    }

    public int SelectByWeight(float[] weights)
    {
        float total = 0f;
        float roll = Random.Range(0f, 100f);

        for (int i = 0; i < weights.Length; i++)
        {
            total += weights[i];
            if (roll < total)
            {

                return i;
            }
        }

        return 10000; // на случай ошибки 
    }

    public int PriseOre(int buff, int idOre)
    {
        if (idOre == 0) return (int)(10 * Mathf.Pow(indexPrice, buff - 30) * 1.4f);
        if (idOre == 1) return (int)(10 * Mathf.Pow(indexPrice, buff - 15) * 1.2f);
        if (idOre == 2) return (int)(10 * Mathf.Pow(indexPrice, buff));
        if (idOre == 3) return (int)(10 * Mathf.Pow(indexPrice, buff - 45) * 1.6f);
        if (idOre == 4) return (int)(10 * Mathf.Pow(indexPrice, buff - 60) * 1.8f);
        if (idOre == 5) return (int)(10 * Mathf.Pow(indexPrice, buff - 75) * 2f);
        if (idOre == 6) return (int)(10 * Mathf.Pow(indexPrice, buff - 90) * 2.2f);
        if (idOre == 7) return (int)(10 * Mathf.Pow(indexPrice, buff - 105) * 2.4f);
        return 0;    
    }
    #endregion
}


