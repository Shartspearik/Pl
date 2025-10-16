using UnityEngine;

public class ShopClick : MonoBehaviour
{
    public GameObject panelShop;
    CameraController cameraController;
    public MenegerUI menegerUI;

    private void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
    }
    private void OnMouseDown()
    {
        panelShop.SetActive(true);
        menegerUI.sound.PlaySound(1);
        cameraController.ResetOn();
    }
}
