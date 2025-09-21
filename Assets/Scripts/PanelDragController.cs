using UnityEngine;
using UnityEngine.EventSystems;

public class PanelDragController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform panelRectTransform;

    public float zoomSpeed = 0.1f;
    public float minZoom = 0.5f;
    public float maxZoom = 2.0f;

    public float minX = -200f;  // минимальная позиция по X в локальных координатах
    public float maxX = 200f;   // максимальная позиция по X
    public float minY = -150f;  // минимальная позиция по Y
    public float maxY = 150f;   // максимальная позиция по Y

    private bool isDragging = false;
    private Vector2 pointerOffset;
    private Canvas canvas;

    void Awake()
    {
        if (panelRectTransform == null)
            panelRectTransform = GetComponent<RectTransform>();

        canvas = GetComponentInParent<Canvas>();
        if (canvas == null)
            Debug.LogError("Canvas not found");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            isDragging = true;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out Vector2 localPointerPosition);
            pointerOffset = (Vector2)panelRectTransform.localPosition - localPointerPosition;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
            isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                Input.mousePosition,
                canvas.worldCamera,
                out Vector2 localPointerPosition))
            {
                Vector2 newPos = localPointerPosition + pointerOffset;

                // Ограничение позиции по заданным границам
                newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
                newPos.y = Mathf.Clamp(newPos.y, minY, maxY);

                panelRectTransform.localPosition = newPos;
            }
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            float scale = panelRectTransform.localScale.x + scroll * zoomSpeed;
            scale = Mathf.Clamp(scale, minZoom, maxZoom);
            panelRectTransform.localScale = new Vector3(scale, scale, 1f);
        }
    }
}
