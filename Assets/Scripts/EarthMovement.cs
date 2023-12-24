using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EarthMovement : MonoBehaviour
{
    private Controls controls;
    public CinemachineVirtualCamera vCam;

    //Zooming
    [SerializeField] private float targetFOV = 50f;
    [SerializeField] private float zoomSpeed = 10f;

    [SerializeField] private float maxFOV = 50f;
    [SerializeField] private float minFOV = 10f;

    //Screen X
    [SerializeField] private float centeredX = 0.5f;
    [SerializeField] private float leftX = 0.33f;

    //Input handling
    public bool reorientPressed;
    public Vector2 scrollValue;
    public bool backPressed;

    private void Awake() {
        controls = new Controls();
    }

    private void OnEnable() {
        controls.Enable();
    }

    private void OnDisable() {
        controls.Disable();
    }

    void Update() {
        //Input handling
        reorientPressed = controls.WorldControls.Reorient.IsPressed();
        scrollValue = controls.WorldControls.Zoom.ReadValue<Vector2>();
        backPressed = controls.WorldControls.Back.IsPressed();

        //Mouse zoom
        if (scrollValue.y < 0 && targetFOV < maxFOV) {
            targetFOV += 5;
        } else if (scrollValue.y > 0 && targetFOV > minFOV) {
            targetFOV -= 5;
        }

        //Smooth lerp
        vCam.m_Lens.FieldOfView = Mathf.Lerp(vCam.m_Lens.FieldOfView, targetFOV, Time.deltaTime * zoomSpeed);

        //Curve for orbit speed
        //vCam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = (1 / 12f) * Mathf.Pow(targetFOV, 2) + 42;
        //vCam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = (1 / 12f)  * Mathf.Pow(targetFOV, 2) + 42;

        //Reset screenX
        if (reorientPressed) {
            CenterScreenX();
        }

    }

    public void ResetFOV() {
        targetFOV = 50;
        vCam.m_Lens.FieldOfView = Mathf.Lerp(vCam.m_Lens.FieldOfView, targetFOV, Time.deltaTime * zoomSpeed);
    }

    public void LeftScreenX() {
        vCam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = leftX;
        minFOV = 25f;
    }

    public void CenterScreenX() {
        vCam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = centeredX;
        minFOV = 10f;
    }

}
