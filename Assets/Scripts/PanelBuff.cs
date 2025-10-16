using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class PanelBuff : MonoBehaviour
{
    public Stats stats;

    public TextMeshProUGUI[] textPowerBuff;
    public GameObject[] price;
    public GameObject[] panelLevelUp;

    public int currentPlanet;

    public void SetPanel(int id)
    {
        //for (int i = 0; i < 3; i++)
        //{
        //    for (int q = 0; q < 5; q++)
        //    {
        //        price[q].transform.GetChild(i).gameObject.SetActive(false);
        //    }
        //}
        currentPlanet = (id == 10) ? 0 : id + 1;

        for (int i = 1; i < 6; i++)
        {
            stats.PrintPrice(i);
            stats.CheckBuff15(i);
        }
    }

    public void Buff(int id)
    {
        stats.Buffing(id);
    }
}
