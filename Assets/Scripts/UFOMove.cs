using UnityEngine;
using YG;

public class UFOMove : MonoBehaviour
{
    public Vector2 targetPos;
    public float speed = 5f;

    void Update()
    {
        // Двигаемся к цели
        Vector2 currentPosition = transform.position;
        Vector2 direction = (targetPos - currentPosition).normalized;

        // Поворачиваем объект в сторону движения
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Перемещаем объект
        transform.position = Vector2.MoveTowards(currentPosition, targetPos, speed * Time.deltaTime);

        // Удаляем при достижении цели
        if (Vector2.Distance(currentPosition, targetPos) < 0.1f)
            Destroy(gameObject);
    }

    void OnMouseDown()
    {
        ShowAdvReward();
        Destroy(gameObject);
    }

    public void ShowAdvReward()
    {
        string id = "coin"; // Передача id требуется для внутренней работы плагина
        YG2.RewardedAdvShow(id, Reward);
    }

    public void Reward()
    {
        print(1);
    }
}

