using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class PanelBuff : MonoBehaviour
{
    public Image image;
    public Sprite[] iconePlanet;
    public Stats stats;

    public TextMeshProUGUI[] textPowerBuff;
    public GameObject[] price;
    public Slider[] sliders;
    public GameObject[] panelLevelUp;

    public TextMeshProUGUI[] textPowerBuffEarth;
    public GameObject[] priceEarth;
    public Slider[] slidersEarth;
    public GameObject[] panelLevelUpEarth;

    public GameObject textNoEarth;
    public GameObject textEarth;
    public GameObject buttonNoEarth;
    public GameObject buttonEarth;
    

    public int currentPlanet;

    public void SetPanel(int id)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int q = 0; q < 5; q++)
            {
                price[q].transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        currentPlanet = (id == 10) ? 0 : id + 1;

        textNoEarth.SetActive(id != 10);
        textEarth.SetActive(id == 10);
        buttonNoEarth.SetActive(id != 10);
        buttonEarth.SetActive(id == 10);
        if (id == 10)
        {
            id = 7;
            for (int i = 3; i < 5; i++)
            {
                stats.ResetPrice(id * 10 + i);
                PrintButton(id, i);
            }
            //image.sprite = iconePlanet[7];
        }
        else
        {

            //image.sprite = iconePlanet[id];
            for (int i = 1; i < 6; i++)
            {
                stats.ResetPrice((id+1) * 10 + i);
                PrintButton(id, i - 1);
            }
        }
    }

    public void PrintButton(int idShip, int idBuff)
    {
        int id = 0;
        switch (idBuff)
        {
            case 1:
                id = YG2.saves.priseBuff1[idShip];
                if (currentPlanet != 0)
                {
                    sliders[idBuff].value = YG2.saves.countBuffs1[idShip];
                    textPowerBuff[idBuff].text = (YG2.saves.countBuffs1[idShip] * 13).ToString();
                    id = YG2.saves.priseBuff1[idShip];
                }
                else
                {
                    slidersEarth[idBuff - 2].value = YG2.saves.countBuffs1[idShip];
                    textPowerBuffEarth[idBuff - 2].text = (YG2.saves.countBuffs1[idShip] * 13).ToString();
                }
                    break;



            case 2:
                id = YG2.saves.priseBuff2[idShip];
                if (currentPlanet != 0)
                {
                    sliders[idBuff].value = YG2.saves.countBuffs2[idShip];
                    textPowerBuff[idBuff].text = (YG2.saves.countBuffs2[idShip] * 13).ToString();
                    id = YG2.saves.priseBuff1[idShip];
                }
                else
                {
                    slidersEarth[idBuff - 2].value = YG2.saves.countBuffs2[idShip];
                    textPowerBuffEarth[idBuff - 2].text = (YG2.saves.countBuffs2[idShip] * 13).ToString();
                }
                break;


            case 3:
                id = YG2.saves.priseBuff3[idShip];
                if (currentPlanet != 0)
                {
                    sliders[idBuff].value = YG2.saves.countBuffs3[idShip];
                    textPowerBuff[idBuff].text = (YG2.saves.countBuffs3[idShip] * 13).ToString();
                    id = YG2.saves.priseBuff1[idShip];
                }
                else
                {
                    slidersEarth[idBuff - 3].value = YG2.saves.countBuffs3[idShip];
                    textPowerBuffEarth[idBuff - 3].text = (YG2.saves.countBuffs3[idShip] * 13).ToString();
                }
                break;


            case 4:
                id = YG2.saves.priseBuff4[idShip];
                if (currentPlanet != 0)
                {
                    sliders[idBuff].value = YG2.saves.countBuffs4[idShip];
                    textPowerBuff[idBuff].text = (YG2.saves.countBuffs4[idShip] * 13).ToString();
                    id = YG2.saves.priseBuff1[idShip];
                }
                else
                {
                    slidersEarth[idBuff - 3].value = YG2.saves.countBuffs4[idShip];
                    textPowerBuffEarth[idBuff - 3].text = (YG2.saves.countBuffs4[idShip] * 13).ToString();
                }
                break;


            case 5:
                id = YG2.saves.priseBuff5[idShip];
                if (currentPlanet != 0)
                {
                    sliders[idBuff].value = YG2.saves.countBuffs5[idShip];
                    textPowerBuff[idBuff].text = (YG2.saves.countBuffs5[idShip] * 13).ToString();
                    id = YG2.saves.priseBuff1[idShip];
                }
                else
                {
                    slidersEarth[idBuff - 2].value = YG2.saves.countBuffs5[idShip];
                    textPowerBuffEarth[idBuff - 2].text = (YG2.saves.countBuffs5[idShip] * 13).ToString();
                }
                break;
        }

        for (int i = 0; i < 3; i++)
        {
            if(id / 10 != 0)
            {
                price[idBuff].transform.GetChild(i).gameObject.SetActive(true);
                //price[idBuff].transform.GetChild(i).GetComponent<Image>().sprite = stats.icone[id];
                int buff = 0;
                switch (idBuff)
                {
                    case 1:
                        buff = YG2.saves.countBuffs1[idShip] + (idShip) * 15;
                        break;
                    case 2:
                        buff = YG2.saves.countBuffs2[idShip] + (idShip) * 15;
                        break;
                    case 3:
                        buff = YG2.saves.countBuffs3[idShip] + (idShip) * 15;
                        break;
                    case 4:
                        buff = YG2.saves.countBuffs4[idShip] + (idShip) * 15;
                        break;
                    case 5:
                        buff = YG2.saves.countBuffs5[idShip] + (idShip) * 15;
                        break;
                }
                price[idBuff].transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = stats.PriseOre(buff, id).ToString();
            }
        }
    }

    public void Buff(int id)
    {
        if (YG2.saves.is15[id - 1]) return;
        stats.Buffing(id);
    }
}
