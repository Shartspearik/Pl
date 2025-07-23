using UnityEngine;

public class UFOSpawner : MonoBehaviour
{
    public GameObject ufoPrefab;
    public Rect mapBounds = new Rect(-10, -10, 20, 20); // Задай размеры карты
    public float spawnInterval = 2f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnUFO), 1f, spawnInterval);
    }

    void SpawnUFO()
    {
        Vector2 from = GetRandomPerimeterPoint();      // Точка спауна
        Vector2 to = GetOppositePerimeterPoint(from);  // Цель для полёта

        GameObject ufo = Instantiate(ufoPrefab, from, Quaternion.identity);

        UFOMove mover = ufo.GetComponent<UFOMove>();
        mover.targetPos = to;
        mover.speed = Random.Range(3f, 6f);
    }

    // Выбор точки на границе карты
    Vector2 GetRandomPerimeterPoint()
    {
        int side = Random.Range(0, 4);
        switch (side)
        {
            case 0: return new Vector2(Random.Range(mapBounds.xMin, mapBounds.xMax), mapBounds.yMin);
            case 1: return new Vector2(mapBounds.xMax, Random.Range(mapBounds.yMin, mapBounds.yMax));
            case 2: return new Vector2(Random.Range(mapBounds.xMin, mapBounds.xMax), mapBounds.yMax);
            default: return new Vector2(mapBounds.xMin, Random.Range(mapBounds.yMin, mapBounds.yMax));
        }
    }

    // Противоположная периметру точка
    Vector2 GetOppositePerimeterPoint(Vector2 from)
    {
        if (Mathf.Approximately(from.y, mapBounds.yMin))
            return new Vector2(Random.Range(mapBounds.xMin, mapBounds.xMax), mapBounds.yMax);
        if (Mathf.Approximately(from.x, mapBounds.xMax))
            return new Vector2(mapBounds.xMin, Random.Range(mapBounds.yMin, mapBounds.yMax));
        if (Mathf.Approximately(from.y, mapBounds.yMax))
            return new Vector2(Random.Range(mapBounds.xMin, mapBounds.xMax), mapBounds.yMin);
        return new Vector2(mapBounds.xMax, Random.Range(mapBounds.yMin, mapBounds.yMax));
    }
}
