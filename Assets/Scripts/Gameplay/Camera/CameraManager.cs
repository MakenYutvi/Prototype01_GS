using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour, ICameraManager
{
    [SerializeField]
    public CameraController _activeCameraController;

    [SerializeField]
    public List<CameraController> _cameraControllersList;

    private void Start()
    {
        foreach( var CameraSystem in _cameraControllersList)
        {
            if(CameraSystem != _activeCameraController)
                CameraSystem.gameObject.SetActive(false);
        }
    }
    public void ZoomDescrete()
    {
        //_activeCameraController.ZoomDescrete();
        var cameraZoomableComponent = _activeCameraController.gameObject.GetComponent<IsCameraZoomable>();
        if (cameraZoomableComponent != null)
        {
            cameraZoomableComponent.Zoom();
        }
    }

    public void SetCameraController(CameraController cameraSystemComponent)
    {
        if (cameraSystemComponent == _activeCameraController)
            return;

        var prevActiveCameraSystemComponent = _activeCameraController;
        foreach (var CameraSystem in _cameraControllersList)
        {
            if (cameraSystemComponent == CameraSystem)
            {
                CameraSystem.gameObject.SetActive(true);
                _activeCameraController = CameraSystem;
            }

            if (prevActiveCameraSystemComponent == CameraSystem)//turn off previous camera
            {
                CameraSystem.gameObject.SetActive(false);
            }

        }
    }
}
