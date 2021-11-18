using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update

    private PlayerInput _playerInput;
    private IBulletManager _BulletManager;
    private Vector2 _center;
    [SerializeField] private Camera _camera;

    [Inject]
    public void Construct(IBulletManager bulletManager)
    {
        _BulletManager = bulletManager;
    }
    void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Fire.performed += context => OnShoot();
        _center.Set(Screen.width / 2.0f, Screen.height / 2.0f);
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
    
    private void OnShoot()
    {
        Vector2 cursor = _playerInput.Player.Cursor.ReadValue<Vector2>();
        Ray ray = _camera.ScreenPointToRay(cursor);
        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 1000);
        bool target = Physics.Raycast(ray, out RaycastHit hit);
        Vector3 direction;
        Vector3 point;
        if (target)
        {
             direction = (hit.point - this.transform.position).normalized;
            //Debug.DrawRay(this.transform.position, direction * 100, Color.blue, 1000);
        }
        else
        {
             point = ray.origin + ray.direction * 100;
             direction = (point - this.transform.position).normalized;
            //Debug.DrawRay(this.transform.position, direction * 100, Color.green, 1000);
        }
        _BulletManager.LaunchBullet(this.transform.position + direction, this.transform.rotation, direction, null);
      

    }
}
