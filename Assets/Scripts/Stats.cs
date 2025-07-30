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
    public List<int> shipCount = new List<int>();
    public List<int> shipBankMax = new List<int>();
    public List<int> shipSpeed = new List<int>();



    [Header("Колличество покупок")]
    public List<int> costShipCloudMax = new List<int>();
    public List<int> costShipCount = new List<int>();
    public List<int> costShipBankMax = new List<int>();
    public List<int> costShipSpeed = new List<int>();


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
    private float[] chance6 = { 39.0f, 24.0f, 16.5f, 10.5f, 6.5f, 3.5f };
    private float[] chance7 = { 40.5f, 21.5f, 15.0f, 10.0f, 6.5f, 4.0f, 2.5f };
    private float[] chance8 = { 40.5f, 19.5f, 14.0f, 10.0f, 6.5f, 4.5f, 3.0f, 2.0f };

    public List<Planet> planats = new List<Planet>();
    public List<int> ore = new List<int>();
    public MenegerUI menegerUI;

    public float indexUp;
    public float indexPrice;

    private void Start()
    {
        foreach (Transform item in textShip1)
        {
            ResetPrice(item);
        }
        foreach (Transform item in textShip2)
        {
            ResetPrice(item);
        }
        foreach (Transform item in textShip3)
        {
            ResetPrice(item);
        }
        foreach (Transform item in textShip4)
        {
            ResetPrice(item);
        }
        foreach (Transform item in textShip5)
        {
            ResetPrice(item);
        }
        foreach (Transform item in textShip6)
        {
            ResetPrice(item);
        }
        foreach (Transform item in textShip7)
        {
            ResetPrice(item);
        }
    }

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
    #endregion

    public void Buffing2(Transform trans, int idOre, int price)
    {
        int idShip = FindNameId(trans.name, 0) - 1;
        int idBuff = FindNameId(trans.name, 1);
        if (idBuff == 1)
        {
            costShipCount[idShip]++;
            shipCount[idShip]++;
            ore[idOre] -= price;

        }
        if (idBuff == 2)
        {
            costShipSpeed[idShip]++;
            shipSpeed[idShip]++;
            ore[idOre] -= price;

        }
        if (idBuff == 3)
        {
            costShipCloudMax[idShip]++;
            shipCloudMax[idShip]++;
            ore[idOre] -= price;

        }
    }

    #region Конопки бафов
    public void Buffing(Transform trans)
    {
        if (trans.GetChild(0).gameObject.activeSelf)
        {
            int idOre1 = FindIconeInOre(trans.GetChild(0).GetChild(0).GetComponent<Image>().sprite);
            int price1 = int.Parse(trans.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text);
            if (ore[idOre1] >= price1)
            {
                Buffing2(trans, idOre1, price1);
                ResetPrice(trans);
            }
            else
            {
            }
        }
        if (trans.GetChild(1).gameObject.activeSelf)
        {
            int idOre1 = FindIconeInOre(trans.GetChild(1).GetChild(0).GetComponent<Image>().sprite);
            int price1 = int.Parse(trans.GetChild(1).GetChild(2).GetComponent<TextMeshProUGUI>().text);

            int idOre2 = FindIconeInOre(trans.GetChild(1).GetChild(1).GetComponent<Image>().sprite);
            int price2 = int.Parse(trans.GetChild(1).GetChild(3).GetComponent<TextMeshProUGUI>().text);

            if (ore[idOre1] >= price1 && ore[idOre2] >= price2)
            {
                Buffing2(trans, idOre1, price1);
                Buffing2(trans, idOre2, price2);
                ResetPrice(trans);
            }
            else
            {
            }
        }
        if (trans.GetChild(2).gameObject.activeSelf)
        {
            int idOre1 = FindIconeInOre(trans.GetChild(2).GetChild(0).GetComponent<Image>().sprite);
            int price1 = int.Parse(trans.GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text);

            int idOre2 = FindIconeInOre(trans.GetChild(2).GetChild(1).GetComponent<Image>().sprite);
            int price2 = int.Parse(trans.GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text);

            int idOre3 = FindIconeInOre(trans.GetChild(2).GetChild(2).GetComponent<Image>().sprite);
            int price3 = int.Parse(trans.GetChild(2).GetChild(5).GetComponent<TextMeshProUGUI>().text);

            if (ore[idOre1] >= price1 && ore[idOre2] >= price2 && ore[idOre3] >= price3)
            {
                Buffing2(trans, idOre1, price1);
                Buffing2(trans, idOre2, price2);
                Buffing2(trans, idOre3, price3);
                ResetPrice(trans);
            }
            else
            {

            }
        }
    }
    #endregion

    #region Цены
    public void ResetPrice(Transform trans)
    {
        int count = RandomCountOre();
        int cost = FindName(trans);

        if(count == 1)                           // Если 1 ресурс
        {
            int idOre = RandomOre();
            int price = PriseOre(cost, idOre);
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
            int price = PriseOre(cost, idOre);
            trans.GetChild(1).GetChild(0).GetComponent<Image>().sprite = icone[idOre];
            trans.GetChild(1).GetChild(2).GetComponent<TextMeshProUGUI>().text = price + "";

            while (true)
            {
                idOre1 = RandomOre();
                if(idOre1 != idOre)
                break;
            }
            price = PriseOre(cost, idOre1);
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
            int price = PriseOre(cost, idOre);
            trans.GetChild(2).GetChild(0).GetComponent<Image>().sprite = icone[idOre];
            trans.GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = price + "";

            while (true)
            {
                idOre1 = RandomOre();
                if (idOre1 != idOre)
                    break;
            }
            price = PriseOre(cost, idOre1);
            trans.GetChild(2).GetChild(1).GetComponent<Image>().sprite = icone[idOre1];
            trans.GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = price + "";

            while (true)
            {
                idOre2 = RandomOre();
                if (idOre2 != idOre && idOre2 != idOre1)
                    break;
            }
            price = PriseOre(cost, idOre2);
            trans.GetChild(2).GetChild(2).GetComponent<Image>().sprite = icone[idOre2];
            trans.GetChild(2).GetChild(5).GetComponent<TextMeshProUGUI>().text = price + "";

            for (int i = 0; i < 3; i++)
            {
                trans.GetChild(i).gameObject.SetActive(false);
            }
            trans.GetChild(2).gameObject.SetActive(true);
        }
    }

    public int FindNameId(string nameShip, int id)
    {
        string numbersPart = nameShip.Replace("Price", ""); // "1_2"

        // Разобьём строку по символу подчёркивания '_'
        string[] parts = numbersPart.Split('_');
        return int.Parse(parts[id]);
    }

    public int FindName(Transform trans)
    {
        if (trans.name == "Price1_1") return costShipCount[0];
        if (trans.name == "Price2_1") return costShipCount[1];
        if (trans.name == "Price3_1") return costShipCount[2];
        if (trans.name == "Price4_1") return costShipCount[3];
        if (trans.name == "Price5_1") return costShipCount[4];
        if (trans.name == "Price6_1") return costShipCount[5];
        if (trans.name == "Price7_1") return costShipCount[6];

        if (trans.name == "Price1_2") return costShipSpeed[0];
        if (trans.name == "Price2_2") return costShipSpeed[1];
        if (trans.name == "Price3_2") return costShipSpeed[2];
        if (trans.name == "Price4_2") return costShipSpeed[3];
        if (trans.name == "Price5_2") return costShipSpeed[4];
        if (trans.name == "Price6_2") return costShipSpeed[5];
        if (trans.name == "Price7_2") return costShipSpeed[6];

        if (trans.name == "Price1_3") return costShipCloudMax[0];
        if (trans.name == "Price2_3") return costShipCloudMax[1];
        if (trans.name == "Price3_3") return costShipCloudMax[2];
        if (trans.name == "Price4_3") return costShipCloudMax[3];
        if (trans.name == "Price5_3") return costShipCloudMax[4];
        if (trans.name == "Price6_3") return costShipCloudMax[5];
        if (trans.name == "Price7_3") return costShipCloudMax[6];


        return 10000;
    }

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
        int chance = Random.Range(0, 100);
        if (countBuyPlanet == 1) return 1;
        else if(countBuyPlanet == 2)
        {
            if (chance < 60) return 2;
            else return 1;
        }
        else if (countBuyPlanet >= 3)
        {
            if (chance < 50) return 3;
            else if (chance < 80) return 2;
            else return 1;
        }
        else
            return 0;
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
        if (idOre == 0) return (int)(10 * Mathf.Pow(indexPrice, buff));
        if (idOre == 1) return (int)(10 * Mathf.Pow(indexPrice, buff - 15) * 1.4f);
        if (idOre == 2) return (int)(10 * Mathf.Pow(indexPrice, buff - 30) * 1.2f);
        if (idOre == 3) return (int)(10 * Mathf.Pow(indexPrice, buff - 45) * 1.6f);
        if (idOre == 4) return (int)(10 * Mathf.Pow(indexPrice, buff - 60) * 1.8f);
        if (idOre == 5) return (int)(10 * Mathf.Pow(indexPrice, buff - 75) * 2f);
        if (idOre == 6) return (int)(10 * Mathf.Pow(indexPrice, buff - 90) * 2.2f);
        return 0;    
    }
    #endregion
}


