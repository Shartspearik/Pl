using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    public GameObject planetParant;
    public Transform targetPlanet; // Целевая планета (таргет)
    public float speed = 5f; // Скорость движения по направлению
    public float rotationSpeed = 200f; // Скорость вращения корабля
    public float detectionDistance = 2f; // Расстояние для обнаружения планеты
    public float orbitRadius = 2f; // Радиус орбиты (используется как базовое значение)
    public float orbitSpeed = 100f; // Скорость вращения по орбите (градусов в секунду)

    public bool isOrbiting = false;
    private float orbitAngle;
    private Quaternion targetRotation;
    private Transform currentOrbitPlanet;
    public float rangPlanet;

    private float currentOrbitRadius; // Текущий радиус орбиты
    private int orbitDirection = 1; // 1 - по часовой, -1 - против часовой

    private void Start()
    {
        if (targetPlanet != null)
        {
            rangPlanet = targetPlanet.gameObject.GetComponent<Planet>().radius;
        }
        else
        {
            rangPlanet = 1f; // Значение по умолчанию, если целевая планета не назначена
        }
    }

    void Update()
    {
        if (isOrbiting)
        {
            OrbitAroundPlanet();

            // Проверка, мешает ли текущая планета продолжать орбиту
            if (!IsPlanetBlocking())
            {
                isOrbiting = false;
            }
            else
            {
                // Проверка угла между целевой планетой и текущей орбитальной планетой
                if (ArePlanetsAtWideAngle())
                {
                    // Если угол >= 90°, отцепляемся от текущей планеты
                    isOrbiting = false;
                }
            }
        }
        else
        {
            DetectPlanetAndMove();

            if (targetPlanet != null && Vector2.Distance(transform.position, targetPlanet.position) < detectionDistance)
            {
                Destroy(gameObject);
            }
        }
    }

    void DetectPlanetAndMove()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, detectionDistance);
        if (hit.collider != null && hit.collider.CompareTag("Planet") && hit.collider.gameObject != targetPlanet.gameObject && hit.collider.gameObject != planetParant)
        {
            StartOrbiting(hit.collider.transform);
            currentOrbitPlanet = hit.collider.transform; // запоминаем текущую орбитальную планету

            // После попадания на новую планету вычисляем и выводим угол
            bool isTargetOnRightSide = CalculateAngle();

            // Устанавливаем направление вращения
            orbitDirection = isTargetOnRightSide ? 1 : -1;

            return;
        }

        if (targetPlanet == null)
            return;

        Vector2 direction = (targetPlanet.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        targetRotation = Quaternion.Euler(0, 0, angle - 90);

        // Плавное вращение к целевому направлению
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.position += transform.up * speed * Time.deltaTime;
    }

    void StartOrbiting(Transform planet)
    {
        isOrbiting = true;
        currentOrbitPlanet = planet;

        Vector3 offset = transform.position - planet.position;
        float currentDistance = offset.magnitude;

        // Устанавливаем текущий радиус орбиты равным текущему расстоянию
        currentOrbitRadius = currentDistance;

        // Обеспечиваем, что позиция находится на правильном радиусе
        if (Mathf.Abs(currentDistance - currentOrbitRadius) > 0.1f)
        {
            float scaleFactor = currentOrbitRadius / currentDistance;
            transform.position = planet.position + offset * scaleFactor;
        }

        orbitAngle = Mathf.Atan2(transform.position.y - planet.position.y,
                                   transform.position.x - planet.position.x) * Mathf.Rad2Deg;

        // Плавное вращение корабля в сторону орбитальной точки
        Vector3 directionToStartOrbitPoint = new Vector3(
            Mathf.Cos(orbitAngle * Mathf.Deg2Rad),
            Mathf.Sin(orbitAngle * Mathf.Deg2Rad),
            0);

        if (directionToStartOrbitPoint != Vector3.zero)
            targetRotation = Quaternion.LookRotation(Vector3.forward, directionToStartOrbitPoint);

        // После начала орбиты вычисляем и выводим угол между ракетой и таргетом относительно этой планеты

    }

    void OrbitAroundPlanet()
    {
        if (currentOrbitPlanet == null)
            return;

        orbitAngle += orbitSpeed * Time.deltaTime * orbitDirection; // Угловая скорость в градусах

        float radian = orbitAngle * Mathf.Deg2Rad;

        float x = Mathf.Cos(radian) * currentOrbitRadius + currentOrbitPlanet.position.x;
        float y = Mathf.Sin(radian) * currentOrbitRadius + currentOrbitPlanet.position.y;

        Vector3 targetPosition = new Vector3(x, y, transform.position.z);

        // Двигаемся к целевой точке с постоянной скоростью
        float moveSpeed = orbitSpeed; // Можно настроить отдельно при необходимости
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Вращение в сторону касательной для ориентации корабля
        Vector3 tangentDirection = new Vector3(-Mathf.Sin(radian), Mathf.Cos(radian), 0);

        if (tangentDirection != Vector3.zero)
            targetRotation = Quaternion.LookRotation(Vector3.forward, tangentDirection);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    bool IsPlanetBlocking()
    {
        if (currentOrbitPlanet == null)
            return false;

        Vector2 directionToPlanet = (currentOrbitPlanet.position - transform.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlanet, detectionDistance);

        if (hit.collider != null && hit.collider.CompareTag("Planet"))
            return true; // Планета мешает движению вперед

        return false;
    }

    bool ArePlanetsAtWideAngle()
    {
        if (targetPlanet == null || currentOrbitPlanet == null)
            return false;

        Vector2 toTargetPlanets = targetPlanet.position - transform.position;
        Vector2 toCurrentPlanets = currentOrbitPlanet.position - transform.position;

        float dotProduct = Vector2.Dot(toTargetPlanets.normalized, toCurrentPlanets.normalized);
        dotProduct = Mathf.Clamp(dotProduct, -1f, 1f);
        float angleDeg = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

        return angleDeg >= 90f;
    }
    bool CalculateAngle()
    {
        // Вектор от планеты к ракете
        Vector2 vectorToShip = (Vector2)(transform.position - currentOrbitPlanet.position);
        // Вектор от планеты к таргету
        Vector2 vectorToTarget = (Vector2)(targetPlanet.position - currentOrbitPlanet.position);

        // Вычисляем углы каждого вектора относительно оси X
        float angleToShip = Mathf.Atan2(vectorToShip.y, vectorToShip.x) * Mathf.Rad2Deg;
        float angleToTarget = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

        // Находим разницу между углами
        float deltaAngle = angleToTarget - angleToShip;

        // Приводим к диапазону [0, 360]
        if (deltaAngle < 0)
            deltaAngle += 360f;

        return deltaAngle <= 180f;
    }
}
