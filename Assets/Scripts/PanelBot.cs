using UnityEngine;
using UnityEngine.UI;

public class PanelBot : MonoBehaviour
{
    public Sprite iconPick;
    public Sprite iconNoPick;
    public Color defaultColor = new Color32(0x1E, 0x24, 0x40, 255);
    public Color selectedColor = new Color32(0x44, 0x52, 0xD5, 255);

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
    }
}
