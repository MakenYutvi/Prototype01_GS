using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TestCamera : MonoBehaviour
{
    [SerializeField]
    private CameraStateId stateId;
    
    [SerializeField]
    private Button _button;

    private ICameraStateManager _cameraManager;

    [Inject]
    public void Construct(ICameraStateManager cameraManager)
    {
        _cameraManager = cameraManager;
    }

    private void OnEnable()
    {
        this._button.onClick.AddListener(this.OnButtonClicked);
    }

    private void OnDisable()
    {
        this._button.onClick.RemoveListener(this.OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        this._cameraManager.SetState(this.stateId);
    }
}
