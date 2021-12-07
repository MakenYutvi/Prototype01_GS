using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public sealed class CameraState_ThirdPerson : CameraState
{
    [SerializeField]
    private CinemachineVirtualCamera _cameraNear;

    [SerializeField]
    private CinemachineVirtualCamera _cameraFar;

    private PlayerInput _playerInput; 

    private void Awake()
    { 
        _playerInput = new PlayerInput();
        _cameraNear.enabled = false;
        _cameraFar.enabled = false;
    }

    public override void OnEnter()
    {
        Debug.Log("THIRD PERSON ENTER");
        _playerInput.Camera.Zoom.performed += this.OnZoom;
        _playerInput.Enable();
        _cameraNear.enabled = true;
        _cameraFar.enabled = true;
    }

    public override void OnExit()
    {
        Debug.Log("THIRD PERSON EXIT");
        _playerInput.Camera.Zoom.performed -= this.OnZoom;
        _playerInput.Disable();
        _cameraNear.enabled = false;
        _cameraFar.enabled = false;
    }

    public void OnZoom(InputAction.CallbackContext obj)
    {
        Debug.Log("ON ZOOM");
        var prioruty = _cameraFar.Priority;
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