using UnityEngine;

public class UIPanelController : MonoBehaviour
{
    public RectTransform panel;        // Панель UI для управления

    public Vector2 baseMinPosition = new Vector2(-500, -500);
    public Vector2 baseMaxPosition = new Vector2(500, 500);

    public float minScale = 0.5f;
    public float maxScale = 2f;

    [Range(0f, 5f)]
    public float limitScaleMultiplier = 1f; // Множитель влияния масштаба на ограничения

    private bool isDragging = false;
    private Vector2 lastMousePosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            isDragging = true;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                panel.parent as RectTransform,
                Input.mousePosition,
                null,
                out lastMousePosition);
        }

        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector2 currentMousePosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                panel.parent as RectTransform,
                Input.mousePosition,
                null,
                out currentMousePosition);

            Vector2 delta = currentMousePosition - lastMousePosition;
            Vector3 newPos = panel.localPosition + (Vector3)delta;

            float scale = panel.localScale.x;

            Vector2 minPosition = baseMinPosition * scale * limitScaleMultiplier;
            Vector2 maxPosition = baseMaxPosition * scale * limitScaleMultiplier;

            newPos.x = Mathf.Clamp(newPos.x, minPosition.x, maxPosition.x);
            newPos.y = Mathf.Clamp(newPos.y, minPosition.y, maxPosition.y);

            panel.localPosition = newPos;
            lastMousePosition = currentMousePosition;
        }

        float scroll = Input.mouseScrollDelta.y;
        if (scroll != 0)
        {
            float scale = panel.localScale.x + scroll * 0.1f;
            scale = Mathf.Clamp(scale, minScale, maxScale);
            panel.localScale = new Vector3(scale, scale, 1f);
        }
    }
}
