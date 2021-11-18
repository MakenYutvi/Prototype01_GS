using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementComponent : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _moveSpeed = 5;

    private PlayerInput _playerInput;
    private Vector2 _moveDirection;
    private bool _isMoveRequired = false;
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
        _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();
        _isMoveRequired = true;
    }

    private void FixedUpdate()
    {
        if(_isMoveRequired)
        {
            Move(_moveDirection);
            _isMoveRequired = false;
        }
        
    }

    private void Move(Vector2 direction)
    {
        float scaledMoveSpeed = _moveSpeed * Time.deltaTime;

        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        this.transform.position += moveDirection * scaledMoveSpeed;
    }
 
}
