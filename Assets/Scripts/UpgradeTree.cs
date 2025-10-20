using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class UpgradeTree : MonoBehaviour
{
    private List<UpgradeNode> nodes;

    public GameObject linePrefab;
    public Transform canvasTransform;
    public MenegerUI menegerUI;



    private void Start()
    {
        for (int i = 1; i < YG2.saves.countBuyPlanet + 1; i++)
        {
            switch (i)
            {
                case 1:
                    nodes = YG2.saves.nodes1;
                    break;
                case 2:
                    nodes = YG2.saves.nodes2;
                    break;
                case 3:
                    nodes = YG2.saves.nodes3;
                    break;
                case 4:
                    nodes = YG2.saves.nodes4;
                    break;
                case 5:
                    nodes = YG2.saves.nodes5;
                    break;
                case 6:
                    nodes = YG2.saves.nodes6;
                    break;
                case 7:
                    nodes = YG2.saves.nodes7;
                    break;
                case 8:
                    nodes = YG2.saves.nodes8;
                    break;
            }
            RePrint(nodes, i);
        }
    }

    private void Update()
    {

    }

    public void Click(int id)
    {
        int idShip = (id >= 100) ? id / 100 : id / 10;
        int idBuff = (id >= 100) ? id % 100 : id % 10;

        // Загрузить нужный список прокачек
        switch (idShip)
        {
            case 1: nodes = YG2.saves.nodes1; break;
            case 2: nodes = YG2.saves.nodes2; break;
            case 3: nodes = YG2.saves.nodes3; break;
            case 4: nodes = YG2.saves.nodes4; break;
            case 5: nodes = YG2.saves.nodes5; break;
            case 6: nodes = YG2.saves.nodes6; break;
            case 7: nodes = YG2.saves.nodes7; break;
            case 8: nodes = YG2.saves.nodes8; break;
        }

        var requiredNode = nodes.Find(n => n.id == idBuff);

        //if (requiredNode == null || requiredNode.upgraded)
        //    return; // Уже прокачано или нет такого

        if (CanUpgrade(idShip, idBuff))
        {
            requiredNode.upgraded = true;
            Transform nodeTransform = transform.GetChild(idShip).GetChild(requiredNode.id - 1);
            Button btn = nodeTransform.GetComponent<Button>();
            if (btn != null) btn.interactable = false;
            menegerUI.VisualizePurchase(true, 0);
            menegerUI.sound.PlaySound(4);
            Buffing(idShip, idBuff);
            UpdateUnlocks(nodes, idShip);
        }
        else
        {
            menegerUI.VisualizePurchase(false, 0);
            menegerUI.sound.PlaySound(3);
        }
    }

   

    public void Buffing(int idShip, int idBuff)
    {
        idShip--;

        if (idShip == 0)
        {
            // Первая планета — 10 узлов
            switch (idBuff)
            {
                case 1: YG2.saves.countBuffsClick[idShip] += 1; break;
                case 2: YG2.saves.countBuffsClick[idShip] += 1; break;
                case 3: YG2.saves.countBuffsClick[idShip] += 1; break;
                case 4: YG2.saves.buffTreeAFKfarm[idShip] = true; break;
                case 5: YG2.saves.buffTreeCloudMine[idShip] = true; break;
                case 6: YG2.saves.countBuffsClick[idShip] += 1; break;
                case 7: YG2.saves.buffTreePrice[idShip] = true; break;
                case 8: YG2.saves.countBuffsClick[idShip] += 1; break;
                case 9: YG2.saves.buffTreeSpeedMine[idShip] = true; break;
                case 10: YG2.saves.buffTreeECO[idShip] = true; break; // Банк
            }
        }
        else
        {
            // Планеты 2-8 — старая логика (13 узлов)
            switch (idBuff - 1)
            {
                case 0: YG2.saves.countBuffsClick[idShip] += 1; break;
                case 1: YG2.saves.countBuffsClick[idShip] += 1; break;
                case 2: YG2.saves.buffTreeSpeedShip[idShip] = true; break;
                case 3: YG2.saves.buffTreeCloudShip[idShip] += 1; break;
                case 4: YG2.saves.countBuffsClick[idShip] += 1; break;
                case 5: YG2.saves.buffTreeCloudShip[idShip] += 1; break;
                case 6: YG2.saves.buffTreeAFKfarm[idShip] = true; break;
                case 7: YG2.saves.buffTreeCloudMine[idShip] = true; break;
                case 8: YG2.saves.countBuffsClick[idShip] += 1; break;
                case 9: YG2.saves.buffTreePrice[idShip] = true; break;
                case 10: YG2.saves.countBuffsClick[idShip] += 1; break;
                case 11: YG2.saves.buffTreeSpeedMine[idShip] = true; break;
                case 12: YG2.saves.buffTreeECO[idShip] = true; break;
            }
        }
    }

    public void UpdateUnlocks(List<UpgradeNode> nodes, int id)
    {
        foreach (var node in nodes)
        {
            if (!node.unlocked)
            {
                bool canUnlock = true;
                foreach (int req in node.requirements)
                {
                    var requiredNode = nodes.Find(n => n.id == req);
                    if (requiredNode == null || !requiredNode.upgraded)
                    {
                        canUnlock = false;
                        break;
                    }
                }
                if (canUnlock)
                {
                    node.unlocked = true;
                    transform.GetChild(id).GetChild(node.id - 1).gameObject.SetActive(true);

                    for (int i = 0; i < node.requirements.Count; i++)
                    {
                        CreateLineBetween(
                    transform.GetChild(id).GetChild(node.requirements[i] - 1).GetComponent<RectTransform>(), // родитель
                    transform.GetChild(id).GetChild(node.id - 1).GetComponent<RectTransform>()  // дочерний узел
                    );

                    }
                    YG2.SaveProgress();
                }
            }
        }
    }


    void CreateLineBetween(RectTransform start, RectTransform end)
    {
        GameObject line = Instantiate(linePrefab, canvasTransform);
        RectTransform rt = line.GetComponent<RectTransform>();

        Vector2 startScreenPos = RectTransformUtility.WorldToScreenPoint(null, start.position);
        Vector2 endScreenPos = RectTransformUtility.WorldToScreenPoint(null, end.position);

        Vector2 localStartPos, localEndPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasTransform as RectTransform, startScreenPos, null, out localStartPos);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasTransform as RectTransform, endScreenPos, null, out localEndPos);

        Vector2 direction = localEndPos - localStartPos;
        float distance = direction.magnitude;

        rt.sizeDelta = new Vector2(distance, rt.sizeDelta.y);
        rt.pivot = new Vector2(0, 0.5f);
        rt.localPosition = localStartPos;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rt.localRotation = Quaternion.Euler(0, 0, angle);
    }

    public void RePrint(List<UpgradeNode> nodes, int id)
    {
        foreach (var node in nodes)
        {
            if (node.unlocked)
            {
                transform.GetChild(id).GetChild(node.id - 1).gameObject.SetActive(true);
                if (node.upgraded)
                {
                    transform.GetChild(id).GetChild(node.id - 1).GetComponent<Button>().interactable = false;
                }
                for (int i = 0; i < node.requirements.Count; i++)
                {
                    CreateLineBetween(
                transform.GetChild(id).GetChild(node.requirements[i] - 1).GetComponent<RectTransform>(), // родитель
                transform.GetChild(id).GetChild(node.id - 1).GetComponent<RectTransform>()  // дочерний узел
                );
                }
            }
        }
    }

    public bool CanUpgrade(int idShip, int idBuff)
    {
        // Проверка на выход за пределы массива
        if (idBuff < 1 || idBuff > Parametrs.upgradeCosts.Length)
            return false;

        int cost = Parametrs.upgradeCosts[idBuff - 1];

        if (YG2.saves.countOre[idShip - 1] >= cost)
        {
            YG2.saves.countOre[idShip - 1] -= cost;
            return true;
        }
        else
        {
            print("Не хватает денег");
            return false;
        }
    }


}
