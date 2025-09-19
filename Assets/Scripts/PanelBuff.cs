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

    public int currentPlanet;

    public void SetPanel(int id)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int q = 0; q < 3; q++)
            {
                price[q].transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        currentPlanet = (id == 10) ? 0 : id + 1;
        if (id == 10)
        {
            image.sprite = iconePlanet[7];
        }
        else
        {   
            image.sprite = iconePlanet[id];
            for (int i = 1; i < 4; i++)
            {
                stats.ResetPrice((id+1) * 10 + i);
                PrintButton(id, i - 1);
            }
        }
    }

    public void PrintButton(int idShip, int idBuff)
    {
        sliders[idBuff].value = YG2.saves.countBuffing[idBuff][idShip];
        textPowerBuff[idBuff].text = (YG2.saves.countBuffing[idBuff][idShip] * 13).ToString();

        int id = YG2.saves.savePrice[idBuff][idShip];
        for (int i = 0; i < 3; i++)
        {
            if(id / 10 != 0)
            {
                price[idBuff].transform.GetChild(i).gameObject.SetActive(true);
                price[idBuff].transform.GetChild(i).GetComponent<Image>().sprite = stats.icone[id];
                int buff = YG2.saves.countBuffing[idBuff - 1][idShip - 1] + (idShip - 1) * 15;
                price[idBuff].transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = stats.PriseOre(buff, id).ToString();
            }
        }
    }

    public void Buff(int id)
    {
        if (currentPlanet == 0) return;
        stats.Buffing(currentPlanet * 10 + id);
    }
}
