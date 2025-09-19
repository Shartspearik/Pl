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



        [Header("Колличество покупок")]
        //public List<int> costShipBankMax = new List<int>() { 13, 2, 4, 5, 6, 12, 4, 12 };

        public int[][] countBuffing = new int[][]
        {
        new int[] { 9, 11, 13, 12, 14, 13, 1, 12 },
        new int[] { 13, 12, 11, 14, 2, 12, 1, 13 },
        new int[] { 3, 2, 3, 4, 5, 6, 7, 8 }
        };

        public int[][] savePrice = new int[][]
        {
        new int[] { 1, 1, 1, 1, 1, 1, 1, 1 },
        new int[] { 1, 1, 1, 1, 1, 1, 1, 1 },
        new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }
        };


        [Header("Колличество ")]
        public List<double> countOre = new List<double>() { 100, 10000000, 10000000, 10000000, 10000000, 10000000, 10000000, 10000000 };


        public float indexUp = 1;
        public float indexPrice = 1.2f;
    }
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
        new int[] { 15, 1, 1, 1, 1, 1, 1, 1 },
        new int[] { 30, 15, 1, 1, 1, 1, 1, 1 },
        new int[] { 45, 30, 15, 1, 1, 1, 1, 1 },
        new int[] { 60, 45, 30, 15, 1, 1, 1, 1 },
        new int[] { 60, 60, 45, 30, 15, 1, 1, 1 },
        new int[] { 60, 60, 60, 45, 30, 15, 1, 1 },
        new int[] { 60, 60, 60, 60, 45, 30, 15, 1 }
        };
    public PanelBuff panelBuff;


    public List<Planet> planats = new List<Planet>();

    public MenegerUI menegerUI;

    public Transform content;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            panelBuff.sliders[0].value = 20;
            //YG2.SaveProgress();
        }
    }

    private void Start()
    {
        YGInsides.LoadProgress();
        for (int q = 1; q < 4; q++)
        {
                ResetPrice(1 * 10 + q);
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
        panelBuff.price[id].SetActive(false);
        panelBuff.panelLevelUp[id].gameObject.SetActive(true);
        panelBuff.panelLevelUp[id].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Откройте " + (YG2.saves.countBuyPlanet + 1) + " планету";
    }
    #region Конопки бафов


    public void CheckBuff15(int idShip, int idBuff)
    {
        Debug.Log(
                    "Число кораблей = " + string.Join(", ", YG2.saves.countBuffing[0]) + "          " +
                    "Скорость кораблей = " + string.Join(", ", YG2.saves.countBuffing[1]) + "          " +
                    "Емкость кораблей = " + string.Join(", ", YG2.saves.countBuffing[2]));


        int index = idShip - 1;
        bool countOk = YG2.saves.countBuffing[0][index] % 15 == 0;
        bool speedOk = YG2.saves.countBuffing[1][index] % 15 == 0;
        bool cloudMaxOk = YG2.saves.countBuffing[2][index] % 15 == 0;

        if (countOk && idBuff == 1)
        {
            PrintBuyPlanet(idBuff);

        }
        if (speedOk && idBuff == 2)
        {
            PrintBuyPlanet(idBuff);
        }
        if (cloudMaxOk && idBuff == 3)
        {
            PrintBuyPlanet(idBuff);
        }

        var pattern = patterns[YG2.saves.countReadyPlanet];
        if (YG2.saves.countBuffing[0].SequenceEqual(pattern) &&
            YG2.saves.countBuffing[1].SequenceEqual(pattern) &&
            YG2.saves.countBuffing[2].SequenceEqual(pattern))
        {
            YG2.saves.countReadyPlanet++;
            content.GetChild(YG2.saves.countBuyPlanet - 1).GetChild(1).gameObject.SetActive(true);
            content.GetChild(YG2.saves.countBuyPlanet - 1).GetChild(4).gameObject.SetActive(true);
        }
    }



    public void Buffing(int id)
    {
        int idShip = id / 10;       // Номер планеты
        int idBuff = id % 10;       // Номер бафа
        int originalOres = 0;
        int countBuff = 0;

        originalOres = YG2.saves.savePrice[idBuff - 1][idShip];
        countBuff = YG2.saves.countBuffing[idBuff - 1][idShip];

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

            YG2.saves.countBuffing[idBuff - 1][idShip - 1]++;

            while (ores != 0)
            {
                int q = ores % 10;      // Получаем цифру (тип руды)
                ores /= 10;
                YG2.saves.countOre[q - 1] -= PriseOre(countBuff, q);
                menegerUI.OreTextPanel(q - 1);
            }
            
            //CheckUnlockBuff();
            ResetPrice(id);
            CheckBuff15(idShip, idBuff);
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
        Transform panel = panelBuff.price[idBuff - 1].transform; 

        for (int i = 0; i < 3; i++)
            panel.GetChild(i).gameObject.SetActive(i == countOre - 1);

        int buff = YG2.saves.countBuffing[idBuff - 1][idShip] + (idShip - 1) * 15;


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
            panelBuff.price[idBuff - 1].transform.GetChild(i).gameObject.SetActive(true);
            panelBuff.price[idBuff - 1].transform.GetChild(i).GetComponent<Image>().sprite = icone[idOre1 - 1];
            panelBuff.price[idBuff - 1].transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = price1.ToString();
        }
        YG2.saves.savePrice[id % 10 - 1][idShip] = saveOre;

        panelBuff.sliders[0].value = YG2.saves.countBuffing[id % 10 - 1][idShip - 1];
        panelBuff.textPowerBuff[0].text = (YG2.saves.countBuffing[id % 10 - 1][idShip - 1] * 13).ToString();
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
