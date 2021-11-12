using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IPropertyInjector
{
    // Start is called before the first frame update
    [SerializeField] private float _cooldown = 1.0f;
    [SerializeField] private float _damage = 10.0f;
    [SerializeField] private GameObject _bullet;

    [SerializeField] public Transform _playerPosition;

     private IBulletManager _IBulletManager;


    private float _currentCooldown;
    private Vector3 _reverseRotation;
    private Transform _reverseTransform;

    void Start()
    {
        _currentCooldown = _cooldown;
    }

    // Update is called once per frame
    void Update()
    {

        _currentCooldown -= Time.deltaTime;
        if(_currentCooldown <= 0.0f)
        {
            Debug.Log("enemy shoot");
            //Quaternion reverseQuaternion = Quaternion.Euler(_playerPosition.rotation.eulerAngles.x, _playerPosition.rotation.eulerAngles.y, _playerPosition.rotation.eulerAngles.z);
            //Instantiate(_bullet, this.transform.position, reverseQuaternion);
            //var bullet = Instantiate(_bullet, this.transform);
            //  bullet.SetDirection(_playerPosition.forward);
             
            _IBulletManager.LaunchBullet(this.transform.position, this.transform.rotation, this.transform.forward, null);



              _currentCooldown = _cooldown;

        }
    }

    void IPropertyInjector.Set(IPropertyProvider provider)
    {
        this._IBulletManager = provider.Get<IBulletManager>(PropertyId.BULLET_SYSTEM);
       // this.conditionProvider = provider.Get<DamageConditionChecker>(PropertyId.DAMAGE_CHECKER);
    }
}
