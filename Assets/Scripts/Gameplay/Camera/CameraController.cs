using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private CameraZoom _cameraZoom;

    public void Zoom()
    {
       // _cameraZoom.ChangeZoom();
        _cameraZoom.ChangeZoom2(3.82f, 7.2f);
    }
}
