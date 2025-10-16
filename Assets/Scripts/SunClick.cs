using UnityEngine;

public class SunClick : MonoBehaviour
{
    public GameObject panelTree;
    CameraController cameraController;
    private void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
    }
    private void OnMouseDown()
    {
        panelTree.SetActive(true);
        cameraController.ResetOn();
    }
}
