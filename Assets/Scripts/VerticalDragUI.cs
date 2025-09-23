using UnityEngine;
using UnityEngine.EventSystems;

public class VerticalDragUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform panel;         // Панель, которую перетаскиваем
    public float minY;                  // Минимальное значение по Y
    public float maxY;                  // Максимальное значение по Y

    private bool dragging = false;
    private Vector2 pointerOffset;

    public void OnPointerDown(PointerEventData eventData)
    {
        // Проверяем, зажата ли правая кнопка мыши
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            dragging = true;

            // Вычисляем смещение курсора относительно панели
            RectTransformUtility.ScreenPointToLocalPointInRectangle(panel, eventData.position, eventData.pressEventCamera, out pointerOffset);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            dragging = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!dragging)
            return;

        Vector2 localPointerPos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(panel.parent as RectTransform, eventData.position, eventData.pressEventCamera, out localPointerPos))
        {
            float clampedY = Mathf.Clamp(localPointerPos.y - pointerOffset.y, minY, maxY);

            Vector3 newPos = panel.localPosition;
            newPos.y = clampedY;
            panel.localPosition = newPos;
        }
    }
}
