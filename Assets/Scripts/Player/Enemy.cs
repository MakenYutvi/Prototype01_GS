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
    [SerializeField] public Transform _playerPosition;
    
    private IBulletManager _BulletManager; 
    private float _currentCooldown;


    void Start()
    {
        _currentCooldown = _cooldown;
    }

    [Inject]
    public void Construct(IBulletManager bulletManager)
    {
        _BulletManager = bulletManager;
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
            var distance = this._playerPosition.position - this.transform.position;
            var direction = distance / distance.magnitude;
            _BulletManager.LaunchBullet(this.transform.position, this._playerPosition.rotation, direction, null);



              _currentCooldown = _cooldown;

        }
    }


}
