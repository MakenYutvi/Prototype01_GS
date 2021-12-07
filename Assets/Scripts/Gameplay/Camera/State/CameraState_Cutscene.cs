using Cinemachine;
using UnityEngine;

public sealed class CameraState_Cutscene : CameraState
{
    [SerializeField]
    private CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        this.virtualCamera.enabled = false;
    }

    public override void OnEnter()
    {
        Debug.Log("CUTSCENE PERSON ENTER");
        this.virtualCamera.enabled = true;
    }

    public override void OnExit()
    {
        Debug.Log("CUTSCENE PERSON EXIT");
        this.virtualCamera.enabled = false;
    }
}