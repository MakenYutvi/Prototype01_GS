using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerFollowPerson : CameraController, IsCameraZoomable
{
    public void Zoom()
    {
        
        int prioruty = base._cameraFar.Priority;
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
