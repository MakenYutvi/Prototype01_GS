using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WeaponComponent : MonoBehaviour, IBulletListener
{
    [SerializeField]
    private int _damage = 5;//задел на будущее
    [SerializeField]
    private DamageController _damageController;

    private IBulletManager _BulletManager;
    public event ActionWeapon<Collider> OnCollideEvent;

    [Inject]
    public void Construct(IBulletManager bulletManager)
    {
        _BulletManager = bulletManager;
    }

    private void OnEnable()
    {
        _damageController.Subscribe(this);
    }

    private void OnDisable()
    {
        _damageController.UnSubscribe(this);
    }
    public void Attack(Vector3 direction)
    {  
        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 1000);       
        _BulletManager.LaunchBullet(this.transform.position + direction, this.transform.rotation, direction, this);
    }

    public void OnBulletCollided(Collider collider)
    {
        //Debug.Log("debug throw listener");
        OnCollideEvent?.Invoke(collider, _damage);
    }
}
