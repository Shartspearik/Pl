using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using YG;

public class MenegerUI : MonoBehaviour
{
    public List<Planet> planets = new List<Planet>();
    public GameObject panelECO;

    public Slider sliderPlanet;
    public TextMeshProUGUI textPlanet;
    public TextMeshProUGUI textBankNow;
    public List<TextMeshProUGUI> orePanels = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> orePanelsEnter = new List<TextMeshProUGUI>();

    // нопки покупки планет
    public List<GameObject> panelBuyPlanet = new List<GameObject>();
    public List<Image> iconeBuyPlanet = new List<Image>();
    public Sprite[] iconPlanet;
    public GameObject[] buffTreePlanet;

    public Sprite[] iconOre;

    // нопки выбора планет
    public List<GameObject> buttonPlanets = new List<GameObject>();

    public CameraController cameraController;
    public GameObject currentPlanet;
    public GameObject panelPlanet;
    public GameObject prefNumber;
    public Transform panelNumbers;



    public GameObject panelPlanetEarth;
    public TextMeshProUGUI textSpeedMineEarth;
    public TextMeshProUGUI textCloudMineEarth;
    public Slider sliderBankEarth;
    public TextMeshProUGUI textBankNowEarth;
    public TextMeshProUGUI textGems;

    public GameObject panelRewardShip;
    public TextMeshProUGUI textRewardShip;
    public TextMeshProUGUI textCountRewardShip;
    public Image iconeRewardShip;
    public Sprite iconeAutoClick;
    public Sprite iconex2ores;
    public Sprite iconeSpeedBoost;

    public Transform content;
    public Transform contentBuff;
    public Transform contentPlanets;
    public Planet planet;
    public GameObject currentPanel;
    public Stats stats;
    public Planet earth;

    public float x;
    public float y;
    public float z;

    private Coroutine currentAnimation = null;
    public bool isPanel;
    public PanelBuff panelBuff;
    public bool isOn = false;

    public int idPlanet;
    public int rewardId;
    public int reward;
    public float timerClick;
    public float timerx2;
    public float timerx3;

    public Slider sliderAutoCliker;
    public Slider sliderX2ores;
    public Slider sliderSpeedBoost;
    public GameObject autoCliker;
    public GameObject x2ores;
    public GameObject speedBoost;
    public TextMeshProUGUI textAutoCliker;
    public TextMeshProUGUI textSpeedBoost;
    public TextMeshProUGUI textX2ores;
    public TextMeshProUGUI textScores;

    public Image targetImage; 
    public Image targetImage1; 
    public Image targetIm; 
    public float colorDuration = 0.2f; // длительность окрашивани€ одного цвета (быстро)

    private Color defaultColor;
    public GameObject[] buttons;
    public UISoundPlayer sound;
    public BankPanel bankPanel;


    private void Start()
    {
        defaultColor = targetImage.color;
        for (int i = 0; i < YG2.saves.countBuyPlanet - 1; i++)
        {
            orePanels[i + 1].transform.parent.gameObject.SetActive(true);
            //buffTreePlanet[i].GetComponent<Image>().sprite = iconPlanet[i];
            //buffTreePlanet[i].transform.GetChild(0).gameObject.SetActive(true);
        }

        //for (int i = 0; i < orePanels.Count; i++)
        //{
        //    if (orePanels[i].gameObject)
        //    {
        //        OreTextPanel(i);
        //    }
            
        //}
        RePrint();
        if (YG2.saves.autoClick <= 0)
        {
            StartCoroutine(AutoClickerTimer());
        }
        if (YG2.saves.x2ores <= 0)
        {
            StartCoroutine(X2OresTimer());
        }
        if (YG2.saves.speedBoost <= 0)
        {
            StartCoroutine(SpeedBoostTimer());
        }
        sliderSpeedBoost.maxValue = YG2.saves.speedBoost;
        sliderAutoCliker.maxValue = YG2.saves.autoClick;
        sliderX2ores.maxValue = YG2.saves.x2ores;

    }

