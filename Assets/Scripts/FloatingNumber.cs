using UnityEngine;
using TMPro; // ���� ����������� TextMeshPro

public class FloatingNumber : MonoBehaviour
{
    public float floatSpeed = 1f; // �������� �������
    public float duration = 1f;   // ����� ����� �����
    private float timer = 0f;

    public void Initialize(int number)
    {

        GetComponent<TextMeshPro>().text = number.ToString();

    }

    void Update()
    {
        // ����������� �����
        transform.position += Vector3.up * floatSpeed * Time.deltaTime;

        // ��������� ����� �����
        timer += Time.deltaTime;
        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }
}