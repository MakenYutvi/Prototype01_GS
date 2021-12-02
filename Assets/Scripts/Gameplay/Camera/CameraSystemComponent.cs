using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSystemComponent : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera _cameraNear;
    [SerializeField]
    private CinemachineVirtualCamera _cameraFar;
    [SerializeField]
    private bool IsZoomable;

    public void ZoomDescrete()
    {
        if (!IsZoomable)
            return;

        int prioruty = _cameraFar.Priority;
        if (_cameraFar.Priority != _cameraNear.Priority)
        {
            _cameraFar.Priority = _cameraNear.Priority;
            _cameraNear.Priority = prioruty;
        }
        else
        {
            Debug.LogError("Cameras with same priority");
        }
    }

}
