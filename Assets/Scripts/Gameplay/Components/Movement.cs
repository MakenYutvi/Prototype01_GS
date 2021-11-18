using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _moveSpeed = 1;

    private PlayerInput _playerInput;
    void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();
    }

    private Vector2 moveDirection;
    
    private void FixedUpdate()
    {
        Move(moveDirection);
        
    }

    private void Move(Vector2 direction)
    {
        float scaledMoveSpeed = _moveSpeed * Time.deltaTime;

        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        this.transform.position += moveDirection * scaledMoveSpeed;
    }
 
}