    private void Update()
    {
        textGems.text = YG2.saves.gems.ToString();

        if (planet == null)
        {
            sliderPlanet.gameObject.SetActive(false);
            panelECO.SetActive(false);
        }

        if (planet != null && YG2.saves.buffTreeECO[idPlanet == 7 ? 0 : idPlanet + 1]) 
        {
            panelECO.SetActive(true);
            bankPanel.oreIndex = idPlanet == 7 ? 0 : idPlanet + 1;
        }
        else
        {
            bankPanel.oreIndex = 11;

        }

        if (planet != null && planet != earth && planet.isActive)
        {
            textBankNow.text = stats.FormatGold((int)YG2.saves.bankNow[idPlanet]) + "";
            sliderPlanet.maxValue = (int)(YG2.saves.countBuffs5[idPlanet] * Parametrs.CloudShip(idPlanet));
            sliderPlanet.value = (int)YG2.saves.bankNow[idPlanet];
            textPlanet.text = YG2.saves.countShip[idPlanet] + " / " + YG2.saves.countBuffs5[idPlanet];
        }

        for (int i = 0; i < 8; i++)
        {
            OreTextPanel(i);
        }

        textScores.text = (int)YG2.saves.liderBoard + "";

        if (YG2.saves.autoClick > 0)
        {
            sliderAutoCliker.gameObject.SetActive(true);
            textAutoCliker.text = (int)YG2.saves.autoClick + "сек";
            sliderAutoCliker.value = YG2.saves.autoClick;
            YG2.saves.autoClick -= Time.deltaTime;

            timerClick += Time.deltaTime;
            if (timerClick >= 0.3f)
            {
                timerClick = 0;
                earth.ClickPlanet();
                for (int i = 0; i < YG2.saves.countBuyPlanet; i++)
                {

                    if (i > 0) planets[i - 1].ClickPlanet();
                }

                if (YG2.saves.autoClick <= 0)
                {
                    sliderAutoCliker.gameObject.SetActive(false);
                    StartCoroutine(AutoClickerTimer());
                }
            }

        }
        if (YG2.saves.x2ores > 0)
        {
            sliderX2ores.gameObject.SetActive(true);
            textX2ores.text = (int)YG2.saves.x2ores + "сек";
            sliderX2ores.value = YG2.saves.x2ores;
            YG2.saves.x2ores -= Time.deltaTime;

            timerx2 += Time.deltaTime;
            if (YG2.saves.x2ores <= 0)
            {
                sliderX2ores.gameObject.SetActive(false);
                StartCoroutine(X2OresTimer());
            }
        }
        if (YG2.saves.speedBoost > 0)
        {
            sliderSpeedBoost.gameObject.SetActive(true);
            textSpeedBoost.text = (int)YG2.saves.speedBoost + "сек";
            sliderSpeedBoost.value = YG2.saves.speedBoost;
            YG2.saves.speedBoost -= Time.deltaTime;

            timerx3 += Time.deltaTime;
            if (YG2.saves.speedBoost <= 0)
            {
                sliderSpeedBoost.gameObject.SetActive(false);
                StartCoroutine(SpeedBoostTimer());
            }
        }
    }

    public void VisualizePurchase(bool isSuccess, int id)
    {
        switch (id)
        {
            case 0:
                targetIm = targetImage;
                break;
            case 1:
                targetIm = targetImage1;
                break;
        }
        Color highlightColor = isSuccess ? Color.green : Color.red;
        StopAllCoroutines();
        StartCoroutine(FlashColor(highlightColor));
    }

    private IEnumerator FlashColor(Color highlightColor)
    {
        // ѕерва€ половина Ч переход к highlightColor
        float time = 0f;
        while (time < colorDuration)
        {
            targetIm.color = Color.Lerp(defaultColor, highlightColor, time / colorDuration);
            time += Time.deltaTime;
            yield return null;
        }
        targetIm.color = highlightColor;

        // ¬тора€ половина Ч плавный возврат к оригинальному цвету
        time = 0f;
        while (time < colorDuration)
        {
            targetIm.color = Color.Lerp(highlightColor, defaultColor, time / colorDuration);
            time += Time.deltaTime;
            yield return null;
        }
        targetIm.color = defaultColor;
    }
    public void RePrint()
    {
        for (int i = 0; i < YG2.saves.countBuyPlanet - 1; i++)
        {
            if (i != 6)
            {
                panelBuyPlanet[i].GetComponent<Button>().interactable = false;
                iconeBuyPlanet[i].sprite = iconPlanet[i];
                panelBuyPlanet[i + 1].GetComponent<Button>().interactable = true;
            }
            else
            {
                panelBuyPlanet[i].GetComponent<Button>().interactable = false;
                iconeBuyPlanet[i].sprite = iconPlanet[i];
            }
            planets[i].transform.GetChild(0).gameObject.SetActive(true);
            planets[i].GetComponent<Planet>().isActive = true;
            buttonPlanets[i].SetActive(true);
        }   
    }

