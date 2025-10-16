using UnityEngine;

public class Click : MonoBehaviour
{
    public float downDistance = 0.1f;   // Расстояние опускания вниз
    public float upDistance = 0.2f;     // Расстояние подъёма выше начальной позиции
    public float moveSpeed = 5f;        // Скорость движения

    private Vector3 startPos;
    private Vector3 downPos;
    private Vector3 upPos;

    private enum State { MovingDown, MovingUp, Done }
    private State currentState;

    void Start()
    {
        startPos = transform.position;
        downPos = startPos + Vector3.down * downDistance;
        upPos = startPos + Vector3.up * upDistance;

        currentState = State.MovingDown;
    }

    void Update()
    {
        switch (currentState)
        {
            case State.MovingDown:
                transform.position = Vector3.MoveTowards(transform.position, downPos, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, downPos) < 0.01f)
                {
                    currentState = State.MovingUp;
                }
                break;

            case State.MovingUp:
                transform.position = Vector3.MoveTowards(transform.position, upPos, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, upPos) < 0.01f)
                {
                    currentState = State.Done;
                }
                break;

            case State.Done:
                Destroy(gameObject);
                break;
        }
    }
}

