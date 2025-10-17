using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Shop : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI textPrice;
    public Text text;
    public MenegerUI menegerUI;
    public Stats stats;

    public GameObject[] panelFree;
    public GameObject[] panelUnLock;

    public Sprite[] iconeOre;
    public Sprite[] iconeBoost;

    public GameObject[] panelFreeGem;
    public GameObject[] panelUnLockGem;
    public TextMeshProUGUI[] textPriceGem;
    public Image[] imagesGem;
    public Image imageGem;
    public Sprite iconeGem;
    public Image iconeGemFree;
    public TextMeshProUGUI textPriceGemFree;

    private void Start()
    {
        stats = GetComponent<Stats>();
        YG2.ConsumePurchases();
        PrintShop();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F  ))
        {
            FillArrayFixedRandom(YG2.saves.countBuyPlanet);
            YG2.saves.shopTimer = 0;
            PrintShop();
        }
        for (int i = 0; i < panelFree.Length; i++) 
        {
            if (YG2.ServerTime() > YG2.saves.shopBuy[i])
            {
                panelFree[i].SetActive(true);
                panelUnLock[i].SetActive(false);
            }
        }
        for (int i = 0; i < panelFreeGem.Length; i++)
        {
            if (YG2.ServerTime() > YG2.saves.shopBuyGem[i] && YG2.saves.countBuyPlanet - i >= 1)
            {
                panelFreeGem[i].SetActive(true);
                panelUnLockGem[i].SetActive(false);
            }
        }
        if (YG2.saves.shopTimer < YG2.ServerTime())
        {
            YG2.saves.shopTimer = YG2.ServerTime() + 1800000; //30 мин
            YG2.saves.shopFree = UnityEngine.Random.Range(0, YG2.saves.countBuyPlanet);
            FillArrayFixedRandom(YG2.saves.countBuyPlanet);
            PrintShop();
            YG2.SaveProgress();
        }       
    }

    public void PrintShop()
    {
        iconeGemFree.sprite = iconeOre[YG2.saves.shopFree];
        textPrice.text = stats.FormatGold(Mathf.Pow(0.4f, YG2.saves.shopOre[YG2.saves.shopFree] + 1) * 10000 * 0.1f * YG2.saves.countBuyPlanet * 2 * Mathf.Pow(1.1f, YG2.saves.countBuffs4[YG2.saves.shopOre[YG2.saves.shopFree] == 0 ? 7 : YG2.saves.shopOre[YG2.saves.shopFree] - 1]));
        textPriceGemFree.text =stats.FormatGold(Formula(YG2.saves.shopFree, 0.1f));
        for (int i = 0; i < 5; i++)
        {
            panelFreeGem[i].SetActive(YG2.saves.countBuyPlanet - i >= 1);
            panelUnLockGem[i].SetActive(YG2.saves.countBuyPlanet - i < 1);
            float x = 0;
            switch (i)
            {
                case 0:
                    x = 0.1f;
                    break;
                case 1:
                    x = 0.4f;
                    break;
                case 2:
                    x = 0.8f;
                    break;
                case 3:
                    x = 1.3f;
                    break;
                case 4:
                    x = 2f;
                    break;
            }
            textPriceGem[i].text = stats.FormatGold(Formula(i,x));
            imagesGem[i].sprite = iconeOre[YG2.saves.shopOre[i]];
        }
    }

    private void OnEnable()
    {
        YG2.onPurchaseSuccess += SuccessPurchased;
        YG2.onPurchaseFailed += FailedPurchased;
    }

    private void OnDisable()
    {
        YG2.onPurchaseSuccess -= SuccessPurchased;
        YG2.onPurchaseFailed -= FailedPurchased;
    }

    public void SuccessPurchased(string id)
    {
        switch (id)
        {
            case "gem50":
                YG2.saves.gems += 50;
                panel.SetActive(true);
                textPrice.text = 50 + "";
                break;
            case "gem200":
                YG2.saves.gems += 300;
                panel.SetActive(true);
                textPrice.text = 300 + "";
                break;
            case "gem300":
                YG2.saves.gems += 500;
                panel.SetActive(true);
                textPrice.text = 500 + "";
                break;
            case "gem600":
                YG2.saves.gems += 1000;
                panel.SetActive(true);
                textPrice.text = 1000 + "";
                break;
            case "5":
                if (YG2.saves.gems < 5)
                {
                    menegerUI.sound.PlaySound(3);
                    menegerUI.VisualizePurchase(false, 1);
                    return;
                }
                menegerUI.sound.PlaySound(2);
                menegerUI.VisualizePurchase(true, 1);
                YG2.saves.shopBuyGem[0] = YG2.ServerTime() + 10000;
                panelFreeGem[0].SetActive(false);
                panelUnLockGem[0].SetActive(true);
                YG2.saves.gems -= 5;
                YG2.saves.countOre[YG2.saves.shopOre[0]] += Formula(0 , 0.1f);
                panel.SetActive(true);
                imageGem.sprite = iconeOre[YG2.saves.shopOre[0]];
                textPrice.text = stats.FormatGold(Formula(0, 0.1f));
                break;
            case "15":
                if (YG2.saves.gems < 15)
                {
                    menegerUI.sound.PlaySound(3);
                    menegerUI.VisualizePurchase(false, 1);
                    return;
                }
                menegerUI.sound.PlaySound(2);
                menegerUI.VisualizePurchase(true, 1);
                YG2.saves.shopBuyGem[1] = YG2.ServerTime() + 10000;
                panelFreeGem[1].SetActive(false);
                panelUnLockGem[1].SetActive(true);
                YG2.saves.gems -= 15;
                YG2.saves.countOre[YG2.saves.shopOre[1]] += Formula(1, 0.4f);
                panel.SetActive(true);
                imageGem.sprite = iconeOre[YG2.saves.shopOre[1]];
                textPrice.text = stats.FormatGold(Formula(1, 0.4f));
                break;
            case "30":
                if (YG2.saves.gems < 30)
                {
                    menegerUI.sound.PlaySound(3);
                    menegerUI.VisualizePurchase(false, 1);
                    return;
                }
                menegerUI.sound.PlaySound(2);
                menegerUI.VisualizePurchase(true, 1);
                YG2.saves.shopBuyGem[2] = YG2.ServerTime() + 10000;
                panelFreeGem[2].SetActive(false);
                panelUnLockGem[2].SetActive(true);
                YG2.saves.gems -= 30;
                YG2.saves.countOre[YG2.saves.shopOre[2]] += Formula(2, 0.8f);
                panel.SetActive(true);
                imageGem.sprite = iconeOre[YG2.saves.shopOre[2]];
                textPrice.text = stats.FormatGold(Formula(2, 0.8f));
                break;
            case "50":
                if (YG2.saves.gems < 50)
                {
                    menegerUI.sound.PlaySound(3);
                    menegerUI.VisualizePurchase(false, 1);
                    return;
                }
                menegerUI.sound.PlaySound(2);
                menegerUI.VisualizePurchase(true, 1);
                YG2.saves.shopBuyGem[3] = YG2.ServerTime() + 10000;
                panelFreeGem[3].SetActive(false);
                panelUnLockGem[3].SetActive(true);
                YG2.saves.gems -= 50;
                YG2.saves.countOre[YG2.saves.shopOre[3]] += Formula(3, 1.3f);
                panel.SetActive(true);
                imageGem.sprite = iconeOre[YG2.saves.shopOre[3]];
                textPrice.text = stats.FormatGold(Formula(3, 1.3f));
                break;
            case "100":
                if (YG2.saves.gems < 100)
                {
                    menegerUI.sound.PlaySound(3);
                    menegerUI.VisualizePurchase(false, 1);
                    return;
                }
                menegerUI.sound.PlaySound(2);
                menegerUI.VisualizePurchase(true, 1);
                YG2.saves.shopBuyGem[4] = YG2.ServerTime() + 10000;
                panelFreeGem[4].SetActive(false);
                panelUnLockGem[4].SetActive(true);
                YG2.saves.gems -= 100;
                YG2.saves.countOre[YG2.saves.shopOre[4]] += Formula(4, 2);
                panel.SetActive(true);
                imageGem.sprite = iconeOre[YG2.saves.shopOre[4]];
                textPrice.text = stats.FormatGold(Formula(4,2));
                break;
            case "auto15":
                if (YG2.saves.gems < 15)
                {
                    menegerUI.sound.PlaySound(3);
                    menegerUI.VisualizePurchase(false, 1);
                    return;
                }
                menegerUI.sound.PlaySound(2);
                menegerUI.VisualizePurchase(true, 1);
                YG2.saves.gems -= 15;
                YG2.saves.autoClick += 300;
                menegerUI.sliderAutoCliker.maxValue = YG2.saves.autoClick;
                panel.SetActive(true);
                imageGem.sprite = iconeBoost[0];
                textPrice.text = "5 " + Lange.Text(9);
                break;
            case "auto60":
                if (YG2.saves.gems < 60)
                {
                    menegerUI.sound.PlaySound(3);
                    menegerUI.VisualizePurchase(false, 1);
                    return;
                }
                menegerUI.sound.PlaySound(2);
                menegerUI.VisualizePurchase(true, 1);
                YG2.saves.gems -= 60;
                YG2.saves.autoClick += 3600;
                menegerUI.sliderAutoCliker.maxValue = YG2.saves.autoClick;
                panel.SetActive(true);
                imageGem.sprite = iconeBoost[0];
                textPrice.text = "1 " + Lange.Text(21);
                break;
            case "gold15":
                if (YG2.saves.gems < 15)
                {
                    menegerUI.sound.PlaySound(3);
                    menegerUI.VisualizePurchase(false, 1);
                    return;
                }
                menegerUI.sound.PlaySound(2);
                menegerUI.VisualizePurchase(true, 1);
                YG2.saves.gems -= 15;
                YG2.saves.x2ores += 300;
                menegerUI.sliderX2ores.maxValue = YG2.saves.x2ores;
                panel.SetActive(true);
                imageGem.sprite = iconeBoost[1];
                textPrice.text = "5 " + Lange.Text(9);
                break;
            case "gold60":
                if (YG2.saves.gems < 60)
                {
                    menegerUI.sound.PlaySound(3);
                    menegerUI.VisualizePurchase(false, 1);
                    return;
                }
                menegerUI.sound.PlaySound(2);
                menegerUI.VisualizePurchase(true, 1);
                YG2.saves.gems -= 60;
                YG2.saves.x2ores += 3600;
                menegerUI.sliderX2ores.maxValue = YG2.saves.x2ores;
                panel.SetActive(true);
                imageGem.sprite = iconeBoost[1];
                textPrice.text = "1 " + Lange.Text(21);
                break;
            case "speed15":
                if (YG2.saves.gems < 15)
                {
                    menegerUI.sound.PlaySound(3);
                    menegerUI.VisualizePurchase(false, 1);
                    return;
                }
                menegerUI.sound.PlaySound(2);
                menegerUI.VisualizePurchase(true, 1);
                YG2.saves.gems -= 15;
                YG2.saves.speedBoost += 300;
                menegerUI.sliderSpeedBoost.maxValue = YG2.saves.speedBoost;
                panel.SetActive(true);
                imageGem.sprite = iconeBoost[2];
                textPrice.text = "5 " + Lange.Text(9);
                break;
            case "speed60":
                if (YG2.saves.gems < 60)
                {
                    menegerUI.sound.PlaySound(3);
                    menegerUI.VisualizePurchase(false, 1);
                    return;
                }
                menegerUI.sound.PlaySound(2);
                menegerUI.VisualizePurchase(true, 1);

                YG2.saves.gems -= 60;
                YG2.saves.speedBoost += 3600;
                menegerUI.sliderSpeedBoost.maxValue = YG2.saves.speedBoost;
                panel.SetActive(true);
                imageGem.sprite = iconeBoost[2];
                textPrice.text = "1 " + Lange.Text(21);
                break;
            default:
                print(id);
                break;
        }
        YG2.SaveProgress();
    }

    private void FailedPurchased(string id)
    {
        // Покупка не была совершена
        print("Не купил");
    }

    private float Formula(int i, float x)
    {
        return Mathf.Pow(0.4f, YG2.saves.shopOre[i] + 1) * 10000 * x * YG2.saves.countBuyPlanet * 2 * Mathf.Pow(1.1f, YG2.saves.countBuffs4[YG2.saves.shopOre[i] == 0 ? 7 : YG2.saves.shopOre[i] - 1]);
    }

    public void ShopGem(int id)
    {
        switch (id)
        {
            case 0:
                YG2.saves.gems += 5;
                panel.SetActive(true);
                panelFree[0].SetActive(false);
                panelUnLock[0].SetActive(true);
                textPrice.text = 5 + "";
                imageGem.sprite = iconeGem;
                YG2.saves.shopBuy[0] = YG2.ServerTime() + 5000;
                break;
            case 1:
                panel.SetActive(true);
                panelFree[1].SetActive(false);
                panelUnLock[1].SetActive(true);
                double ore = Mathf.Pow(0.4f, YG2.saves.shopOre[YG2.saves.shopFree] + 1) * 10000 * 0.1f * YG2.saves.countBuyPlanet * 2 * Mathf.Pow(1.1f, YG2.saves.countBuffs4[YG2.saves.shopOre[YG2.saves.shopFree] == 0 ? 7 : YG2.saves.shopOre[YG2.saves.shopFree] - 1]);
                YG2.saves.countOre[YG2.saves.shopFree] += ore;
                YG2.saves.liderBoard += ore * Mathf.Pow(1.3f, id) / 50;
                imageGem.sprite = iconeOre[YG2.saves.shopFree];
                YG2.saves.shopBuy[1] = YG2.ServerTime() + 5000;
                textPrice.text = stats.FormatGold(ore);
                YG2.saves.shopFree = UnityEngine.Random.Range(0, YG2.saves.countBuyPlanet);
                iconeGemFree.sprite = iconeOre[YG2.saves.shopFree];
                break;
        }
    }

    public void FillArrayFixedRandom(int countBuyPlanet)
    {
        int fillCount = Mathf.Clamp(countBuyPlanet, 0, 5);

        // Генерируем уникальные числа от 0 до countBuyPlanet-1
        int[] numbers = new int[countBuyPlanet];
        for (int i = 0; i < countBuyPlanet; i++)
            numbers[i] = i;

        Shuffle(numbers);

        for (int i = 0; i < fillCount; i++)
        {
            YG2.saves.shopOre[i] = numbers[i];
        }
    }

    private static void Shuffle(int[] array)
    {
        System.Random rng = new System.Random();
        int n = array.Length;
        while (n > 1)
        {
            int k = rng.Next(n--);
            int temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }
}