    public void OreTextPanel(int id)
    {
        orePanels[id == 7 ? 0 : id + 1].text = stats.FormatGold(YG2.saves.countOre[id == 7 ? 0 : id + 1]);
    }

    public void ClickPlanet(int id)
    {
        buttons[2].SetActive(id != 10);
        buttons[3].SetActive(id != 10);
        buttons[4].SetActive(id != 10);

        panelBuff.SetPanel(id);

        if (id == 7 || id == 10)
            {
                currentPlanet = earth.gameObject;
            }
            else
            {
                currentPlanet = planets[id].gameObject;
            }
            planet = currentPlanet.GetComponent<Planet>();
            idPlanet = planet.idPlanet == 10 ? 7 : planet.idPlanet;
            cameraController.ClickPlanet(currentPlanet.transform);
        
    }

    public void OffPanelPlanet()
    {
        planet = null;
        //panelPlanet.SetActive(false);
        //panelPlanetEarth.SetActive(false);
    }
    IEnumerator AutoClickerTimer()
    {
        yield return new WaitForSeconds(180f);
        autoCliker.gameObject.SetActive(true);
    }
    IEnumerator X2OresTimer()
    {
        yield return new WaitForSeconds(180f);
        x2ores.gameObject.SetActive(true);
    }
    IEnumerator SpeedBoostTimer()
    {
        yield return new WaitForSeconds(180f);
        speedBoost.gameObject.SetActive(true);
    }
    public void Colonizetion(int id)
    {
        if (!isOn)
        {
            VisualizePurchase(false, 0);
            sound.PlaySound(3);
            return;
        }

        switch (id)
        {
            case 1:
                if (YG2.saves.countOre[0] >= 10)
                {
                    YG2.saves.countOre[0] -= 10;
                    break;
                }
                else
                {
                    VisualizePurchase(false, 0);
                    sound.PlaySound(3);
                    return;
                }
            case 2:
                if (YG2.saves.countOre[0] >= 10 && YG2.saves.countOre[1] >= 10)
                {
                    YG2.saves.countOre[0] -= 10;
                    YG2.saves.countOre[1] -= 10;
                    break;
                }
                else
                {
                    VisualizePurchase(false, 0);
                    sound.PlaySound(3);
                    return;
                }
            case 3:
                if (YG2.saves.countOre[0] >= 10 && YG2.saves.countOre[1] >= 10 && YG2.saves.countOre[2] >= 10)
                {
                    YG2.saves.countOre[0] -= 10;
                    YG2.saves.countOre[1] -= 10;
                    YG2.saves.countOre[2] -= 10;
                    break;
                }
                else
                {
                    VisualizePurchase(false, 0);
                    sound.PlaySound(3);
                    return;
                }
            case 4:
                if (YG2.saves.countOre[0] >= 10 && YG2.saves.countOre[1] >= 10 && YG2.saves.countOre[2] >= 10 && YG2.saves.countOre[3] >= 10)
                {
                    YG2.saves.countOre[0] -= 10;
                    YG2.saves.countOre[1] -= 10;
                    YG2.saves.countOre[2] -= 10;
                    YG2.saves.countOre[3] -= 10;
                    break;
                }
                else
                {
                    VisualizePurchase(false, 0);
                    sound.PlaySound(3);
                    return;
                }
            case 5:
                if (YG2.saves.countOre[0] >= 10 && YG2.saves.countOre[1] >= 10 && YG2.saves.countOre[2] >= 10 && YG2.saves.countOre[3] >= 10 && YG2.saves.countOre[4] >= 10)
                {
                    YG2.saves.countOre[0] -= 10;
                    YG2.saves.countOre[1] -= 10;
                    YG2.saves.countOre[2] -= 10;
                    YG2.saves.countOre[3] -= 10;
                    YG2.saves.countOre[4] -= 10;
                    break;
                }
                else
                {
                    VisualizePurchase(false, 0);
                    sound.PlaySound(3);
                    return;
                }
            case 6:
                if (YG2.saves.countOre[0] >= 10 && YG2.saves.countOre[1] >= 10 && YG2.saves.countOre[2] >= 10 && YG2.saves.countOre[3] >= 10 && YG2.saves.countOre[4] >= 10 && YG2.saves.countOre[5] >= 10)
                {
                    YG2.saves.countOre[0] -= 10;
                    YG2.saves.countOre[1] -= 10;
                    YG2.saves.countOre[2] -= 10;
                    YG2.saves.countOre[3] -= 10;
                    YG2.saves.countOre[4] -= 10;
                    YG2.saves.countOre[5] -= 10;
                    break;
                }
                else
                {
                    VisualizePurchase(false, 0);
                    return;
                }
            case 7:
                if (YG2.saves.countOre[6] >= 10 && YG2.saves.countOre[1] >= 10 && YG2.saves.countOre[2] >= 10 && YG2.saves.countOre[3] >= 10 && YG2.saves.countOre[4] >= 10 && YG2.saves.countOre[5] >= 10)
                {
                    YG2.saves.countOre[6] -= 10;
                    YG2.saves.countOre[1] -= 10;
                    YG2.saves.countOre[2] -= 10;
                    YG2.saves.countOre[3] -= 10;
                    YG2.saves.countOre[4] -= 10;
                    YG2.saves.countOre[5] -= 10;
                    break;
                }
                else
                {
                    VisualizePurchase(false, 0);
                    sound.PlaySound(3);
                    return;
                }
        }
        YG2.saves.countBuyPlanet++;
        VisualizePurchase(true, 0);
        sound.PlaySound(4);
        //ќбработка кнопок покупок планет
        if (id != 7)
        {
            panelBuyPlanet[id].GetComponent<Button>().interactable = true;
        }
        panelBuyPlanet[id - 1].GetComponent<Button>().interactable = false;
        iconeBuyPlanet[id - 1].sprite = iconPlanet[id - 1];

        //ќбработка планет на орбите
        planets[id - 1].transform.GetChild(0).gameObject.SetActive(true);
        planets[id - 1].GetComponent<Planet>().isActive = true;

        //ќбработка кнопок планет
        buttonPlanets[id - 1].SetActive(true);

        ////ќбработка кнопок дерева талантов
        buffTreePlanet[id - 1].GetComponent<Button>().image.GetComponent<Image>().sprite = iconPlanet[id - 1];
        buffTreePlanet[id - 1].transform.GetChild(0).gameObject.SetActive(true);

        panelBuff.currentPlanet = 1;
        for (int q = 1; q < 6; q++)
        {
            buttons[q - 1].GetComponent<Button>().interactable = true;
            panelBuff.price[q - 1].SetActive(true);
            panelBuff.panelLevelUp[q - 1].gameObject.SetActive(false);
            stats.CheckBuff15(q);
        }
        panelBuff.currentPlanet = 0;
        isOn = false;
        orePanels[YG2.saves.countBuyPlanet - 1].transform.parent.gameObject.SetActive(true);
        YG2.SaveProgress();
    }

