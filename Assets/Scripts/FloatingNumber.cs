using TMPro; // если используете TextMeshPro
using UnityEngine;

public class FloatingNumber : MonoBehaviour
{
    public float speed = 100f;       // скорость движения вправо (единиц в секунду)
    public float fadeDuration = 2f;  // время исчезновения (секунд)

    private TextMeshProUGUI tmp;
    private Color originalColor;
    private RectTransform rectTransform;
    private float elapsed = 0f;

    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        originalColor = tmp.color;
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        float t = Mathf.Clamp01(elapsed / fadeDuration);

        // Движение вправо
        rectTransform.anchoredPosition += Vector2.down * speed * Time.deltaTime;

        // Затемнение текста
        Color c = originalColor;
        c.a = Mathf.Lerp(1f, 0f, t);
        tmp.color = c;

        // Удаление когда полностью прозрачен
        if (tmp.color.a <= 0.01f)
        {
            Destroy(gameObject);
        }
    }
}