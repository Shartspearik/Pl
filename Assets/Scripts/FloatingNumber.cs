using UnityEngine;
using TMPro; // если используете TextMeshPro

public class FloatingNumber : MonoBehaviour
{
    public float floatSpeed = 1f; // скорость подъема
    public float duration = 1f;   // время жизни цифры
    private float timer = 0f;

    public void Initialize(int number)
    {

        GetComponent<TextMeshPro>().text = number.ToString();

    }

    void Update()
    {
        // Поднимаемся вверх
        transform.position += Vector3.up * floatSpeed * Time.deltaTime;

        // Уменьшаем время жизни
        timer += Time.deltaTime;
        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }
}