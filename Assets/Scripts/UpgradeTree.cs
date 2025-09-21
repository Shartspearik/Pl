using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using YG;

public class UpgradeTree : MonoBehaviour
{
    private List<UpgradeNode> nodes;

    public GameObject linePrefab;
    public Transform canvasTransform;


    private void Start()
    {
        for (int i = 1; i < 9; i++)
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
        int idShip = (id >= 100) ? id / 100 : id / 10;      // Номер планеты
        int idBuff = (id >= 100) ? id % 100 : id % 10;

        switch (idShip)
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

        var requiredNode = nodes.Find(n => n.id == idBuff);
        requiredNode.upgraded = true;
        UpdateUnlocks(nodes, idShip);
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


}
