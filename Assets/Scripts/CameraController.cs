using UnityEngine;
using UnityEngine.EventSystems;
using YG;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 10f; // скорость перемещени€
    public float speedCamera;
    public float zoomSpeed = 2f;
    public float minSize = 2f;
    public float maxSize = 20f;

    public Vector2 minPosition;
    public Vector2 maxPosition;

    private Camera cam;

    private Vector3? targetPosition = null;
    private float targetZoom;

    public Transform targetPlanet = null;
    private bool followingPlanet = false;

    private bool isDragging = false;
    private Vector3 dragStartMouseWorldPos; // точка в мире при начале перетаскивани€
    private Vector3 dragStartCameraPos;     // позици€ камеры при начале
    private bool isReturning;
    public bool isOn;
    public ClickPlanet clickPlanet;
    public Stats stats;

    public MenegerUI menegerUI;

    void Start()
    {
        cam = Camera.main;
        targetZoom = cam.orthographicSize;
    }

    void Update()
    {
        if (!isOn) return;
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return; // Ќе обрабатываем, если клик по UI
        }
        HandleMouseDrag();

        HandleZoom();

        if (targetPosition.HasValue)
        {
            MoveTowardsTarget();
        }
        else if (followingPlanet && targetPlanet != null)
        {
            FollowPlanet();
        }
        else if (isReturning)
        {
            ReturnToInitial();
        }

        ClampPosition();

        DetectPlanetClick();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToInitial();
            clickPlanet.MovePanel(true);

        }
    }

    void HandleMouseDrag()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            isDragging = true;
            dragStartMouseWorldPos = GetMouseWorldPosition();
            dragStartCameraPos = transform.position;
        }
        else if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 currentMouseWorldPos = GetMouseWorldPosition();

            // »спользуем SmoothDamp дл€ плавного движени€
            Vector3 targetPos = dragStartCameraPos + (dragStartMouseWorldPos - currentMouseWorldPos);
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speedCamera);
        }
    }


    Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPos = Input.mousePosition;

        // ƒл€ ортографической камеры z-координата должна быть равна рассто€нию от камеры до плоскости мира.
        // ¬ 2D обычно камера находитс€ на z=-10, а объекты на z=0.
        mouseScreenPos.z = Mathf.Abs(cam.transform.position.z);

        return cam.ScreenToWorldPoint(mouseScreenPos);
    }

    void HandleZoom()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0f && cam != null && cam.orthographic)
        {
            float dynamicZoomSpeed = zoomSpeed * cam.orthographicSize;

            float newSize = cam.orthographicSize - scrollInput * dynamicZoomSpeed;
            newSize = Mathf.Clamp(newSize, minSize, maxSize);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newSize, Time.deltaTime * zoomSpeed);
            targetZoom = newSize;
        }

        if (targetPosition.HasValue && cam != null && cam.orthographic)
        {
            float currentSize = cam.orthographicSize;
            cam.orthographicSize = Mathf.Lerp(currentSize, targetZoom, Time.deltaTime * zoomSpeed);
        }
    }

    void MoveTowardsTarget()
    {
        Vector3 currentPos = transform.position;
        Vector3 targetPos = targetPosition.Value;

        float zoomRatio = Mathf.InverseLerp(minSize, maxSize, cam.orthographicSize);

        float minMultiplier = 0.5f;
        float maxMultiplier = 3f;

        float speedMultiplier = Mathf.Lerp(minMultiplier, maxMultiplier, zoomRatio);

        float step = moveSpeed * speedMultiplier * Time.deltaTime;

        transform.position = Vector3.MoveTowards(currentPos, targetPos, step);

        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            followingPlanet = true;
            targetPosition = null;
            if (targetPlanet.GetComponent<Planet>().idPlanet + 2 <= YG2.saves.countBuyPlanet || targetPlanet.GetComponent<Planet>().idPlanet == 7)
            {
                for (int i = 0; i < 5; i++)
                {
                    menegerUI.buttons[2].SetActive(targetPlanet.GetComponent<Planet>().idPlanet != 7);
                    menegerUI.buttons[3].SetActive(targetPlanet.GetComponent<Planet>().idPlanet != 7);
                    menegerUI.buttons[4].SetActive(targetPlanet.GetComponent<Planet>().idPlanet != 7);
                    stats.PrintPrice(i + 1);
                }

                clickPlanet.MovePanel(false);
            }
        }
    }

    void FollowPlanet()
    {
        if (targetPlanet != null)
        {
            Vector3 planetPos2D = new Vector3(targetPlanet.position.x, targetPlanet.position.y, transform.position.z);

            float zoomRatio = Mathf.InverseLerp(targetPlanet.GetComponent<Planet>().radius * 2.5f, maxSize, cam.orthographicSize);
            float minMultiplier = 0.5f;
            float maxMultiplier = 3f;

            float speedMultiplier = Mathf.Lerp(minMultiplier, maxMultiplier, zoomRatio);

            float step = moveSpeed * speedMultiplier * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, planetPos2D, step);

            // ѕлавное приближение к минимальному зуму при следовании
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetPlanet.GetComponent<Planet>().radius * 5f, Time.deltaTime * zoomSpeed);
        }
    }

    void DetectPlanetClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseScreenPos = Input.mousePosition;
            mouseScreenPos.z = Mathf.Abs(cam.transform.position.z);
            Vector3 worldPos = cam.ScreenToWorldPoint(mouseScreenPos);

            RaycastHit2D hit = Physics2D.Raycast(worldPos, new Vector2(0, 0));

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Planet") && hit.transform != targetPlanet && hit.collider.GetComponent<Planet>().idPlanet != 100)
                {
                    menegerUI.ClickPlanet(hit.collider.GetComponent<Planet>().idPlanet);
                }
            }
        }
    }

    public void ClickPlanet(Transform obj)
    {
        if (targetPlanet != null && targetPlanet == obj)
        {
            ReturnToInitial();
        }
        else
        {
            targetPlanet = obj;
            Vector3 planetPos2D = new Vector3(targetPlanet.position.x, targetPlanet.position.y, transform.position.z);
            targetPosition = planetPos2D;
            targetZoom = minSize;
            followingPlanet = false;

            var planetComponent = targetPlanet.GetComponent<Planet>();
            if (planetComponent != null) 
            {
                foreach (Planet item in menegerUI.planets)
                {
                    item.isCurrent = false;
                }
                targetPlanet.GetComponent<Planet>().isCurrent = true;
            }

        }
    }

    void ReturnToInitial()
    {
        followingPlanet = false;
        targetPlanet = null;
        menegerUI.OffPanelPlanet();
        // ѕлавно интерполируем позицию и зум обратно к начальному состо€нию

        //transform.position = Vector3.Lerp(transform.position, new Vector3(0,0,-10), Time.deltaTime * moveSpeed);
        //cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 10, Time.deltaTime * zoomSpeed);

        transform.position = new Vector3(0, 0, -10);
        cam.orthographicSize = 10;

        // ѕровер€ем достижение цели с учетом погрешности
        //if (Vector3.Distance(transform.position, new Vector3(0, 0, -10)) < 0.01f &&
        //   Mathf.Abs(cam.orthographicSize - 10) < 0.01f)
        //{
        isReturning = false; // завершили возврат
        //}
    }

    void ClampPosition()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, minPosition.x, maxPosition.x);
        pos.y = Mathf.Clamp(pos.y, minPosition.y, maxPosition.y);

        transform.position = pos;
    }
    public void ResetOn()
    {
        isOn = !isOn;
    }
}