using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class BankPanel : MonoBehaviour
{
    public GameObject bankImageObj;
    public GameObject clouse;
    public GameObject putButton;
    public GameObject takeButton;
    public TextMeshProUGUI bankAmountText;
    public int oreIndex;

    public Stats stats;

    private double percentPerHour = 1;
    private const int maxDeposits = 10;
    private bool bankActivated = false;

    private void Update()
    {
        if (oreIndex == 11)
        {
            putButton.SetActive(false);
            bankAmountText.gameObject.SetActive(false);
            clouse.SetActive(true);
            takeButton.SetActive(false);
            bankActivated = false;
            return;
        }
        if (!bankActivated && YG2.saves.buffTreeECO[oreIndex])
        {
            ActivateBank();
            bankActivated = true;
        }
        RefreshDisplay();
    }

    public void ActivateBank()
    {
        putButton.SetActive(true);
        bankAmountText.gameObject.SetActive(true);
        clouse.SetActive(false);
        takeButton.SetActive(true);
        RefreshDisplay();
    }

    public void PutMoney()
    {
        if (YG2.saves.deposits.Count >= maxDeposits)
        {
            Debug.Log("Превышен лимит вкладов. Больше нельзя вкладывать.");
            return;
        }

        int arrayIndex = YG2.saves.deposits.FindIndex(d => d.index == 3);
        int targetIndex = (arrayIndex != -1) ? arrayIndex : 3;

        long toDeposit = (long)YG2.saves.countOre[targetIndex];

        if (toDeposit > 0)
        {
            long unixNow = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            YG2.saves.deposits.Add(new Deposit { index = 3, amount = toDeposit, timeUnix = unixNow });
            YG2.saves.countOreBank[targetIndex] += toDeposit;
            YG2.saves.countOre[targetIndex] = 0;

            Debug.Log($"Вложение успешно. Количество вкладов: {YG2.saves.deposits.Count}");
        }

        YG2.SaveProgress();
    }

    public void TakeMoney()
    {
        long totalWithPercent = 0;
        long unixNow = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        foreach (var dep in YG2.saves.deposits)
        {
            double hours = (unixNow - dep.timeUnix) / 3600.0;
            double percent = 1 + percentPerHour * hours;
            long withPercent = (long)Math.Floor(dep.amount * percent);
            totalWithPercent += withPercent;
        }

        YG2.saves.countOre[oreIndex] += totalWithPercent;
        YG2.saves.countOreBank[oreIndex] = 0;
        YG2.saves.deposits.Clear();
        YG2.SaveProgress();
    }

    private void RefreshDisplay()
    {
        long totalDeposit = 0;
        long totalWithPercent = 0;
        long unixNow = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        if(YG2.saves.deposits.Exists(d => d.index == oreIndex))
        {
            var dep = YG2.saves.deposits[oreIndex];
            double hours = (unixNow - dep.timeUnix) / 3600.0;
            double percent = 1 + percentPerHour * hours;
            long withPercent = (long)Math.Floor(dep.amount * percent);

            totalDeposit += dep.amount;
            totalWithPercent += withPercent;

            long profit = totalWithPercent - totalDeposit;
            bankAmountText.text = $"В банке: {stats.FormatGold(totalWithPercent)}\nЗаработано: {stats.FormatGold(profit)}";
        }
        else
        {
            bankAmountText.text = $"В банке: {0}\nЗаработано: {0}";
        }
    }

    [Serializable]
    public class Deposit
    {
        public long amount;
        public int index;
        public long timeUnix; // время в unix секундах
    }
}
