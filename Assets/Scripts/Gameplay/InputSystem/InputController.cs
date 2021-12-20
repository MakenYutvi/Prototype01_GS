using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class InputController : MonoBehaviour
{
    [SerializeField]
    private MovementComponent _movementComponent;
    private IAtackComponent _attackComponent;
    [SerializeField]
    private Camera _camera;

    private PlayerInput _playerInput;
    private bool _isMoveRequired = false;
    private Vector2 _moveDirection;
    private IWeaponManager _weaponManager;

    [Inject]
    public void Construct(IAtackComponent attackComponen)
    {
        _attackComponent = attackComponen;
    }
    [Inject]
    public void Construct(IWeaponManager weaponManager)
    {
        _weaponManager = weaponManager;
    }
    void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Fire.performed += context => Attack();
        _playerInput.Player.WeaponState1.performed += context => WeaponState1();
        _playerInput.Player.WeaponState2.performed += context => WeaponState2();
        _playerInput.Player.WeaponState3.performed += context => WeaponState3();
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

    private void WeaponState1()
    {
        _weaponManager.SetState(WeaponStateID.PISTOL);
    }
    private void WeaponState2()
    {
        _weaponManager.SetState(WeaponStateID.RIFLE);
    }
    private void WeaponState3()
    {
        _weaponManager.SetState(WeaponStateID.KNIFE);
    }
}

