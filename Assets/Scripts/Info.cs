using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;  // Не забыть подключить чтобы использовать события UI
using TMPro;
using YG;

public class Info : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject panel;
    public Stats stats;
    public int id;
    public int idShip;

    private TextMeshProUGUI textName;
    private TextMeshProUGUI textPrice;
    private TextMeshProUGUI textInfo;
    private Image icone;
    public GameObject panelLeaderBoard;
    public Sprite[] iconeOre;

    private void Start()
    {
        if(panel != null)
        {
            if (id < 13)
            {
                textName = panel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                textPrice = panel.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
                textInfo = panel.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
                icone = panel.transform.GetChild(3).GetComponent<Image>();
            }
            else
            {
                textName = panel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                textInfo = panel.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            }
        }
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnHoverEnter();
    }

    // Этот метод вызывается, когда курсор покидает объект (необязательно)
    public void OnPointerExit(PointerEventData eventData)
    {
        OnHoverExit();
    }

    private void OnHoverEnter()
    {
        // Пока метод пустой
        //Debug.Log("Курсор наведён на объект UI");
        if (panel != null)
        {
            panel.SetActive(true);
            if (id < 13)
            {
                panel.transform.position = new Vector2(transform.position.x + 330, transform.position.y + 40);
            }
            else
            {
                panel.transform.position = new Vector2(transform.position.x, transform.position.y + 150);
            }
        }
        
        switch (id)
        {
            case 0:
                textName.text = Lange.Text(30);
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[0]);
                textInfo.text = Lange.Text(31);
                icone.sprite = iconeOre[idShip];
                break;
            case 1:
                textName.text = Lange.Text(32);
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[1]);
                textInfo.text = Lange.Text(33);
                icone.sprite = iconeOre[idShip];
                break;
            case 2:
                textName.text = Lange.Text(34);
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[2]);
                textInfo.text = Lange.Text(35);
                icone.sprite = iconeOre[idShip];
                break;
            case 3:
                textName.text = Lange.Text(36);
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[3]);
                textInfo.text = Lange.Text(37);
                icone.sprite = iconeOre[idShip];
                break;
            case 4:
                textName.text = Lange.Text(38);
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[4]);
                textInfo.text = Lange.Text(39);
                icone.sprite = iconeOre[idShip];
                break;
            case 5:
                textName.text = Lange.Text(40);
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[5]);
                textInfo.text = Lange.Text(41);
                icone.sprite = iconeOre[idShip];
                break;
            case 6:
                textName.text = Lange.Text(42);
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[6]);
                textInfo.text = Lange.Text(43);
                icone.sprite = iconeOre[idShip];
                break;
            case 7:
                textName.text = Lange.Text(44);
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[7]);
                textInfo.text = Lange.Text(45);
                icone.sprite = iconeOre[idShip];
                break;
            case 8:
                textName.text = Lange.Text(46);
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[8]);
                textInfo.text = Lange.Text(47);
                icone.sprite = iconeOre[idShip];
                break;
            case 9:
                textName.text = Lange.Text(48);
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[9]);
                textInfo.text = Lange.Text(49);
                icone.sprite = iconeOre[idShip];
                break;
            case 10:
                textName.text = Lange.Text(50);
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[10]);
                textInfo.text = Lange.Text(51);
                icone.sprite = iconeOre[idShip];
                break;
            case 11:
                textName.text = Lange.Text(52);
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[11]);
                textInfo.text = Lange.Text(53);
                icone.sprite = iconeOre[idShip];
                break;
            case 12:
                textName.text = Lange.Text(54);
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[12]);
                textInfo.text = Lange.Text(55);
                icone.sprite = iconeOre[idShip];
                break;
            case 13:
                textName.text = stats.CheckOre(0);

                if(YG2.saves.countBuyPlanet == 1)
                {
                    panel.transform.GetChild(3).gameObject.SetActive(true);
                    textInfo.text = Lange.Text(56);
                    panel.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
                    panel.transform.GetChild(3).GetChild(2).gameObject.SetActive(false);
                    panel.transform.GetChild(3).GetChild(3).gameObject.SetActive(false);
                    panel.transform.GetChild(3).GetChild(4).gameObject.SetActive(false);
                    panel.transform.GetChild(3).GetChild(5).gameObject.SetActive(false);

                    panel.transform.GetChild(3).GetChild(1).gameObject.SetActive(true);
                    panel.transform.GetChild(3).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = 10 + "";
                    panel.transform.GetChild(3).GetChild(1).GetChild(1).GetComponent<Image>().sprite = iconeOre[0];
                }
                else if (YG2.saves.countBuyPlanet < 1)
                {
                    textName.text = "???";
                    textInfo.text = "??????";
                }
                else
                {
                    textInfo.text = Lange.Text(57);
                    panel.transform.GetChild(3).gameObject.SetActive(false);
                }

                break;

            case 14:
                textName.text = stats.CheckOre(1);
                if (YG2.saves.countBuyPlanet == 2)
                {
                    panel.transform.GetChild(3).gameObject.SetActive(true);
                    textInfo.text = Lange.Text(56);

                    panel.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
                panel.transform.GetChild(3).GetChild(2).gameObject.SetActive(false);
                panel.transform.GetChild(3).GetChild(3).gameObject.SetActive(false);
                panel.transform.GetChild(3).GetChild(4).gameObject.SetActive(false);
                panel.transform.GetChild(3).GetChild(5).gameObject.SetActive(false);

                panel.transform.GetChild(3).GetChild(1).gameObject.SetActive(true);
                panel.transform.GetChild(3).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = 11 + "";
                panel.transform.GetChild(3).GetChild(1).GetChild(1).GetComponent<Image>().sprite = iconeOre[0];

                panel.transform.GetChild(3).GetChild(2).gameObject.SetActive(true);
                panel.transform.GetChild(3).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = 11 + "";
                panel.transform.GetChild(3).GetChild(2).GetChild(1).GetComponent<Image>().sprite = iconeOre[1];
        }
                else if (YG2.saves.countBuyPlanet < 2)
                {
                    textName.text = "???";
                    textInfo.text = "??????";
                    panel.transform.GetChild(3).gameObject.SetActive(false);
                }
                else
        {
            textInfo.text = Lange.Text(58);
                    panel.transform.GetChild(3).gameObject.SetActive(false);
        }
        break;

            case 15:
                textName.text = stats.CheckOre(2);
                if (YG2.saves.countBuyPlanet == 3)
                {
                    panel.transform.GetChild(3).gameObject.SetActive(true);
                    textInfo.text = Lange.Text(56);

                    panel.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
                panel.transform.GetChild(3).GetChild(2).gameObject.SetActive(false);
                panel.transform.GetChild(3).GetChild(3).gameObject.SetActive(false);
                panel.transform.GetChild(3).GetChild(4).gameObject.SetActive(false);
                panel.transform.GetChild(3).GetChild(5).gameObject.SetActive(false);

                panel.transform.GetChild(3).GetChild(1).gameObject.SetActive(true);
                panel.transform.GetChild(3).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = 112 + "";
                panel.transform.GetChild(3).GetChild(1).GetChild(1).GetComponent<Image>().sprite = iconeOre[0];

                panel.transform.GetChild(3).GetChild(2).gameObject.SetActive(true);
                panel.transform.GetChild(3).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = 112 + "";
                panel.transform.GetChild(3).GetChild(2).GetChild(1).GetComponent<Image>().sprite = iconeOre[1];

                panel.transform.GetChild(3).GetChild(3).gameObject.SetActive(true);
                panel.transform.GetChild(3).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = 112 + "";
                panel.transform.GetChild(3).GetChild(3).GetChild(1).GetComponent<Image>().sprite = iconeOre[3];
        }
                else if (YG2.saves.countBuyPlanet < 3)
                {
                    textName.text = "???";
                    textInfo.text = "??????";
                    panel.transform.GetChild(3).gameObject.SetActive(false);
                }
                else
        {
            textInfo.text = Lange.Text(59);
                    panel.transform.GetChild(3).gameObject.SetActive(false);
        }
        break;

            case 16:
                textName.text = stats.CheckOre(3);
                if (YG2.saves.countBuyPlanet == 4)
                {
                    panel.transform.GetChild(3).gameObject.SetActive(true);
                    textInfo.text = Lange.Text(56);

                    panel.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
                panel.transform.GetChild(3).GetChild(2).gameObject.SetActive(false);
                panel.transform.GetChild(3).GetChild(3).gameObject.SetActive(false);
                panel.transform.GetChild(3).GetChild(4).gameObject.SetActive(false);
                panel.transform.GetChild(3).GetChild(5).gameObject.SetActive(false);

                panel.transform.GetChild(3).GetChild(1).gameObject.SetActive(true);
                panel.transform.GetChild(3).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = 111 + "";
                panel.transform.GetChild(3).GetChild(1).GetChild(1).GetComponent<Image>().sprite = iconeOre[0];

                panel.transform.GetChild(3).GetChild(2).gameObject.SetActive(true);
                panel.transform.GetChild(3).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = 111 + "";
                panel.transform.GetChild(3).GetChild(2).GetChild(1).GetComponent<Image>().sprite = iconeOre[1];

                panel.transform.GetChild(3).GetChild(3).gameObject.SetActive(true);
                panel.transform.GetChild(3).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = 111 + "";
                panel.transform.GetChild(3).GetChild(3).GetChild(1).GetComponent<Image>().sprite = iconeOre[2];

                panel.transform.GetChild(3).GetChild(4).gameObject.SetActive(true);
                panel.transform.GetChild(3).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text = 111 + "";
                panel.transform.GetChild(3).GetChild(4).GetChild(1).GetComponent<Image>().sprite = iconeOre[3];
        }
                else if (YG2.saves.countBuyPlanet < 4)
                {
                    textName.text = "???";
                    textInfo.text = "??????";
                    panel.transform.GetChild(3).gameObject.SetActive(false);
                }
                else
        {
            textInfo.text = Lange.Text(60);
                    panel.transform.GetChild(3).gameObject.SetActive(false);
        }
        break;

            case 17:
                textName.text = stats.CheckOre(4);
                if (YG2.saves.countBuyPlanet == 5)
                {
                    panel.transform.GetChild(3).gameObject.SetActive(true);
                    textInfo.text = Lange.Text(56);

                    panel.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
                panel.transform.GetChild(3).GetChild(2).gameObject.SetActive(false);
                panel.transform.GetChild(3).GetChild(3).gameObject.SetActive(false);
                panel.transform.GetChild(3).GetChild(4).gameObject.SetActive(false);
                panel.transform.GetChild(3).GetChild(5).gameObject.SetActive(false);

                panel.transform.GetChild(3).GetChild(1).gameObject.SetActive(true);
                panel.transform.GetChild(3).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = 113 + "";
                panel.transform.GetChild(3).GetChild(1).GetChild(1).GetComponent<Image>().sprite = iconeOre[0];

                panel.transform.GetChild(3).GetChild(2).gameObject.SetActive(true);
                panel.transform.GetChild(3).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = 131 + "";
                panel.transform.GetChild(3).GetChild(2).GetChild(1).GetComponent<Image>().sprite = iconeOre[1];

                panel.transform.GetChild(3).GetChild(3).gameObject.SetActive(true);
                panel.transform.GetChild(3).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = 113 + "";
                panel.transform.GetChild(3).GetChild(3).GetChild(1).GetComponent<Image>().sprite = iconeOre[2];

                panel.transform.GetChild(3).GetChild(4).gameObject.SetActive(true);
                panel.transform.GetChild(3).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text = 11 + "";
                panel.transform.GetChild(3).GetChild(4).GetChild(1).GetComponent<Image>().sprite = iconeOre[3];

                panel.transform.GetChild(3).GetChild(5).gameObject.SetActive(true);
                panel.transform.GetChild(3).GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>().text = 131 + "";
                panel.transform.GetChild(3).GetChild(5).GetChild(1).GetComponent<Image>().sprite = iconeOre[4];
        }
                else if (YG2.saves.countBuyPlanet < 5)
                {
                    textName.text = "???";
                    textInfo.text = "??????";
                    panel.transform.GetChild(3).gameObject.SetActive(false);
                }
                else
        {
            textInfo.text = Lange.Text(61);
                    panel.transform.GetChild(3).gameObject.SetActive(false);
        }
        break;

            case 18:
                textName.text = stats.CheckOre(5);
                if (YG2.saves.countBuyPlanet == 6)
                {
                    panel.transform.GetChild(3).gameObject.SetActive(true);
                    textInfo.text = Lange.Text(56);

                    panel.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
                panel.transform.GetChild(3).GetChild(2).gameObject.SetActive(false);
                panel.transform.GetChild(3).GetChild(3).gameObject.SetActive(false);
                panel.transform.GetChild(3).GetChild(4).gameObject.SetActive(false);
                panel.transform.GetChild(3).GetChild(5).gameObject.SetActive(false);

                panel.transform.GetChild(3).GetChild(1).gameObject.SetActive(true);
                panel.transform.GetChild(3).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = 1123 + "";
                panel.transform.GetChild(3).GetChild(1).GetChild(1).GetComponent<Image>().sprite = iconeOre[1];

                panel.transform.GetChild(3).GetChild(2).gameObject.SetActive(true);
                panel.transform.GetChild(3).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = 1231 + "";
                panel.transform.GetChild(3).GetChild(2).GetChild(1).GetComponent<Image>().sprite = iconeOre[2];

                panel.transform.GetChild(3).GetChild(3).gameObject.SetActive(true);
                panel.transform.GetChild(3).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = 2113 + "";
                panel.transform.GetChild(3).GetChild(3).GetChild(1).GetComponent<Image>().sprite = iconeOre[3];

                panel.transform.GetChild(3).GetChild(4).gameObject.SetActive(true);
                panel.transform.GetChild(3).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text = 121 + "";
                panel.transform.GetChild(3).GetChild(4).GetChild(1).GetComponent<Image>().sprite = iconeOre[4];

                panel.transform.GetChild(3).GetChild(5).gameObject.SetActive(true);
                panel.transform.GetChild(3).GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>().text = 211 + "";
                panel.transform.GetChild(3).GetChild(5).GetChild(1).GetComponent<Image>().sprite = iconeOre[5];
        }
                else if (YG2.saves.countBuyPlanet < 6)
                {
                    textName.text = "???";
                    textInfo.text = "??????";
                    panel.transform.GetChild(3).gameObject.SetActive(false);
                }
                else
        {
            textInfo.text = Lange.Text(62);
                    panel.transform.GetChild(3).gameObject.SetActive(false);
        }
        break;

            case 19:
                textName.text = stats.CheckOre(6);
                if (YG2.saves.countBuyPlanet == 7)
                {
                panel.transform.GetChild(3).gameObject.SetActive(true);
                textInfo.text = Lange.Text(56);

                    panel.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
                panel.transform.GetChild(3).GetChild(2).gameObject.SetActive(false);
                panel.transform.GetChild(3).GetChild(3).gameObject.SetActive(false);
                panel.transform.GetChild(3).GetChild(4).gameObject.SetActive(false);
                panel.transform.GetChild(3).GetChild(5).gameObject.SetActive(false);

                panel.transform.GetChild(3).GetChild(1).gameObject.SetActive(true);
                panel.transform.GetChild(3).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = 1123 + "";
                panel.transform.GetChild(3).GetChild(1).GetChild(1).GetComponent<Image>().sprite = iconeOre[2];

                panel.transform.GetChild(3).GetChild(2).gameObject.SetActive(true);
                panel.transform.GetChild(3).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = 1231 + "";
                panel.transform.GetChild(3).GetChild(2).GetChild(1).GetComponent<Image>().sprite = iconeOre[3];

                panel.transform.GetChild(3).GetChild(3).gameObject.SetActive(true);
                panel.transform.GetChild(3).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = 2113 + "";
                panel.transform.GetChild(3).GetChild(3).GetChild(1).GetComponent<Image>().sprite = iconeOre[4];

                panel.transform.GetChild(3).GetChild(4).gameObject.SetActive(true);
                panel.transform.GetChild(3).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text = 121 + "";
                panel.transform.GetChild(3).GetChild(4).GetChild(1).GetComponent<Image>().sprite = iconeOre[5];

                panel.transform.GetChild(3).GetChild(5).gameObject.SetActive(true);
                panel.transform.GetChild(3).GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>().text = 211 + "";
                panel.transform.GetChild(3).GetChild(5).GetChild(1).GetComponent<Image>().sprite = iconeOre[6];
                }
                else if (YG2.saves.countBuyPlanet < 7)
                {
                    textName.text = "???";
                    textInfo.text = "??????";
                    panel.transform.GetChild(3).gameObject.SetActive(false);
                }
                else
                {
                    textInfo.text = Lange.Text(63);
                    panel.transform.GetChild(3).gameObject.SetActive(false);
                }
        break;
            case 20:
                panelLeaderBoard.SetActive(true);
                break;

        case 21:
            textName.text = stats.CheckOre(7);
                textInfo.text = Lange.Text(64);
                panel.transform.GetChild(3).gameObject.SetActive(false);

                break;

        }
        YG2.SaveProgress();
    }

    private void OnHoverExit()
    {
        if (panelLeaderBoard != null) panelLeaderBoard.SetActive(false);
        if (panel != null) panel.SetActive(false);
    }
}
