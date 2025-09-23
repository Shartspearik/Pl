using UnityEngine;

public class Spin : MonoBehaviour
{
    // Скорость вращения в градусах в секунду
    public float rotationSpeed = 100f;

    void Update()
    {
        // Вращаем объект вокруг оси Y с заданной скоростью
        transform.Rotate(0, 0 , rotationSpeed * Time.deltaTime);
    }
}