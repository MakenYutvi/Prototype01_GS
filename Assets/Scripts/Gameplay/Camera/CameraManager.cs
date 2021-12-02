using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour, ICameraManager
{
    [SerializeField]
    public CameraSystemComponent _activeCameraSystemComponent;

    [SerializeField]
    public List<CameraSystemComponent> _cameraSystemList;

    private void Start()
    {
        foreach( var CameraSystem in _cameraSystemList)
        {
            if(CameraSystem != _activeCameraSystemComponent)
                CameraSystem.gameObject.SetActive(false);
        }
    }
    public void ZoomDescrete()
    {
        _activeCameraSystemComponent.ZoomDescrete();
    }

    public void ActivateCameraSystem(CameraSystemComponent cameraSystemComponent)
    {
        if (cameraSystemComponent == _activeCameraSystemComponent)
            return;

        var prevActiveCameraSystemComponent = _activeCameraSystemComponent;
        foreach (var CameraSystem in _cameraSystemList)
        {
            if (cameraSystemComponent == CameraSystem)
            {
                CameraSystem.gameObject.SetActive(true);
                _activeCameraSystemComponent = CameraSystem;
            }

            if (prevActiveCameraSystemComponent == CameraSystem)//turn off previous camera
            {
                CameraSystem.gameObject.SetActive(false);
            }

        }
    }
}
