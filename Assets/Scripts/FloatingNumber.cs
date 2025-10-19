using TMPro;
using UnityEngine;

public class FloatingNumber3D : MonoBehaviour
{
    public float speed = 1f;       // скорость движения вниз (единиц в секунду)
    public float fadeDuration = 2f; // время исчезновения (секунд)

    private TextMeshPro tmp;
    private Color originalColor;
    private float elapsed = 0f;

    void Start()
    {
        tmp = GetComponent<TextMeshPro>();
        originalColor = tmp.color;
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        float t = Mathf.Clamp01(elapsed / fadeDuration);

        // Движение вниз по оси Y
        transform.position += Vector3.down * speed * Time.deltaTime;

        // Затемнение текста
        Color c = originalColor;
        c.a = Mathf.Lerp(1f, 0f, t);
        tmp.color = c;

        // Удаление объекта, когда прозрачность близка к 0
        if (tmp.color.a <= 0.01f)
        {
            Destroy(gameObject);
        }
    }
}
