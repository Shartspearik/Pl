using UnityEngine;
using System.Collections;

public class ClickPlanet : MonoBehaviour
{
    public RectTransform panel;  // UI панель для движения
    public float moveDistance = 300f; // Насколько опускаем или поднимаем
    public float moveDuration = 0.3f; // Время движения

    private Vector2 originalPosition;

    void Awake()
    {
        originalPosition = panel.anchoredPosition;
    }

    public void MovePanel(bool moveUp)
    {
        StopAllCoroutines();
        Vector2 targetPos = moveUp
            ? originalPosition
            : originalPosition - new Vector2(0, -moveDistance);

        StartCoroutine(MovePanelCoroutine(targetPos));
    }

    private IEnumerator MovePanelCoroutine(Vector2 targetPosition)
    {
        Vector2 startPos = panel.anchoredPosition;
        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            panel.anchoredPosition = Vector2.Lerp(startPos, targetPosition, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        panel.anchoredPosition = targetPosition;
    }
}
