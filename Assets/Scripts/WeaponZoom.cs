using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cam;
    [SerializeField] FirstPersonController firstPersonController;
    [SerializeField] float baseRotateSpeed;
    [SerializeField] float zoomRotateSpeed;
    [Space]
    [SerializeField] float baseFOV;
    [SerializeField] float zoomFOV;
    [SerializeField] float zoomSpeed;
    bool isZoomingIn = false;

    void Start()
    {
        baseRotateSpeed = firstPersonController.RotationSpeed;
        baseFOV = cam.m_Lens.FieldOfView;
    }

    void Update()
    {
        ZoomIn();
        ZoomOut();
    }

    void ZoomIn()
    {
        if (!isZoomingIn || cam.m_Lens.FieldOfView == zoomFOV) return;

        firstPersonController.RotationSpeed = zoomRotateSpeed;
        cam.m_Lens.FieldOfView = Mathf.Lerp(cam.m_Lens.FieldOfView, zoomFOV, zoomSpeed * Time.deltaTime);
    }

    void ZoomOut()
    {
        if (isZoomingIn || cam.m_Lens.FieldOfView == baseFOV) return;

        firstPersonController.RotationSpeed = baseRotateSpeed;
        cam.m_Lens.FieldOfView = Mathf.Lerp(cam.m_Lens.FieldOfView, baseFOV, zoomSpeed * Time.deltaTime);
    }

    void OnAim(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            isZoomingIn = true;
        }
        else
        {
            isZoomingIn = false;
        }
    }

    void OnDisable()
    {
        isZoomingIn = false;
        cam.m_Lens.FieldOfView = baseFOV;
    }
}
