using UnityEngine;
using UnityEngine.UI;

public class PanelBot : MonoBehaviour
{
    public Sprite iconPick;
    public Sprite iconNoPick;
    public Color defaultColor = new Color32(0x1E, 0x24, 0x40, 255);
    public Color selectedColor = new Color32(0x44, 0x52, 0xD5, 255);
    public MenegerUI menegerUI;

    public GameObject[] panels;
    public GameObject panelPlanetRight;
    public GameObject panelOre;

    public void Pick(int id)
    {
        for (int i = 0; i < 5; i++)
        {
            Transform child = transform.GetChild(i);
            RectTransform rt = child.GetComponent<RectTransform>();
            Image img = child.GetComponent<Image>();

            rt.sizeDelta = new Vector2(rt.sizeDelta.x, i == id ? 165 : 150);
            img.sprite = (i == id) ? iconPick : iconNoPick;
            img.color = (i == id) ? selectedColor : defaultColor;
        }
        menegerUI.isPanel = (id == 2 || id == 1) ? true : false;
        // ”правление видимостью панелей
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }

        if (id == 0)
        {
            panels[0].SetActive(true);
            panelPlanetRight.SetActive(false);
            panelOre.SetActive(false);
        }
        else if (id == 1)
        {
            panels[1].SetActive(true);
            panelPlanetRight.SetActive(true);
            panelOre.SetActive(true);
        }
        else if (id == 2)
        {
            panelPlanetRight.SetActive(true);
            panelOre.SetActive(true);
        }
        else if (id == 3)
        {
            panels[2].SetActive(true);
            panelPlanetRight.SetActive(false);
            panelOre.SetActive(true);
        }
        else if (id == 4)
        {
            panels[3].SetActive(true);
            panelPlanetRight.SetActive(false);
            panelOre.SetActive(true);
        }
    }
}
