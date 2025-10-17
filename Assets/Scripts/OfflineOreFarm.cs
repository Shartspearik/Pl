using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class OfflineOreFarm : MonoBehaviour
{
    public GameObject panelAFK;
    public Stats stats;
    public GameObject[] panelOre;
    public long[] ores = new long[] {0, 0, 0, 0, 0, 0, 0, 0};

    private const string LastExitTimeKey = "LastExitTime";
    private int orePerSecond = 1; // Количество руды в секунду офлайн

    // Порог времени в секундах. Можно менять, например, через инспектор или параметры.
    public int MinOfflineSeconds = 60;

    void Start()
    {
        stats = GetComponent<Stats>();
        YG2.onHideWindowGame += OnGameHide;
        foreach (var buff in YG2.saves.buffTreeAFKfarm)
        {
            if (buff)
            {
                CalculateOfflineOre();
                return;
            }
        }
        
    }

    private void OnGameHide()
    {
        long currentTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        PlayerPrefs.SetString(LastExitTimeKey, currentTime.ToString());
        PlayerPrefs.Save();
    }

    private void CalculateOfflineOre()
    {
        if (PlayerPrefs.HasKey(LastExitTimeKey))
        {
            string savedTimeStr = PlayerPrefs.GetString(LastExitTimeKey);
            if (long.TryParse(savedTimeStr, out long lastExitTime))
            {
                long currentTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                //long offlineSeconds = 1000000;
                long offlineSeconds = currentTime - lastExitTime;

                if (offlineSeconds < MinOfflineSeconds)
                {
                    Debug.Log($"Мало времени прошло: {offlineSeconds} секунд. Нужно минимум {MinOfflineSeconds} сек для фарма!");
                }
                else
                {
                    int earnedOre = (int)(offlineSeconds * orePerSecond);
                    SetOre(offlineSeconds);
                    Debug.Log($"Вы были офлайн {offlineSeconds} сек. Начислено руды: {earnedOre}");
                    
                }
            }
        }
        else
        {
            Debug.Log("Это ваш первый заход, офлайн руды нет.");
        }
    }

    private void OnDestroy()
    {
        YG2.onHideWindowGame -= OnGameHide;
    }

    public void SetOre(long sec)
    {
        panelAFK.SetActive(true);
        panelAFK.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = Lange.Text(65) + SecondsToReadableString(sec);
        for (int i = 0; i < 8; i++)
        {
            if (YG2.saves.buffTreeAFKfarm[i])
            {
                panelOre[i].SetActive(true);
                double ore1 = i == 0 ? Parametrs.CloudMine(0) : Parametrs.CloudShip(i - 1);

                int ore = (int)(sec * ore1 * 0.5f);
                ores[i] = ore;
                panelOre[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = stats.FormatGold(ore);
            }
        }
    }
    public string SecondsToReadableString(long totalSeconds)
    {
        long days = totalSeconds / 86400;
        long hours = (totalSeconds % 86400) / 3600;
        long minutes = (totalSeconds % 3600) / 60;
        long seconds = totalSeconds % 60;

        List<string> parts = new List<string>();
        if (days > 0) parts.Add($"{days} d");
        if (hours > 0) parts.Add($"{hours} h");
        if (minutes > 0) parts.Add($"{minutes} min");
        if (seconds > 0 || parts.Count == 0) parts.Add($"{seconds} sek");

        return string.Join(" ", parts);
    }

    public void ButtonCloudAFK()
    {
        for (int i = 0; i < 8; i++)
        {
            YG2.saves.countOre[i] += ores[i];
            YG2.saves.liderBoard += ores[i] * Mathf.Pow(1.3f, i) / 50;
        }
        YG2.SaveProgress();
        panelAFK.SetActive(false);
    }
}