    public void PrintOre(int id)
    {

        GameObject number = Instantiate(prefNumber, id == 0? earth.transform.position : planets[id - 1].transform.position, Quaternion.identity, panelNumbers);
        number.GetComponent<TextMeshPro>().text = "+" + stats.FormatGold(Parametrs.Ore(id));
        number.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = iconOre[id];
        AnimateMoneyGain(orePanels[id]);
        YG2.saves.countOre[id] += Parametrs.Ore(id);
        YG2.saves.liderBoard += Parametrs.Ore(id) * Mathf.Pow(1.3f, id) / 50;
    }

    public void PrintOreClick(int id)
    {

        GameObject number = Instantiate(prefNumber, id == 0 ? earth.transform.position : planets[id - 1].transform.position, Quaternion.identity, panelNumbers);
        number.GetComponent<TextMeshPro>().text = "+" + Parametrs.Click(id);
        number.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = iconOre[id];
        AnimateMoneyGain(orePanels[id]);
        YG2.saves.countOre[id] += Parametrs.Click(id);
        YG2.saves.liderBoard += Parametrs.Click(id) * Mathf.Pow(1.3f, id) / 50;
    }

    public void RewardShip()
    {
        panelRewardShip.SetActive(true);
        rewardId = Random.Range(0, YG2.saves.countBuyPlanet);
        double basePower = System.Math.Pow(0.4, rewardId + 1);
        double buffPower = System.Math.Pow(1.1, YG2.saves.countBuffs4[rewardId == 0 ? 7 : rewardId - 1]);
        double oreValue = basePower * 10000.0 * 0.1 * YG2.saves.countBuyPlanet * 2.0 * buffPower;
        textCountRewardShip.text = stats.FormatGold(oreValue);

        iconeRewardShip.sprite = iconOre[rewardId];
        reward = 0;
    }

