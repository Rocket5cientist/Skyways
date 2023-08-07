using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EarthMovement : MonoBehaviour
{
    private Controls controls;
    public CinemachineVirtualCamera vCam;

    //Zooming
    private float targetFOV = 60f;
    [SerializeField] private float zoomSpeed = 10f;

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
        if (scrollValue.y < 0 && targetFOV < 50) {
            targetFOV += 5;
        } else if (scrollValue.y > 0 && targetFOV > 10) {
            targetFOV -= 5;
        }

        vCam.m_Lens.FieldOfView = Mathf.Lerp(vCam.m_Lens.FieldOfView, targetFOV, Time.deltaTime * zoomSpeed);

	}
}
