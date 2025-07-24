using UnityEngine;
using UnityEngine.UI;

public class ScrollSnapController : MonoBehaviour
{
   
    public ScrollRect scrollRect;          // ScrollRect компонента
    public RectTransform content;          // Content внутри ScrollRect
    public RectTransform[] items;          // Элементы внутри content (должны быть прямыми детьми)
    public float smoothSpeed = 10f;        // Скорость плавного смещения

    private int currentIndex = 0;          // Текущий выбранный элемент
    private bool isScrolling = false;
    private Vector2 targetPosition;

    //void Start()
    //{
    //    // Можно автоматом получить элементы, если не задали вручную:
    //    if (items == null || items.Length == 0)
    //    {
    //        items = new RectTransform[content.childCount];
    //        for (int i = 0; i < content.childCount; i++)
    //            items[i] = content.GetChild(i).GetComponent<RectTransform>();
    //    }
    //    SnapToElement(currentIndex);
    //}

    void Update()
    {
        if (isScrolling)
        {
            content.anchoredPosition = Vector2.Lerp(content.anchoredPosition, targetPosition, Time.deltaTime * smoothSpeed);
            if (Vector2.Distance(content.anchoredPosition, targetPosition) < 0.1f)
            {
                content.anchoredPosition = targetPosition;
                isScrolling = false;
            }
        }
    }

    public void ScrollLeft()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            SnapToElement(currentIndex);
        }
    }

    public void ScrollRight()
    {
        if (currentIndex < items.Length - 1)
        {
            currentIndex++;
            SnapToElement(currentIndex);
        }
    }

    private void SnapToElement(int index)
    {
        // Позиция выбранного элемента в локальной системе координат content
        Vector3 elementLocalPos = items[index].localPosition;

        // Центр viewport в локальной системе координат контента (обычно (0,0), если pivot по центру)
        Vector2 viewportLocalCenter = Vector2.zero;

        // Разница позиции элемента и центра viewport - чтобы элемент был по центру
        Vector2 difference = (Vector2)elementLocalPos - viewportLocalCenter;

        // Новая цель для content, сдвигаем в противоположную сторону от разницы (учитываем, что content движется)
        targetPosition = content.anchoredPosition - difference;

        isScrolling = true;
    }
}

