using UnityEngine;
using UnityEngine.UI;

public class ScrollSnapController : MonoBehaviour
{
    public RectTransform content;          
    public GameObject buttonLeft;          
    public GameObject buttonRight;
    public int count = 0;

    public float smoothSpeed = 10f;        // Скорость плавного смещения

    private bool isScrolling = false;
    private Vector2 targetPosition;

    private void Start()
    {
        OffSet();
    }

    public void OffSet()
    {
        buttonLeft.SetActive(true);
        buttonRight.SetActive(true);
        if (count <= 0)
        {
            buttonRight.SetActive(false);
        }
        if (count >= 6)
        {
            buttonLeft.SetActive(false);
        }
    }

    void Update()
    {
        if (isScrolling)
        {
            content.anchoredPosition = Vector2.Lerp(content.anchoredPosition, targetPosition, Time.deltaTime * smoothSpeed);
            if (Vector2.Distance(content.anchoredPosition, targetPosition) < 0.1f)
            {
                
                content.anchoredPosition = targetPosition;
                isScrolling = false;
            }
        }
    }

    public void ScrollLeft()
    {
        if (!isScrolling)
        {
            count--;
            targetPosition = content.anchoredPosition + new Vector2(900, 0);
            isScrolling = true;
            OffSet();
        }
    }

    public void ScrollRight()
    {
        if (!isScrolling)
        {
            count++;
            targetPosition = content.anchoredPosition - new Vector2(900, 0);
            isScrolling = true;
            OffSet();
        }
    }
}