    public void RewardClick()
    {
        autoCliker.SetActive(false);
        panelRewardShip.SetActive(true);
        textCountRewardShip.text = "120 " + Lange.Text(68);
        iconeRewardShip.sprite = iconeAutoClick;
        reward = 1;
    }
    public void RewardClick1()
    {
        x2ores.SetActive(false);
        panelRewardShip.SetActive(true);
        textCountRewardShip.text = "120 " + Lange.Text(68);
        iconeRewardShip.sprite = iconex2ores;
        reward = 2;
    }
    public void RewardClick2()
    {
        speedBoost.SetActive(false);
        panelRewardShip.SetActive(true);
        textCountRewardShip.text = "120 " + Lange.Text(68);
        iconeRewardShip.sprite = iconeSpeedBoost;
        reward = 3;
    }

    public void ClickRewardShip()
    {
        switch (reward)
        {
            case 0:
                YG2.RewardedAdvShow("coin", Reward0);
                break;
            case 1:
                YG2.RewardedAdvShow("autoClick", Reward1);
                break;
            case 2:
                YG2.RewardedAdvShow("x2ore", Reward2);
                break;
            case 3:
                YG2.RewardedAdvShow("speedBoost", Reward3);
                break;
        }
    }

    public void Reward0()
    {
        GameObject number = Instantiate(prefNumber, planets[rewardId].transform.position, Quaternion.identity, panelNumbers);
        number.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = iconOre[rewardId];
        AnimateMoneyGain(orePanels[rewardId]);
        double basePower = System.Math.Pow(0.4, rewardId + 1);
        double buffPower = System.Math.Pow(1.1, YG2.saves.countBuffs4[rewardId == 0 ? 7 : rewardId - 1]);
        double ore = basePower * 10000 * 0.1 * YG2.saves.countBuyPlanet * 2 * buffPower;

        number.GetComponent<TextMeshPro>().text = "+" + stats.FormatGold(ore);
        YG2.saves.countOre[rewardId] += ore;
        YG2.saves.liderBoard += ore * Mathf.Pow(1.3f, rewardId) / 50;
    }

    public void Reward1()
    {
        YG2.saves.autoClick += 120;
        sliderAutoCliker.maxValue = YG2.saves.autoClick;
        YG2.SaveProgress();
    }
    public void Reward2()
    {
        YG2.saves.x2ores += 120;
        sliderX2ores.maxValue = YG2.saves.x2ores;
        YG2.SaveProgress();
    }
    public void Reward3()
    {
        YG2.saves.speedBoost += 120;
        sliderSpeedBoost.maxValue = YG2.saves.speedBoost;
        YG2.SaveProgress();
    }


    public void AnimateMoneyGain(TextMeshProUGUI tmpText)
    {
        // ≈сли анимаци€ уже идЄт, остановить еЄ и вернуть текст в исходное состо€ние
        if (currentAnimation != null)
        {
            StopCoroutine(currentAnimation);
            ResetText(tmpText);
        }
        currentAnimation = StartCoroutine(AnimateText(tmpText));
    }

    private void ResetText(TextMeshProUGUI tmpText)
    {
        tmpText.color = Color.white; // или другой оригинальный цвет
        tmpText.transform.localScale = Vector3.one; // или исходный масштаб
    }

    private IEnumerator AnimateText(TextMeshProUGUI tmpText)
    {
        Color originalColor = tmpText.color;
        Vector3 originalScale = tmpText.transform.localScale;

        Color targetColor = Color.green;
        Vector3 targetScale = originalScale * 1.2f;

        float duration = 0.3f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            tmpText.color = Color.Lerp(originalColor, targetColor, t);
            tmpText.transform.localScale = Vector3.Lerp(originalScale, targetScale, t);
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);

        elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            tmpText.color = Color.Lerp(targetColor, originalColor, t);
            tmpText.transform.localScale = Vector3.Lerp(targetScale, originalScale, t);
            yield return null;
        }

        tmpText.color = originalColor;
        tmpText.transform.localScale = originalScale;

        currentAnimation = null;
    }
}

 