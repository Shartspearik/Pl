using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    public GameObject planetParant;
    public Transform targetPlanet; // ������� ������� (������)
    public float speed = 5f; // �������� �������� �� �����������
    public float rotationSpeed = 200f; // �������� �������� �������
    public float detectionDistance = 2f; // ���������� ��� ����������� �������
    public float orbitRadius = 2f; // ������ ������ (������������ ��� ������� ��������)
    public float orbitSpeed = 100f; // �������� �������� �� ������ (�������� � �������)

    public bool isOrbiting = false;
    private float orbitAngle;
    private Quaternion targetRotation;
    private Transform currentOrbitPlanet;
    public float rangPlanet;

    private float currentOrbitRadius; // ������� ������ ������
    private int orbitDirection = 1; // 1 - �� �������, -1 - ������ �������

    private void Start()
    {
        if (targetPlanet != null)
        {
            rangPlanet = targetPlanet.gameObject.GetComponent<Planet>().radius;
        }
        else
        {
            rangPlanet = 1f; // �������� �� ���������, ���� ������� ������� �� ���������
        }
    }

    void Update()
    {
        if (isOrbiting)
        {
            OrbitAroundPlanet();

            // ��������, ������ �� ������� ������� ���������� ������
            if (!IsPlanetBlocking())
            {
                isOrbiting = false;
            }
            else
            {
                // �������� ���� ����� ������� �������� � ������� ����������� ��������
                if (ArePlanetsAtWideAngle())
                {
                    // ���� ���� >= 90�, ����������� �� ������� �������
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
            currentOrbitPlanet = hit.collider.transform; // ���������� ������� ����������� �������

            // ����� ��������� �� ����� ������� ��������� � ������� ����
            bool isTargetOnRightSide = CalculateAngle();

            // ������������� ����������� ��������
            orbitDirection = isTargetOnRightSide ? 1 : -1;

            return;
        }

        if (targetPlanet == null)
            return;

        Vector2 direction = (targetPlanet.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        targetRotation = Quaternion.Euler(0, 0, angle - 90);

        // ������� �������� � �������� �����������
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.position += transform.up * speed * Time.deltaTime;
    }

    void StartOrbiting(Transform planet)
    {
        isOrbiting = true;
        currentOrbitPlanet = planet;

        Vector3 offset = transform.position - planet.position;
        float currentDistance = offset.magnitude;

        // ������������� ������� ������ ������ ������ �������� ����������
        currentOrbitRadius = currentDistance;

        // ������������, ��� ������� ��������� �� ���������� �������
        if (Mathf.Abs(currentDistance - currentOrbitRadius) > 0.1f)
        {
            float scaleFactor = currentOrbitRadius / currentDistance;
            transform.position = planet.position + offset * scaleFactor;
        }

        orbitAngle = Mathf.Atan2(transform.position.y - planet.position.y,
                                   transform.position.x - planet.position.x) * Mathf.Rad2Deg;

        // ������� �������� ������� � ������� ����������� �����
        Vector3 directionToStartOrbitPoint = new Vector3(
            Mathf.Cos(orbitAngle * Mathf.Deg2Rad),
            Mathf.Sin(orbitAngle * Mathf.Deg2Rad),
            0);

        if (directionToStartOrbitPoint != Vector3.zero)
            targetRotation = Quaternion.LookRotation(Vector3.forward, directionToStartOrbitPoint);

        // ����� ������ ������ ��������� � ������� ���� ����� ������� � �������� ������������ ���� �������

    }

    void OrbitAroundPlanet()
    {
        if (currentOrbitPlanet == null)
            return;

        orbitAngle += orbitSpeed * Time.deltaTime * orbitDirection; // ������� �������� � ��������

        float radian = orbitAngle * Mathf.Deg2Rad;

        float x = Mathf.Cos(radian) * currentOrbitRadius + currentOrbitPlanet.position.x;
        float y = Mathf.Sin(radian) * currentOrbitRadius + currentOrbitPlanet.position.y;

        Vector3 targetPosition = new Vector3(x, y, transform.position.z);

        // ��������� � ������� ����� � ���������� ���������
        float moveSpeed = orbitSpeed; // ����� ��������� �������� ��� �������������
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // �������� � ������� ����������� ��� ���������� �������
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
            return true; // ������� ������ �������� ������

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
        // ������ �� ������� � ������
        Vector2 vectorToShip = (Vector2)(transform.position - currentOrbitPlanet.position);
        // ������ �� ������� � �������
        Vector2 vectorToTarget = (Vector2)(targetPlanet.position - currentOrbitPlanet.position);

        // ��������� ���� ������� ������� ������������ ��� X
        float angleToShip = Mathf.Atan2(vectorToShip.y, vectorToShip.x) * Mathf.Rad2Deg;
        float angleToTarget = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

        // ������� ������� ����� ������
        float deltaAngle = angleToTarget - angleToShip;

        // �������� � ��������� [0, 360]
        if (deltaAngle < 0)
            deltaAngle += 360f;

        return deltaAngle <= 180f;
    }
}
