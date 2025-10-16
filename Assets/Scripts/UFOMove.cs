using UnityEngine;
using UnityEngine.EventSystems;
using YG;

public class UFOMove : MonoBehaviour
{
    public Vector2 targetPos;
    public float speed = 5f;
    public MenegerUI menegerUI;

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
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return; // Не обрабатываем, если клик по UI
        }
        menegerUI.sound.PlaySound(1);
        menegerUI.RewardShip();
        Destroy(gameObject);
    }

 


}

