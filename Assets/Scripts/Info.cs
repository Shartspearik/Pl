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
        Debug.Log("Курсор наведён на объект UI");
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
                textName.text = "Рука 2 уровня";
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[0]);
                textInfo.text = "Добыча за клик + 1";
                icone.sprite = iconeOre[idShip];
                break;
            case 1:
                textName.text = "Рука 3 уровня";
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[1]);
                textInfo.text = "Добыча за клик + 2";
                icone.sprite = iconeOre[idShip];
                break;
            case 2:
                textName.text = "Новая формула топлива";
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[2]);
                textInfo.text = "Увеличеная скорость кораблей";
                icone.sprite = iconeOre[idShip];
                break;
            case 3:
                textName.text = "Дополнительный левый отсек";
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[3]);
                textInfo.text = "Большая вместимость кораблей";
                icone.sprite = iconeOre[idShip];
                break;
            case 4:
                textName.text = "Рука 3 уровня";
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[4]);
                textInfo.text = "Добыча за клик + 5";
                icone.sprite = iconeOre[idShip];
                break;
            case 5:
                textName.text = "Дополнительный правый отсек";
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[5]);
                textInfo.text = "Большая вместимость кораблей";
                icone.sprite = iconeOre[idShip];
                break;
            case 6:
                textName.text = "Авто-Добыча";
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[6]);
                textInfo.text = "Добыча руды вне игры";
                icone.sprite = iconeOre[idShip];
                break;
            case 7:
                textName.text = "Большая добыча";
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[7]);
                textInfo.text = "Увеличить добычу руды";
                icone.sprite = iconeOre[idShip];
                break;
            case 8:
                textName.text = "Рука 4 уровня";
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[8]);
                textInfo.text = "Увеличить добычу за клик на 10";
                icone.sprite = iconeOre[idShip];
                break;
            case 9:
                textName.text = "Скидка";
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[9]);
                textInfo.text = "Уменьшить цены на улучшения";
                icone.sprite = iconeOre[idShip];
                break;
            case 10:
                textName.text = "Рука 5 уровня";
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[10]);
                textInfo.text = "Увеличить добычу за клик на 100";
                icone.sprite = iconeOre[idShip];
                break;
            case 11:
                textName.text = "Быстрая добыча";
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[11]);
                textInfo.text = "Увеличить скорость добычи руды";
                icone.sprite = iconeOre[idShip];
                break;
            case 12:
                textName.text = "Вложения";
                textPrice.text = stats.FormatGold(Parametrs.upgradeCosts[12]);
                textInfo.text = "Разблокировать возможность ложить руду под процент";
                icone.sprite = iconeOre[idShip];
                break;
            case 13:
                textName.text = stats.CheckOre(0);

                if(YG2.saves.countBuyPlanet == 1)
                {
                    panel.transform.GetChild(3).gameObject.SetActive(true);
                    textInfo.text = "Необходимо : Изучить все доступные улучшения";
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
                    textInfo.text = "Cамая быстрая планета, Флеш в солнечной системе";
                    panel.transform.GetChild(3).gameObject.SetActive(false);
                }

                break;

            case 14:
                textName.text = stats.CheckOre(1);
                if (YG2.saves.countBuyPlanet == 2)
                {
                    panel.transform.GetChild(3).gameObject.SetActive(true);
                    textInfo.text = "Необходимо : Изучить все доступные улучшения";

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
            textInfo.text = "Горячая планета с атмосферой, будто парилка в сауне, и вечным дымом облаков серной кислоты";
            panel.transform.GetChild(3).gameObject.SetActive(false);
        }
        break;

            case 15:
                textName.text = stats.CheckOre(2);
                if (YG2.saves.countBuyPlanet == 3)
                {
                    panel.transform.GetChild(3).gameObject.SetActive(true);
                    textInfo.text = "Необходимо : Изучить все доступные улучшения";

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
            textInfo.text = "Красный сосед с амбициями стать второй землей, где люди мечтают строить первые колонии";
            panel.transform.GetChild(3).gameObject.SetActive(false);
        }
        break;

            case 16:
                textName.text = stats.CheckOre(3);
                if (YG2.saves.countBuyPlanet == 4)
                {
                    panel.transform.GetChild(3).gameObject.SetActive(true);
                    textInfo.text = "Необходимо : Изучить все доступные улучшения";

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
            textInfo.text = "Огромный гигант, владыка ветров и штормов, чья мощь сдерживает хаос в системе";
            panel.transform.GetChild(3).gameObject.SetActive(false);
        }
        break;

            case 17:
                textName.text = stats.CheckOre(4);
                if (YG2.saves.countBuyPlanet == 5)
                {
                    panel.transform.GetChild(3).gameObject.SetActive(true);
                    textInfo.text = "Необходимо : Изучить все доступные улучшения";

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
            textInfo.text = "Планета с короной из ледяных колец, символ красоты и величия среди соседей";
            panel.transform.GetChild(3).gameObject.SetActive(false);
        }
        break;

            case 18:
                textName.text = stats.CheckOre(5);
                if (YG2.saves.countBuyPlanet == 6)
                {
                    panel.transform.GetChild(3).gameObject.SetActive(true);
                    textInfo.text = "Необходимо : Изучить все доступные улучшения";

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
            textInfo.text = "Уникальный странник, который вращается на боку, как будто игнорирует общие правила";
            panel.transform.GetChild(3).gameObject.SetActive(false);
        }
        break;

            case 19:
                textName.text = stats.CheckOre(6);
                if (YG2.saves.countBuyPlanet == 7)
                {
                panel.transform.GetChild(3).gameObject.SetActive(true);
                textInfo.text = "Необходимо : Изучить все доступные улучшения";

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
                    textInfo.text = "Ледяной и глубокий, где бушуют сильнейшие в Солнечной системе штормы и тайны";
                    panel.transform.GetChild(3).gameObject.SetActive(false);
                }
        break;
            case 20:
                panelLeaderBoard.SetActive(true);
                break;

        case 21:
            textName.text = stats.CheckOre(7);
                textInfo.text = "Космический шар с вечной вечеринкой на ее поверхности";
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
