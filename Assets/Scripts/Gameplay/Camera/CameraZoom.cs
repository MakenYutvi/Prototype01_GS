using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera _cameraNear;
    [SerializeField]
    private CinemachineVirtualCamera _cameraFar;

    public void ChangeZoom()
    {
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

    public void ChangeZoom2(float min, float max)
    {
        float currentValue;
        CinemachineComponentBase componentBase = _cameraNear.GetCinemachineComponent(CinemachineCore.Stage.Body);
        if (componentBase is CinemachineFramingTransposer)
        {
            currentValue = (componentBase as CinemachineFramingTransposer).m_CameraDistance;
            if (currentValue == min)
                (componentBase as CinemachineFramingTransposer).m_CameraDistance = max;
            else
                (componentBase as CinemachineFramingTransposer).m_CameraDistance = min;
        }
    }

}
