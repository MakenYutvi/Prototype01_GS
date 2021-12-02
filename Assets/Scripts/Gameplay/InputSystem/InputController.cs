using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputController : MonoBehaviour
{
    [SerializeField]
    private MovementComponent _movementComponent;
    [SerializeField]
    private AttackComponent _attackComponent;
    [SerializeField]
    private Camera _camera;

    private ICameraManager _cameraManager;

    private PlayerInput _playerInput;
    private bool _isMoveRequired = false;
    private Vector2 _moveDirection;

    [Inject]
    public void Construct(ICameraManager cameraManager)
    {
        _cameraManager = cameraManager;
    }
    [Inject]

    void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Fire.performed += context => Attack();
        _playerInput.Camera.Zoom.performed += context => CameraZoom();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    void Update()
    {
        _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();
        _isMoveRequired = true;
    }

    private void FixedUpdate()
    {
        if (_isMoveRequired)
        {
            _movementComponent.Move(_moveDirection);
            _isMoveRequired = false;
        }

    }

    private void Attack()
    {
        Vector2 cursor = _playerInput.Player.Cursor.ReadValue<Vector2>();
        Ray ray = _camera.ScreenPointToRay(cursor);
        _attackComponent.Attack(ray);
    }

    private void CameraZoom()
    {
        _cameraManager.ZoomDescrete();
    }


}

