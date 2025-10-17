using UnityEngine;
using UnityEngine.UI;
using YG;

public class OnOff : MonoBehaviour
{
    public GameObject[] panels;

    bool isOn;

    private void Awake()
    {
        switch (YG2.lang)
        {
            case "ru":
                gameObject.SetActive(true);
                break;
            case "en":
                gameObject.SetActive(true);
                break;
            case "tr":
                gameObject.SetActive(true);
                break;
            case "de":
                gameObject.SetActive(true);
                break;
            case "es":
            gameObject.SetActive(true);
                break;
        }
    }

    public void SetLang(int id)
    {
        if (isOn)
        {
            isOn = false;
            foreach (var item in panels)
            {
                item.SetActive(false);
            }
            panels[id].SetActive(true);
        }
        else
        {
            foreach (var item in panels)
            {
                item.SetActive(true);
            }
            isOn = true;
        }
    }
}
