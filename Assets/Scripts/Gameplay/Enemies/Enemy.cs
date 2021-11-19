using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _cooldown = 1.0f;
    [SerializeField] private float _damage = 10.0f;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private WeaponComponent _weaponComponent;
    
    private IBulletManager _BulletManager; 
    private IWeaponManager _weaponManager; 
    private float _currentCooldown;
    private float _fixedDeltaTime;


    void Start()
    {
        _currentCooldown = _cooldown;
        this._fixedDeltaTime = Time.fixedDeltaTime;
    }

    [Inject]
    public void Construct(IBulletManager bulletManager)
    {
        _BulletManager = bulletManager;
    }[Inject]
    public void Construct(IWeaponManager weaponManager)
    {
        _weaponManager = weaponManager;
    }

    void FixedUpdate()
    {

        _currentCooldown -= _fixedDeltaTime;
        if(_currentCooldown <= 0.0f)
        {
            //Debug.Log("enemy shoot");
            //OnShoot();
            Attack();
              _currentCooldown = _cooldown;

        }
    }


    private void Attack()
    {
        var distance = this._playerPosition.position - this.transform.position;
        var direction = distance / distance.magnitude;
        _weaponComponent.Attack(direction);
    }


}
