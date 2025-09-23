using UnityEngine;

public class Top : MonoBehaviour
{
    public float amplitude = 1f;  // амплитуда движения
    public float frequency = 1f;  // частота движения

    private Vector3 startLocalPosition;

    void Start()
    {
        // Сохраняем начальное локальное положение относительно родителя
        startLocalPosition = transform.localPosition;
    }

    void Update()
    {
        // Смещение по оси Y относительно родителя с помощью синусоиды
        float offsetY = amplitude * Mathf.Sin(Time.time * frequency * 2 * Mathf.PI);

        // Обновляем локальную позицию объекта - относительно родителя
        transform.localPosition = startLocalPosition + new Vector3(0, offsetY, 0);
    }
}
