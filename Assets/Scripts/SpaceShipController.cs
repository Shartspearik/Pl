using UnityEngine;
using YG;

public class SpaceShipController : MonoBehaviour
{
    public GameObject planetParant;
    public Transform targetPlanet; // Целевая планета (таргет)
    public float speed = 5f; // Скорость движения по направлению
    public float rotationSpeed = 200f; // Скорость вращения корабля
    public float detectionDistance = 0.1f; // Очень маленькое расстояние — как ты хочешь!
    public float orbitRadius = 2f; // Не используется напрямую
    public float orbitSpeed = 100f; // Скорость вращения по орбите (градусов в секунду)

    public bool isOrbiting = false;
    private float orbitAngle;
    private Quaternion targetRotation;
    private Transform currentOrbitPlanet;
    public float rangPlanet;
    public Stats stats;
    public MenegerUI menegerUI;
    public GameObject earth;

    public int attack;
    public int HP;
    public int HPRegen;
    public int id;

    private float currentOrbitRadius; // Текущий радиус орбиты
    private int orbitDirection = 1; // 1 - по часовой, -1 - против часовой
    private bool orbitDirectionSet = false;

    private void Start()
    {
        if (targetPlanet != null)
        {
            rangPlanet = targetPlanet.gameObject.GetComponent<Planet>().radius;
        }
        else
        {
            rangPlanet = 1f;
        }
    }

    void Update()
    {
        if (isOrbiting)
        {
            OrbitAroundPlanet();

            if (!IsPlanetBlocking())
            {
                isOrbiting = false;
                orbitDirectionSet = false;
            }
            else
            {
                if (ArePlanetsAtWideAngle())
                {
                    isOrbiting = false;
                    orbitDirectionSet = false;
                }
            }
        }
        else
        {
            DetectPlanetAndMove();

            if (targetPlanet != null && Vector2.Distance(transform.position, targetPlanet.position) < detectionDistance)
            {
                targetPlanet.GetComponent<Planet>().FinishShip();

                if (targetPlanet.gameObject == earth)
                {
                    menegerUI.PrintOre(id);
                }
                else
                {
                    YG2.saves.countShip[id - 1]++;
                }
                YG2.saves.shipFly[id - 1]--;
                Destroy(gameObject);
            }
        }
    }

    void DetectPlanetAndMove()
    {
        // Используем очень короткий луч (0.1f)
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, detectionDistance);
        if (hit.collider != null &&
            hit.collider.CompareTag("Planet") &&
            hit.collider.gameObject != targetPlanet?.gameObject &&
            hit.collider.gameObject != planetParant)
        {
            // Начинаем орбиту немедленно — даже если внутри
            StartOrbiting(hit.collider.transform);
            currentOrbitPlanet = hit.collider.transform;
            return;
        }

        if (targetPlanet == null) return;

        Vector2 direction = (targetPlanet.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        targetRotation = Quaternion.Euler(0, 0, angle - 90);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void StartOrbiting(Transform planet)
    {
        isOrbiting = true;
        currentOrbitPlanet = planet;

        Planet planetScript = planet.GetComponent<Planet>();
        float planetRadius = planetScript != null ? planetScript.radius : 1f;

        Vector3 offset = transform.position - planet.position;
        float currentDistance = offset.magnitude;

        // 🔥 Устанавливаем минимальный радиус орбиты, НО НЕ перемещаем корабль!
        currentOrbitRadius = Mathf.Max(currentDistance, planetRadius + 0.1f);

        // 🔥 ВАЖНО: НЕ меняем transform.position — корабль остаётся на месте!

        orbitAngle = Mathf.Atan2(transform.position.y - planet.position.y,
                                 transform.position.x - planet.position.x) * Mathf.Rad2Deg;

        // Пересчитываем направление облёта
        orbitDirectionSet = false;
        bool isTargetOnRightSide = CalculateAngle();
        orbitDirection = isTargetOnRightSide ? 1 : -1;
        orbitDirectionSet = true;

        // Ориентация корабля по касательной
        Vector3 directionToStart = new Vector3(
            Mathf.Cos(orbitAngle * Mathf.Deg2Rad),
            Mathf.Sin(orbitAngle * Mathf.Deg2Rad),
            0
        );
        if (directionToStart != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(Vector3.forward, directionToStart);
            transform.rotation = targetRotation;
        }
    }

    void OrbitAroundPlanet()
    {
        if (currentOrbitPlanet == null) return;

        orbitAngle += orbitSpeed * Time.deltaTime * orbitDirection;
        float radian = orbitAngle * Mathf.Deg2Rad;

        float x = Mathf.Cos(radian) * currentOrbitRadius + currentOrbitPlanet.position.x;
        float y = Mathf.Sin(radian) * currentOrbitRadius + currentOrbitPlanet.position.y;
        Vector3 targetPosition = new Vector3(x, y, transform.position.z);

        // Двигаемся к точке орбиты с текущей скоростью
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Ориентация по касательной
        Vector3 tangentDirection = new Vector3(-Mathf.Sin(radian), Mathf.Cos(radian), 0);
        if (tangentDirection != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(Vector3.forward, tangentDirection * orbitDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    // 🔥 Исправлено: не используем Raycast с 0.1f — он бесполезен
    bool IsPlanetBlocking()
    {
        if (currentOrbitPlanet == null) return false;

        float distanceToCenter = Vector2.Distance(transform.position, currentOrbitPlanet.position);
        Planet planetScript = currentOrbitPlanet.GetComponent<Planet>();
        float planetRadius = planetScript != null ? planetScript.radius : 1f;

        // Планета "блокирует", пока корабль близко к ней
        return distanceToCenter < planetRadius + 0.5f;
    }

    bool ArePlanetsAtWideAngle()
    {
        if (targetPlanet == null || currentOrbitPlanet == null) return false;

        Vector2 toTarget = (Vector2)(targetPlanet.position - transform.position);
        Vector2 toCurrent = (Vector2)(currentOrbitPlanet.position - transform.position);

        float dot = Vector2.Dot(toTarget.normalized, toCurrent.normalized);
        dot = Mathf.Clamp(dot, -1f, 1f);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
        return angle >= 90f;
    }

    bool CalculateAngle()
    {
        Vector2 vectorToShip = (Vector2)(transform.position - currentOrbitPlanet.position);
        Vector2 vectorToTarget = (Vector2)(targetPlanet.position - currentOrbitPlanet.position);

        float angleToShip = Mathf.Atan2(vectorToShip.y, vectorToShip.x) * Mathf.Rad2Deg;
        float angleToTarget = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

        float deltaAngle = angleToTarget - angleToShip;
        if (deltaAngle < 0) deltaAngle += 360f;

        return deltaAngle <= 180f;
    }
}