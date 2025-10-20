using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class BankPanel : MonoBehaviour
{
    public GameObject bankImageObj;
    public GameObject clouse;
    public GameObject putButton;
    public GameObject takeButton;
    public TextMeshProUGUI bankAmountText;
    public int oreIndex; // от 0 до 7

    public Stats stats;

    private double percentPerHour = 100.0;
    private const int maxDeposits = 10;
    private bool bankActivated = false;

    private void Update()
    {
        if (oreIndex == 11)
        {
            bankImageObj.SetActive(true);
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
        bankImageObj.SetActive(true);
        putButton.SetActive(true);
        bankAmountText.gameObject.SetActive(true);
        clouse.SetActive(false);
        takeButton.SetActive(true);
    }

    public void PutMoney()
    {
        // Считаем, сколько уже вложено по этой руде
        int currentDeposits = 0;
        foreach (var dep in YG2.saves.deposits)
        {
            if (dep.index == oreIndex)
                currentDeposits++;
        }

        if (currentDeposits >= maxDeposits)
        {
            Debug.Log("Превышен лимит вкладов для этой руды. Больше нельзя вкладывать.");
            return;
        }

        long toDeposit = (long)YG2.saves.countOre[oreIndex];
        if (toDeposit <= 0)
        {
            Debug.Log("Нет руды для вклада.");
            return;
        }

        long unixNow = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        YG2.saves.deposits.Add(new Deposit
        {
            index = oreIndex,       // ← Исправлено: не 3, а oreIndex!
            amount = toDeposit,
            timeUnix = unixNow
        });

        YG2.saves.countOreBank[oreIndex] += toDeposit;
        YG2.saves.countOre[oreIndex] = 0;

        Debug.Log($"Вложение успешно. Всего вкладов по руде {oreIndex}: {currentDeposits + 1}");
        YG2.SaveProgress();
    }

    public void TakeMoney()
    {
        long totalWithPercent = 0;
        long unixNow = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        var depositsToRemove = new List<Deposit>();

        // Проходим только по вкладам текущей руды
        foreach (var dep in YG2.saves.deposits)
        {
            if (dep.index == oreIndex)
            {
                double hours = (unixNow - dep.timeUnix) / 3600.0;
                double percent = 1.0 + percentPerHour * hours;
                long withPercent = (long)Math.Floor(dep.amount * percent);
                totalWithPercent += withPercent;
                depositsToRemove.Add(dep);
            }
        }

        if (depositsToRemove.Count == 0)
        {
            Debug.Log("Нет вкладов для снятия по этой руде.");
            return;
        }

        // Добавляем деньги игроку
        YG2.saves.countOre[oreIndex] += totalWithPercent;
        YG2.saves.countOreBank[oreIndex] = 0;

        // Удаляем только вклады текущей руды
        foreach (var dep in depositsToRemove)
        {
            YG2.saves.deposits.Remove(dep);
        }

        Debug.Log($"Снято: {stats.FormatGold(totalWithPercent)} по руде {oreIndex}");
        YG2.SaveProgress();
    }

    private void RefreshDisplay()
    {
        long totalDeposit = 0;
        long totalWithPercent = 0;
        long unixNow = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        bool hasDeposits = false;

        foreach (var dep in YG2.saves.deposits)
        {
            if (dep.index == oreIndex)
            {
                hasDeposits = true;
                double hours = (unixNow - dep.timeUnix) / 3600.0;
                double percent = 1.0 + percentPerHour * hours;
                long withPercent = (long)Math.Floor(dep.amount * percent);

                totalDeposit += dep.amount;
                totalWithPercent += withPercent;
            }
        }

        if (hasDeposits)
        {
            long profit = totalWithPercent - totalDeposit;
            bankAmountText.text = Lange.Text(74) + stats.FormatGold(totalDeposit)+ "\n" + Lange.Text(75) + stats.FormatGold(profit);
        }
        else
        {
            bankAmountText.text = Lange.Text(74) + 0 + "\n" + Lange.Text(75) + 0;
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