using System.Collections;
using TMPro;
using UnityEngine;
using YG;

public class InterstitialAdv : MonoBehaviour
{
    public float interval = 4f;
    public GameObject panelAds;

    void Start()
    {
        StartCoroutine(TimerCoroutine());
    }

    IEnumerator TimerCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            panelAds.SetActive(true);
            panelAds.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Реклама через 3";
            yield return new WaitForSeconds(1);
            panelAds.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Реклама через 2";
            yield return new WaitForSeconds(1);
            panelAds.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Реклама через 1";
            yield return new WaitForSeconds(1);
            YG2.InterstitialAdvShow();
            panelAds.SetActive(false);
        }
    }
}
